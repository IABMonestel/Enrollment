using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess
{
    public class DAOpenSubjects
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
        //constructor por default
        public DAOpenSubjects()
        {
            _cadenaConexion = string.Empty;
            _mensaje = string.Empty;
        }
        //constructor con cadena de conexion
        public DAOpenSubjects(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //******* methods *** //
        //inserta materia con un horario
        public int Insertar(OpenSubject openSubject, Schedule schedule)
        {
            int resultado = -1;//retorno por defecto
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//define conexion
            SqlCommand comando = new SqlCommand();//comando que ejecuta sentencia
            comando.Connection = conexion;//define conexion para comando
            comando.CommandText = "SP_ActualizaMateriasAbiertas";//procedimiento a ejecutar
            comando.CommandType = CommandType.StoredProcedure;//indica que debe ejecutar un procedimiento almacenado
            //parametro de entrada
            comando.Parameters.AddWithValue("@CodMateriaAbierta", openSubject.OpenSubjectsCode);
            comando.Parameters.AddWithValue("@CodMateriaCarrera", openSubject.CareerMatterCode);
            comando.Parameters.AddWithValue("@Grupo", openSubject.Group);
            comando.Parameters.AddWithValue("@Cupo", openSubject.Quota);
            comando.Parameters.AddWithValue("@Costo", openSubject.Cost);
            comando.Parameters.AddWithValue("@Period", openSubject.Period);
            comando.Parameters.AddWithValue("@_Year", openSubject.Year);
            comando.Parameters.AddWithValue("@Disponible", openSubject.Available);
            comando.Parameters.AddWithValue("@Dia", schedule.Dia);
            comando.Parameters.AddWithValue("@HoraInicio", DateTime.Parse(schedule.StartTime));
            comando.Parameters.AddWithValue("@HoraFin", DateTime.Parse(schedule.EndTime));            
            //parametro de salida
            comando.Parameters.Add("@msj", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                conexion.Open();//abre conexion
                comando.ExecuteNonQuery();//ejecuta comando sql
                //leer el parametro de salida
                resultado = Convert.ToInt32(comando.Parameters["@retorno"].Value);
                _mensaje = comando.Parameters["@msj"].Value.ToString();
                conexion.Close();//cierra conexion
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;//retorno de procedimiento
        }
        //lista de materias a matricular
        public List<OpenSubject> ListarMateriasMatricular(string condicion)
        {
            DataSet DS = new DataSet();//objeto para establecer datos
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//objeto que define conexion sql
            SqlDataAdapter adapter;//adaptador sql que ejecuta la sentencia
            List<OpenSubject> Lista = new List<OpenSubject>();//lista vacia de materias abiertas
            //sentencia que recupera datos de una vista
            string sentencia = "SELECT OpenSubjectsCode, CareerMatterCode,ProfesorCode,AulaCode,GroupO,Quota,"+
                            "Cost,PeriodO,YearO, NameM, Code, CareerCode, NOMBRECARRERA, Requirement, Corequisite"+
                            " FROM dbo.VIEW_MAT_ABIER_MATRICULAR";
            if (!string.IsNullOrEmpty(condicion))
            {//concatena condicion si existe
                sentencia = string.Format("{0} where {1}", sentencia, condicion);
            }
            try
            {
                //ejecuta sentencia sql
                adapter = new SqlDataAdapter(sentencia, conexion);
                //carga datos que devuelve la consulta
                adapter.Fill(DS, "MateriasMatricular");
                //sentencia linq
                Lista = (from DataRow fila in DS.Tables[0].Rows
                         select new OpenSubject()//objeto por defecto
                         {
                             //asigna valores
                             OpenSubjectsCode = (int)fila[0],
                             CareerMatterCode = (int)fila[1],
                             ProfesorCode = fila.IsNull(2) ? 0 : (int)fila[2],
                             AulaCode = (short)(fila.IsNull(3) ? 0 : (short)fila[3]),  
                             Group = (byte)fila[4],
                             Quota = (byte)fila[5],
                             Cost = (decimal)fila[6],
                             Period = (byte)fila[7],
                             Year = (short)fila[8],
                             Name = fila[9].ToString(),
                             Code = fila[10].ToString(),
                             CareerCode = (int)fila[11],
                             CareerName = fila[12].ToString(),
                             Requirement = fila[13].ToString(),
                             Corequisite = fila[14].ToString(),
                             Exists = true
                         }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return Lista;//retorna la lista
        }
        //asigna profesor en null a materia a bierta
        public int DesasignarProfe(int v1)
        {
            int resultado = -1;//retorno por defecto
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//objeto que establece la conexion
            SqlCommand comando = new SqlCommand();//comando que ejecuta sentencia
            comando.Connection = conexion;//asigna conexion a comando
            comando.CommandText = "SP_DESASIGNAR_PROFESOR";//procedimiento a ejecutar
            comando.CommandType = CommandType.StoredProcedure;//indica que debe ejecutar un procedimiento
            //parametro de entrada
            comando.Parameters.AddWithValue("@ID_Materia", v1);
            //parametro de salida
            comando.Parameters.Add("@msj", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                conexion.Open();//abre conexion
                comando.ExecuteNonQuery();//ejecuta comando sql
                //leer el parametro de salida
                resultado = Convert.ToInt32(comando.Parameters["@retorno"].Value);
                _mensaje = comando.Parameters["@msj"].Value.ToString();
                conexion.Close();//cierra la conexion
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;//retorno del procedimiento
        }
        //asigna en null el aula
        public int DesasignarAula(int v1)
        {
            int resultado = -1;//retorno por defaulr
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//establece conexion sql
            SqlCommand comando = new SqlCommand();//establece comando que ejecuta sentencia sql
            comando.Connection = conexion;//asigna conexion a comando
            comando.CommandText = "SP_DESASIGNAR_AULA";//procedimiento a ejecutar
            comando.CommandType = CommandType.StoredProcedure;//indica que debe ejecutar un procedimiento
            //parametro de entrada
            comando.Parameters.AddWithValue("@ID_Materia", v1);

            //parametro de salida
            comando.Parameters.Add("@msj", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                conexion.Open();//abre conexion
                comando.ExecuteNonQuery();//ejecuta comando
                //leer el parametro de salida
                resultado = Convert.ToInt32(comando.Parameters["@retorno"].Value);
                _mensaje = comando.Parameters["@msj"].Value.ToString();
                conexion.Close();//cierra conexion
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;//retorno del procedimiento
        }
        //obtiene materia abierta por id disponibles
        public OpenSubject GetOpenSubjectD(int idMatAbierta)
        {
            OpenSubject openSubject = null;//objeto nulo de materia a bierta
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//objeto que define la materia
            SqlCommand comando = new SqlCommand();//objeto comando que ejecuta la sentencia
            SqlDataReader dataReader;//objeto sql data reader que ejecuta comando
            //sentencia sql
            string sentencia = string.Format("SELECT OpenSubjectsCode, CareerMatterCode, NameM, Code, Requirement, ProfesorCode,"+
                   "AulaCode, GroupO, Quota, Cost, PeriodO, YearO, NOMBRECARRERA from dbo.MATERIAS_MATABIERTAS_CARRERAS "+
                "where OpenSubjectsCode = {0}", idMatAbierta);
            comando.Connection = conexion;//asigna conexion a comando
            comando.CommandText = sentencia;//asigna sentencia a comando
            try
            {
                conexion.Open();//abre conexion
                dataReader = comando.ExecuteReader();//ejecuta comando y gurda datos
                if (dataReader.HasRows)//comprueba si cargó datos
                {
                    openSubject = new OpenSubject();//objeto por defecto
                    dataReader.Read();//lee datos devueltos
                    //asigna valores 
                    openSubject.OpenSubjectsCode = dataReader.GetInt32(0);
                    openSubject.CareerMatterCode = dataReader.GetInt32(1);
                    openSubject.Name = dataReader.GetString(2);
                    openSubject.Code = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4))//comprueba requirement is null
                    {
                        openSubject.Requirement = dataReader.GetString(4);
                    }
                    else
                    {
                        openSubject.Requirement = string.Empty;
                    }
                    if (!dataReader.IsDBNull(5))
                    {
                        openSubject.ProfesorCode = dataReader.GetInt32(5);
                    }
                    else
                    {
                        openSubject.ProfesorCode = 0;
                    }
                    if (!dataReader.IsDBNull(6))
                    {
                        openSubject.AulaCode = dataReader.GetInt16(6);
                    }
                    else
                    {
                        openSubject.AulaCode = 0;
                    }
                    openSubject.Group = dataReader.GetByte(7);
                    openSubject.Quota = dataReader.GetByte(8);
                    openSubject.Cost = dataReader.GetDecimal(9);
                    openSubject.Period = dataReader.GetByte(10);
                    openSubject.Year = dataReader.GetInt16(11);
                    openSubject.CareerName = dataReader.GetString(12);
                    openSubject.Exists = true;
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return openSubject;//retorna objeto
        }
        //retorna materias disponibles a matricular
        public OpenSubject GetOpenSubject(int idMatAbierta)
        {
            OpenSubject openSubject = null;//objeto nulo para establecer valores
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//objeto que define conexion
            SqlCommand comando = new SqlCommand();//objeto comando que ejecuta sentencia sql
            SqlDataReader dataReader;//objeto que ejecuta comando sql
            //sentencia sql
            string sentencia = string.Format("SELECT OpenSubjectsCode,CareerMatterCode,NameM,Code,ProfesorCode," +
                "AulaCode, GroupO, Quota, Cost, PeriodO, YearO, Available, NombreCarrera FROM dbo.MATERIAS_MATABIERTAS_CARRERAS " +
                    "where OpenSubjectsCode = {0}", idMatAbierta);
            comando.Connection = conexion;//asigna conexion a comando
            comando.CommandText = sentencia;//asigna sentencia a comando
            try
            {
                conexion.Open();//abre conexion
                dataReader = comando.ExecuteReader();//ejecuta comando y guarda datos
                if (dataReader.HasRows)//comprueba si recibio datos
                {
                    openSubject = new OpenSubject();//objeto default
                    dataReader.Read();//lee los datos
                    //establece los datos
                    openSubject.OpenSubjectsCode = dataReader.GetInt32(0);
                    openSubject.CareerMatterCode = dataReader.GetInt32(1);
                    openSubject.Name = dataReader.GetString(2);
                    openSubject.Code = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4))
                    {
                        openSubject.ProfesorCode = dataReader.GetInt32(4);
                    }
                    else
                    {
                        openSubject.ProfesorCode = 0;
                    }
                    if (!dataReader.IsDBNull(5))
                    {
                        openSubject.AulaCode = dataReader.GetInt16(5);
                    }
                    else
                    {
                        openSubject.AulaCode = 0;
                    }
                    openSubject.Group = dataReader.GetByte(6);
                    openSubject.Quota = dataReader.GetByte(7);
                    openSubject.Cost = dataReader.GetDecimal(8);
                    openSubject.Period = dataReader.GetByte(9);
                    openSubject.Year = dataReader.GetInt16(10);
                    openSubject.Available = dataReader.GetBoolean(11);
                    openSubject.CareerName = dataReader.GetString(12);
                    openSubject.Exists = true;
                }
                conexion.Close();//cierra la conexion
            }
            catch (Exception)
            {
                throw;
            }
            return openSubject;//objeto retorno
        }

        public List<OpenSubject> ListarMatAbiertas(string condicion, string orden)
        {
            DataSet DS = new DataSet();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            List<OpenSubject> Lista = new List<OpenSubject>();
            string sentencia = "SELECT OpenSubjectsCode,CareerMatterCode,NameM,Code,ProfesorCode,"
                + "AulaCode,GroupO,Quota,Cost,PeriodO,YearO,Available,NombreCarrera " +
                "FROM dbo.MATERIAS_MATABIERTAS_CARRERAS";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = string.Format("{0} where {1}", sentencia, condicion);
            }

            sentencia = string.Format("{0} order by {1}", sentencia, orden);

            try
            {
                adapter = new SqlDataAdapter(sentencia, conexion);
                adapter.Fill(DS, "dbo.MATERIAS_MATABIERTAS_CARRERAS");
                //sentencia linq
                Lista = (from DataRow fila in DS.Tables[0].Rows                         
                         select new OpenSubject()
                         {                             
                             OpenSubjectsCode = (int)fila[0],
                             CareerMatterCode = (int)fila[1],
                             Name = fila[2].ToString(),
                             Code = fila[3].ToString(),
                             ProfesorCode = fila.IsNull(4) ? 0 : (int)fila[4],
                             AulaCode = (short)(fila.IsNull(5) ? 0 : (short)fila[5]),
                             Group = (byte)fila[6],
                             Quota = (byte)fila[7],
                             Cost = (decimal)fila[8],
                             Period = (byte)fila[9],
                             Year = (short)fila[10],
                             Available = (bool)fila[11],
                             CareerName = fila[12].ToString(),
                             Exists = true
                         }).ToList();
            }
             catch (Exception)
            {

                throw;
            }
            return Lista;
        }
        //asigna un profesor a materia abierta
        public int AsignarProfesor(int matterCode, int profCode)
        {
            int resultado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//objeto que define conexion sql
            SqlCommand comando = new SqlCommand();//comando que ejecuta la sentencia
            comando.Connection = conexion;//asigna conexion a comando
            comando.CommandText = "SP_AsignarProfesorMateria";//procedimiento a ejecutar
            comando.CommandType = CommandType.StoredProcedure;//indica que debe ejecutar un procedimiento
            //parametro de entrada
            comando.Parameters.AddWithValue("@ID_MATERIA_ABIERTA", matterCode);
            comando.Parameters.AddWithValue("@ID_PROFESOR ", profCode);
            comando.Parameters.AddWithValue("@DIA ", DBNull.Value);
            comando.Parameters.AddWithValue("@HORA_INICIO ", DBNull.Value);
            comando.Parameters.AddWithValue("@HORA_FIN ", DBNull.Value);

            //parametro de salida
            comando.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                conexion.Open();//abre conexion
                comando.ExecuteNonQuery();//ejecuta comando
                //leer el parametro de salida
                resultado = Convert.ToInt32(comando.Parameters["@retorno"].Value);
                _mensaje = comando.Parameters["@MENSAJE"].Value.ToString();
                conexion.Close();//cierra conexion
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;//retorno del procedimiento
        }
        //asigna aula a procedimiento
        public int AsignarAula(int matterCode, int aulaCode)
        {
            int resultado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//define conexion sql
            SqlCommand comando = new SqlCommand();//comando que ejecuta sentencia
            comando.Connection = conexion;//asigna conexion a comando
            comando.CommandText = "SP_AsignarAulaMat";//procedimiento a ejecutar
            comando.CommandType = CommandType.StoredProcedure;//indica que debe ejecutar un procedimiento
            //parametro de entrada
            comando.Parameters.AddWithValue("@ID_MATERIA_ABIERTA", matterCode);
            comando.Parameters.AddWithValue("@ID_AULA", aulaCode);
            comando.Parameters.AddWithValue("@DIA ", DBNull.Value);
            comando.Parameters.AddWithValue("@HORA_INICIO ", DBNull.Value);
            comando.Parameters.AddWithValue("@HORA_FIN ", DBNull.Value);
            //parametro de salida
            comando.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                conexion.Open();//abre conexion
                comando.ExecuteNonQuery();//ejecuta comando
                //leer el parametro de salida
                resultado = Convert.ToInt32(comando.Parameters["@retorno"].Value);
                _mensaje = comando.Parameters["@MENSAJE"].Value.ToString();
                conexion.Close();//cierra conexion
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;//retorno del procedimiento
        }
        //elimina materia abierta
        public int EliminarSP(int id)
        {
            int resultado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//define conexion sql
            SqlCommand comando = new SqlCommand();//comando que ejecuta sentencia
            comando.Connection = conexion;//asigna conexion a comando
            comando.CommandText = "SP_ELIMINAR_MAT_ABIERTA";//procedimiento a ejecutar
            comando.CommandType = CommandType.StoredProcedure;//indica que debe ejecutar un procedimiento
            //parametro de entrada
            comando.Parameters.AddWithValue("@ID_MAT_ABIERTA", id);
            //parametro de salida
            comando.Parameters.Add("@msj", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                conexion.Open();//abre conexion
                comando.ExecuteNonQuery();//ejecuta comando
                //leer el parametro de salida
                resultado = Convert.ToInt32(comando.Parameters["@retorno"].Value);
                _mensaje = comando.Parameters["@msj"].Value.ToString();
                conexion.Close();//cierra conexion
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;//retorno del procedimiento
        }
        //comprueba choques de horario con otras materias
        public int CompChoqHoraOtrasMat(int matAbierta, string carne)
        {
            int resultado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//define conexion sql
            SqlCommand comando = new SqlCommand();//comando que ejecuta la sentencia
            comando.Connection = conexion;//asigna conexion a comando
            comando.CommandText = "SP_Comp_Horario_Matriculas";//procedimiento a ejecutar
            comando.CommandType = CommandType.StoredProcedure;//indica que debe evaluar un procedimiento
            //parametro de entrada
            comando.Parameters.AddWithValue("@ID_MATERIA_ABIERTA", matAbierta);
            comando.Parameters.AddWithValue("@CARNE", carne);            
            //parametro de salida
            comando.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                conexion.Open();//abre conexion
                comando.ExecuteNonQuery();//ejecuta comando
                //leer el parametro de salida
                resultado = Convert.ToInt32(comando.Parameters["@retorno"].Value);
                _mensaje = comando.Parameters["@MENSAJE"].Value.ToString();
                conexion.Close();//cierra conexion
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;//retorno del procedimiento
        }
    }
}
