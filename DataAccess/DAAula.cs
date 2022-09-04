using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace DataAccess
{
    public class DAAula
    {
        //atributos
        private string _cadenaConexion;
        private string _mensaje;

        //propiedad
        public string Mensaje
        {
            get => _mensaje;
        }
        //Establece la cadena de conexión
        public string CadenaConexion
        {
            set => _cadenaConexion = value;
        }
        //Default Constructor
        public DAAula()
        {
            _cadenaConexion = string.Empty;
            _mensaje = string.Empty;
        }
        //Constructor with parameters
        public DAAula(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        //métodos
        //Obtiene la lista de aulas
        public List<Aula> ListarAulas(string condicion = "", string orden = "")
        {
            DataSet DS = new DataSet();//Objeto que carga información de tabla o consulta
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//Objeto sql que conecta con la base de datos
            //mediante la cadena de conexion
            SqlDataAdapter adapter;//Objeto sql que ejecuta la sentencia usando la conexion y devuelve
            //el resultado de la consulta
            List<Aula> Lista = new List<Aula>();//lista para retornar las aulas
            string sentencia = "SELECT Codigo,Tipo,Numero,Capacidad FROM TBL_Aulas ";
            //sentencia para ejecutar consulta
            if (!string.IsNullOrEmpty(condicion))//Concatena la condicion si existe
            {
                sentencia = string.Format("{0} where {1}", sentencia, condicion);
            }
            if (!string.IsNullOrEmpty(orden))//Concatena la condicion si existe
            {
                //Establece un orden para la llista
                sentencia = string.Format("{0} order by {1}", sentencia, orden);
            }
            try
            {
                //Se carga el adaptador sql con la consulta y conexion
                adapter = new SqlDataAdapter(sentencia, conexion);
                //Carga el DataSet con el resultado de consulta y le asigna un nombre
                adapter.Fill(DS, "TBL_Aulas");
                //sentencia linq, carga la lista con la información del data set
                Lista = (from DataRow fila in DS.Tables[0].Rows
                         select new Aula()
                         {
                             Codigo = (short)fila[0],
                             Tipo = fila[1].ToString(),
                             Numero = (byte)fila[2],
                             Capacidad = (byte)fila[3],
                             Existe = true
                         }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return Lista;//retorna la lista 
        }
        //Elimina un aula
        public int Delete(int aula)
        {
            int resultado = -1;//valor de retorno
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//Objetos para establecer conexion
            SqlCommand comando = new SqlCommand();//Comandos SQL a ejecutar sentencia consulta
            comando.Connection = conexion; //carga la conexion en el comando a ejecutar
            comando.CommandText = "SP_DeleteAulas";//Nombre de procedimiento almacenado
            comando.CommandType = CommandType.StoredProcedure;//Indica que debe buscar procedimiento almacenado
            //parametro de entrada
            comando.Parameters.AddWithValue("@Codigo", aula);
            //parametro de salida
            comando.Parameters.Add("@msj", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                conexion.Open();//Abre conexion
                comando.ExecuteNonQuery();//Ejecuta
                //leer el parametro de salida
                resultado = Convert.ToInt32(comando.Parameters["@retorno"].Value);//valor de retorno del SP
                _mensaje = comando.Parameters["@msj"].Value.ToString();//Mensaje del SP
                conexion.Close();//Cierra conexion
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;//retorno según ejecución de procedimiento
        }
        //Método para insertar un aula
        public int Insertar(Aula aula)//Ingresa un aula
        {
            int resultado = -1;//Valor a retornar
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//Objeto sql que establce la conexion 
            //usando una cadena de conexion
            SqlCommand comando = new SqlCommand();//Objeto sql que establce el comando a ejecutar
            comando.Connection = conexion;//Obtiene la conexion para el comando
            comando.CommandText = "SP_ActualizaAulas";//Nombre de sp
            comando.CommandType = CommandType.StoredProcedure;//Indica que debe buscar un procedimiento almacenado
            //parametro de entrada
            comando.Parameters.AddWithValue("@Codigo", aula.Codigo);
            comando.Parameters.AddWithValue("@Tipo", aula.Tipo);
            comando.Parameters.AddWithValue("@Numero", aula.Numero);
            comando.Parameters.AddWithValue("@Capacidad", aula.Capacidad);
            //parametro de salida
            comando.Parameters.Add("@msj", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                conexion.Open();//Abre la conexion
                comando.ExecuteNonQuery();//Ejecuta el comando procedimiento almacenado
                //leer el parametro de salida
                resultado = Convert.ToInt32(comando.Parameters["@retorno"].Value);
                _mensaje = comando.Parameters["@msj"].Value.ToString();
                conexion.Close();//cierra la conexion
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;//retorno según ejecución de procedimiento
        }

        public Aula ObtenerAula(byte id)//Obtiene el aula
        {
            Aula aula = null;//Define un objeto nulo
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//Establece conexión usando cadena de conexión
            SqlCommand comando = new SqlCommand();//Objeto sql con sentencia a ejecutar 
            SqlDataReader dataReader;//Objeto data reader que almacena los datos devueltos por la consulta
            string sentencia = string.Format("SELECT Codigo,Tipo,Numero,Capacidad FROM TBL_Aulas where Codigo={0}", id);
            //sentencia a ejecutar
            comando.Connection = conexion;//Define conexion a comando a ejecutar
            comando.CommandText = sentencia;//define la sentencia al comando sql
            try
            {
                conexion.Open();//abre la conexion
                dataReader = comando.ExecuteReader();//carga la información de la consulta en el objeto sqlDataReader
                if (dataReader.HasRows)//Comprueba si obtuvo algo
                {
                    aula = new Aula();//Instancia default de aula
                    dataReader.Read();//lee la información del data reader
                    //Asiga los valores correspondientes
                    aula.Codigo = Convert.ToInt16(dataReader.GetInt16(0));
                    aula.Tipo = dataReader.GetString(1);
                    aula.Numero = Convert.ToByte(dataReader.GetByte(2));
                    aula.Capacidad = Convert.ToByte(dataReader.GetByte(3));
                    aula.Existe = true;
                }
                conexion.Close();//Cierra la conexion
            }
            catch (Exception)
            {
                throw;
            }
            return aula;//retorna el objeto según procesamiento
        }
    }
}
