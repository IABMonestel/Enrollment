using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace DataAccess
{
    public class DACareerMatter
    {
        //atributos
        private string _cadenaConexion;
        private string _mensaje;

        //propiedad
        public string Mensaje
        {
            get => _mensaje;
        }
        //Establece cadena de conexion
        public string CadenaConexion
        {
            set => _cadenaConexion = value;
        }
        //Default constructor
        public DACareerMatter()
        {
            _cadenaConexion = string.Empty;
            _mensaje = string.Empty;
        }
        //Constuctor with parameters
        public DACareerMatter(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        //Methods
        //Inserta una materia carrera
        public int Insertar(CareerMatter career)
        {
            //objeto que se usa para establecer una conexión con la BD
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            //conexion.ConnectionString = _cadenaConexion;
            //Objeto que se usa para ejecutar comando de SQL(INSERT,DELETE, UPDATE, SELECT, EXECUTE)
            SqlCommand comando = new SqlCommand();
            int id = -1;
            //preparando el sqlcammand para ejecutar una consulta o instruccion
            string sentencia = "INSERT INTO TBL_MateriasCarreras(CodigoCarrera,CodigoMateria,Requisito,corequisito)"+
                " VALUES(@COD_CARRERA, @COD_MATERIA, @REQUISITO, @CORREQUISITO) select @@identity";
            //Sentencia sql a ejecuar
            comando.Connection = conexion;//Asigna una conexion al comando
            //Parámetros de entrada
            comando.Parameters.AddWithValue("@COD_CARRERA", career.CareerCode);
            comando.Parameters.AddWithValue("@COD_MATERIA", career.MatterCode);
            if (career.Requirement == null) {//requirrement is null
                comando.Parameters.AddWithValue("@REQUISITO", DBNull.Value);
            } else {
                comando.Parameters.AddWithValue("@REQUISITO", career.Requirement);
            }
            if (career.Corequisite == null)//corequisite is null
            {
                comando.Parameters.AddWithValue("@CORREQUISITO", DBNull.Value);
            }
            else
            {
                comando.Parameters.AddWithValue("@CORREQUISITO", career.Corequisite);
            }
            //define la sentencia al comando 
            comando.CommandText = sentencia;
            try
            {
                conexion.Open();//abre la conexion
                //retorna filas afectadas
                id = Convert.ToInt32(comando.ExecuteScalar());
                conexion.Close();//Cierra la conexion
            }
            catch (Exception)
            {
                throw;
            }
            finally//borra datos temporales de objetos creados
            {
                conexion.Dispose();
                comando.Dispose();
            }
            return id;//retorna filas afectadas
        }

        //return List of career matter
        public List<CareerMatter> ListarMateriasCarrera(string condicion = "", string orden = "")//
        {
            DataSet DS = new DataSet();//objeto para cargar información de la lista
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//Objeto que define la conexion mediante una cadena
            SqlDataAdapter adapter;//adaptador para ejecuar la sentencia en una conexion
            List<CareerMatter> Lista = new List<CareerMatter>();//Lista vacía de materias carreras
            //Sentencia a ejecutar
            string sentencia = "SELECT CodeCareerMatter,NameM,Code,NameC,CareerCode,Requirement,Corequisite FROM dbo.MATERIAS_MATCARRERAS_CARRERAS";
            //concatena condicion si exista
            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = string.Format("{0} where {1}", sentencia, condicion);
            }
            //{//si orden no esta vacia entonces concatene ese orden a la sentencia
            if (!string.IsNullOrEmpty(orden))
            {
                sentencia = string.Format("{0} order by {1}", sentencia, orden); 
            }
            
            try
            {
                //obtiene los datos de la sentecia ejecutada en esa conexion
                adapter = new SqlDataAdapter(sentencia, conexion);
                //carga los datos obtenidos en el data set
                adapter.Fill(DS, "dbo.MATERIAS_MATCARRERAS_CARRERAS");                
                //sentencia linq
                Lista = (from DataRow fila in DS.Tables[0].Rows
                         select new CareerMatter()//nuevo objeto carreras materias
                         {
                             CodeCareerMatter = (int)fila[0],
                             Name = fila[1].ToString(),
                             Code = fila[2].ToString(),
                             CareerName = fila[3].ToString(),
                             CareerCode = (int)fila[4],
                             Requirement = fila[5].ToString(),
                             Corequisite = fila[6].ToString(),
                             ExistsCarrerMatter = true
                         }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;//lista de objetos carreras materias
        }
        //Buscar una materia carrera
        public CareerMatter ObtenerMateriaCarrera(int id)
        {
            CareerMatter careerMatter = null;//objeto nulo de carrera materia
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//establece la conexion
            SqlCommand comando = new SqlCommand();//comando sql
            SqlDataReader dataReader;//lector de datos sql
            //sentencia a ejecutar
            string sentencia = string.Format("SELECT CodeCareerMatter, NameM, Code, NameC, CareerCode, Requirement, Corequisite" +
                " FROM dbo.MATERIAS_MATCARRERAS_CARRERAS where CodeCareerMatter = {0}", id);
            comando.Connection = conexion;//define la conexion para que se ejecute el comando

            comando.CommandText = sentencia;//asigna la sentencia a ejecutar
            try
            {
                conexion.Open();//abre la conexion
                dataReader = comando.ExecuteReader();//obtiene los datos 
                if (dataReader.HasRows)//verifica si sentencia devolvio datos
                {
                    careerMatter = new CareerMatter();//objeto por defaul de materia carrera
                    //lee los datos
                    dataReader.Read();
                    //asigna los valores
                    careerMatter.CodeCareerMatter = dataReader.GetInt32(0);
                    careerMatter.Name = dataReader.GetString(1);
                    careerMatter.MatterCode = dataReader.GetString(2);
                    careerMatter.CareerName = dataReader.GetString(3);
                    careerMatter.CareerCode = dataReader.GetInt32(4);
                    if (!dataReader.IsDBNull(5))//if requirement is null
                    {
                        careerMatter.Requirement = dataReader.GetString(5);
                    }
                    else
                    {//else
                        careerMatter.Requirement = string.Empty;
                    }
                    if (!dataReader.IsDBNull(6))
                    {
                        careerMatter.Corequisite = dataReader.GetString(6);
                    }
                    else
                    {
                        careerMatter.Corequisite = string.Empty;
                    }
                }
                conexion.Close();//cierra la conexion
            }
            catch (Exception)
            {
                throw;
            }
            return careerMatter;//retorno de objeto
        }
    }
}
