using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace DataAccess
{
    public class DACareers
    {
        //atributos
        private string _cadenaConexion;
        private string _mensaje;

        //propiedad
        public string Mensaje
        {
            get => _mensaje;
        }
        public string CadenaConexion
        {
            set => _cadenaConexion = value;
        }
        public DACareers()
        {
            _cadenaConexion = string.Empty;
            _mensaje = string.Empty;
        }

        public DACareers(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        //métodos
        //retorna lista de carreras
        public List<Careers> ListarCareers(string condicion = "")
        {
            DataSet DS = new DataSet();//objeto data set para cargar datos devueltos por la consulta
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//objeto sql que define conexion usando una cadena
            SqlDataAdapter adapter;//adaptador sql que ejecuta la sentencia
            List<Careers> Lista = new List<Careers>();//lista de carreras
            //sentencia sql a ejecutar
            string sentencia = "SELECT CodigoCarrera, NombreCarrera, TotalCreditos, GradoCarrera FROM TBL_Carreras";
            if (!string.IsNullOrEmpty(condicion))
            {   //concatena condicion si existe
                sentencia = string.Format("{0} where {1}", sentencia, condicion);
            }
            try
            {   //adaptador sql que ejecuta la sentencia
                adapter = new SqlDataAdapter(sentencia, conexion);
                //carga los datos de la consulta en el DataSet
                adapter.Fill(DS, "TBL_Carreras");
                //sentencia linq
                Lista = (from DataRow fila in DS.Tables[0].Rows
                         select new Careers()//objeto carrera por default
                         {
                             //asigna valores
                             Code = (int)fila[0],
                             Name = fila[1].ToString(),
                             Credits = (short)fila[2],
                             Degree = fila[3].ToString(),
                             Exists = true
                         }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return Lista;//lista de carreras
        }

        //Inserta una carrera
        public int Insertar(Careers career)
        {
            int resultado = -1;//resultado por defecto
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//Objeto sql que define la conexion
            SqlCommand comando = new SqlCommand();//comando sql que define sentencia
            comando.Connection = conexion;//se asigna conexion al comando
            comando.CommandText = "SP_ActualizaCarreras";//indica nombre de procedimiento a ejecutar
            comando.CommandType = CommandType.StoredProcedure;//indica que debe ejecutar un sp
            //parametro de entrada
            comando.Parameters.AddWithValue("@Codigo", career.Code);
            comando.Parameters.AddWithValue("@Nombre", career.Name);
            comando.Parameters.AddWithValue("@Creditos", career.Credits);
            comando.Parameters.AddWithValue("@Grado", career.Degree);
            //parametro de salida
            comando.Parameters.Add("@MSJ", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                conexion.Open();//abre la conexion
                comando.ExecuteNonQuery();//execute sentencia 
                //leer el parametro de salida
                resultado = Convert.ToInt32(comando.Parameters["@retorno"].Value);
                _mensaje = comando.Parameters["@MSJ"].Value.ToString();
                conexion.Close();//cierra la conexion
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;//retorno del procedimiento
        }
        //elimina una carrera
        public int Delete(Careers career)
        {
            int resultado = -1;//return of default
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//objeto que define conexion
            SqlCommand comando = new SqlCommand();//comando que ejecuta sentencia
            comando.Connection = conexion;//conexion del comando sql
            comando.CommandText = "SP_DeleteCarreras";//procedimiento a ejecutar
            comando.CommandType = CommandType.StoredProcedure;//define que debe ejecutar un procedimiento almacenado
            //parametro de entrada
            comando.Parameters.AddWithValue("@Codigo", career.Code);
            //parametro de salida
            comando.Parameters.Add("@MSJ", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                conexion.Open();//abre la conexion
                comando.ExecuteNonQuery();//ejecuta la sentencia
                //leer el parametro de salida
                resultado = Convert.ToInt32(comando.Parameters["@retorno"].Value);
                _mensaje = comando.Parameters["@MSJ"].Value.ToString();
                conexion.Close();//cierra la conexion
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;//retorno del procedmiento
        }
        //obtiene una carrera por id
        public Careers GetCareer(int idCarrera)
        {
            Careers carrer = null;//objeto nulo de carreras
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//objeto sql de conexion 
            SqlCommand comando = new SqlCommand();//objeto sql que carga la sentencia
            SqlDataReader dataReader;//objeto que carga la información de la consulta
            //sentencia sql
            string sentencia = string.Format("SELECT CodigoCarrera, NombreCarrera, TotalCreditos, GradoCarrera FROM TBL_Carreras where CodigoCarrera={0}", idCarrera);
            comando.Connection = conexion;//asiga la conexion al comando sql
            comando.CommandText = sentencia;//asiga la sentencia al comando sql
            try
            {
                conexion.Open();//abre la conexion
                dataReader = comando.ExecuteReader();//ejecuta el comando
                if (dataReader.HasRows)//comprueba si la consulta retorno datos
                {
                    carrer = new Careers();//objeto default de carreras
                    dataReader.Read();//lee información del data reader
                    //asigna los datos
                    carrer.Code = dataReader.GetInt32(0);
                    carrer.Name = dataReader.GetString(1);
                    carrer.Credits = dataReader.GetInt16(2);
                    carrer.Degree = dataReader.GetString(3);
                    carrer.Exists = true;
                }
                conexion.Close();//cierra la conexion
            }
            catch (Exception)
            {
                throw;
            }
            return carrer;//retorna objeto
        }
    }
}
