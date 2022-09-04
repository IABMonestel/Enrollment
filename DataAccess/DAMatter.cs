using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace DataAccess
{
    public class DAMatter
    {

        //atributos
        private string _cadenaConexion;
        private string _mensaje;

        //propiedad
        public string Mensaje
        {
            get => _mensaje;
        }
        //set cadena de conexion
        public string CadenaConexion
        {
            set => _cadenaConexion = value;
        }
        //constuctor por default
        public DAMatter()
        {
            _cadenaConexion = string.Empty;
            _mensaje = string.Empty;
        }
        //constructor con cadena de conexion
        public DAMatter(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        //métodos
        //lista de materias
        public List<Matter> ListarMaterias(string condicion = "", string orden = "")
        {
            DataSet DS = new DataSet();//objeto data set para establecer datos
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//objeto sql para definir conexion
            SqlDataAdapter adapter;//objeto sql data adapter para ejecutar sentencia
            List<Matter> Lista = new List<Matter>();//lista vacia de materias
            //sentencia para obtener datos de materia
            string sentencia = "SELECT Code, NameM, Credits, Erased FROM TBL_Matters WHERE Erased = 0";
            if (!string.IsNullOrEmpty(condicion))
            {//concatena la condicion si existe
                sentencia = string.Format("{0} AND {1}", sentencia, condicion);
            }

            if (!string.IsNullOrEmpty(orden))
            {//si orden no esta vacia entonces concatene ese orden a la sentencia
                sentencia = string.Format("{0} order by {1}", sentencia, orden);
            }

            try
            {
                adapter = new SqlDataAdapter(sentencia, conexion);//ejecuta la sentencia en el sql data adapter
                adapter.Fill(DS, "TBL_Materias");//carga datos devueltos en el data set
                //sentencia linq
                Lista = (from DataRow fila in DS.Tables[0].Rows
                         select new Matter()//objeto por defecto
                         {                             
                             //asignar valores
                             Code = fila[0].ToString(),
                             Name = fila[1].ToString(),
                             Credits = Convert.ToByte(fila[2]),
                             Erased = Convert.ToBoolean(fila[3]),
                             Exists = true
                         })
                .ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return Lista;//retorna la lista
        }
        //obtiene una materia por codigo
        public Matter GetMatter(string code)
        {
            Matter matter = null;//objeto nulo de materia para retornar
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//objeto sql que define la conexion
            SqlCommand comando = new SqlCommand();//comando sql que ejecuta la sentencia
            SqlDataReader dataReader;//objeto que lee los datos de la consulta
            //consulta sql que devuelve los datos de la materia
            string sentencia = string.Format("SELECT Code, NameM, Credits, Erased FROM TBL_Matters WHERE Code = '{0}'", code);
            comando.Connection = conexion;//asigna conexion a comando sql
            comando.CommandText = sentencia;//asigna sentencia a comando sql
            try
            {
                conexion.Open();//abre la conexion
                dataReader = comando.ExecuteReader();//ejecuta el comando y carga datos
                if (dataReader.HasRows)//comprueba que haya retornado datos
                {
                    matter = new Matter();//instancia por default 
                    dataReader.Read();//lee datos del sql data reader
                    //asigna datos
                    matter.Code = dataReader.GetString(0);
                    matter.Name = dataReader.GetString(1);
                    matter.Credits = dataReader.GetByte(2);
                    matter.Erased = dataReader.GetBoolean(3);
                    matter.Exists = true;
                }
                conexion.Close();//cierra la conexion
            }
            catch (Exception)
            {
                throw;
            }
            return matter;//objeto retorno
        }

        //Eliminar materia con SP
        public int DeleteMatter(string code)
        { //eliminar registro con Stored Procedure
            int resultado = -1;//retorno por defecto
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//objeto sql que defina la conexion
            SqlCommand comando = new SqlCommand();//comando sql que ejecuta la conexion
            comando.CommandText = "SP_Delete_Matter"; //nombre del procedimiento almacenado
            comando.CommandType = CommandType.StoredProcedure;//se especifica que tipo de comando es, en este caso es un procedimiento almacenado
            comando.Connection = conexion;//asigna conexion a comando
            //parametro de entrada para el SP
            comando.Parameters.AddWithValue("@Cod_Materia",code);
            //parametro de salida del SP
            comando.Parameters.Add("@msj", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;//definicion del parametro de salida del procedimiento almacenado
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;//se declara otro parametro de retorno del SP que obtenga el retorno del SP

            try
            {
                conexion.Open();//abre la conexion
                comando.ExecuteNonQuery(); //ejecuta el SP y se llenan las variables de retorno del SP
                resultado = Convert.ToInt32(comando.Parameters["@retorno"].Value); //obtengo la variable de retorno
                //se va a leer el parametro de salida del SP
                _mensaje = comando.Parameters["@msj"].Value.ToString();//obtiene el mensaje que se devolvio del SP
                conexion.Close();//cierra la conexion
            }
            catch (Exception)
            {

                throw;
            }
            return resultado;//retorno del sp
        }
        //Crear o actualizar materia con SP
        public int UpdateMatter(Matter matter)
        { //update registro con Stored Procedure
            int resultado = -1;//retorno por default
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//sql objeto que define la conexion
            SqlCommand comando = new SqlCommand();//comando sql que ejecuta la sentencia
            comando.CommandText = "SP_ActualizaMaterias"; //nombre del procedimiento almacenado
            comando.CommandType = CommandType.StoredProcedure;//se especifica que tipo de comando es, en este caso es un procedimiento almacenado
            comando.Connection = conexion;//asigna conexion a comando
            //parametro de entrada para el SP
            comando.Parameters.AddWithValue("@Codigo", matter.Code);
            comando.Parameters.AddWithValue("@Nombre", matter.Name);
            comando.Parameters.AddWithValue("@Creditos", matter.Credits);
            //parametro de salida del SP
            comando.Parameters.Add("@msj", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;//definicion del parametro de salida del procedimiento almacenado
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;//se declara otro parametro de retorno del SP que obtenga el retorno del SP

            try
            {
                conexion.Open();//abre la conexion
                comando.ExecuteNonQuery(); //ejecuta el SP y se llenan las variables de retorno del SP
                resultado = Convert.ToInt32(comando.Parameters["@retorno"].Value); //obtengo la variable de retorno
                //se va a leer el parametro de salida del SP
                _mensaje = comando.Parameters["@msj"].Value.ToString();//obtiene el mensaje que se devolvio del SP
                conexion.Close();//cierra la conexion
            }
            catch (Exception)
            {

                throw;
            }
            return resultado;//retorno de procedimiento almacenado
        }
    }
}
