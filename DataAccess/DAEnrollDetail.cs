using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Entities;

namespace DataAccess
{
    public class DAEnrollDetail
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
        //default constructor
        public DAEnrollDetail()
        {
            _cadenaConexion = string.Empty;
            _mensaje = string.Empty;
        }
        //constructor con cadena de conexion
        public DAEnrollDetail(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        //métodos
        //lista detalles de matrícula
        public List<StudentEnrollDetail> ListarDetalles(string condicion = "")
        {
            DataSet DS = new DataSet();//objeto para cargar datos
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//objeto sql conexion
            SqlDataAdapter adapter;//objeto sql que realiza la consulta
            List<StudentEnrollDetail> Lista = new List<StudentEnrollDetail>();//lista de detalles de matricula
            //sentencia sql
            string sentencia = "SELECT OpenSubjectsCode,License, BillNumber, Cost, NOMBREMATERIA, Requisito, PeriodO, YearO, DateM, Discount" +
                " FROM VIEW_DETALLES_MATRICULA";
            if (!string.IsNullOrEmpty(condicion))
            {//concatena condicion si existe
                sentencia = string.Format("{0} where License = '{1}'", sentencia, condicion);
            }
            try
            {
                //ejecuta la conexion
                adapter = new SqlDataAdapter(sentencia, conexion);
                //carga los datos en el data set
                adapter.Fill(DS, "VIEW_DETALLES_MATRICULA");
                //sentencia linq
                Lista = (from DataRow fila in DS.Tables[0].Rows
                         select new StudentEnrollDetail()//objeto default
                         {
                             //asigna los valores
                            MatterCode = (int)fila[0],
                            Bill = (int)fila[2],
                            CostMatter = Convert.ToDecimal(fila[3]),
                            Matter = fila[4].ToString(),
                            Requirement = fila[5].ToString(),
                            Period = Convert.ToByte(fila[6]),
                            Year = (short)fila[7],
                            Date = Convert.ToDateTime(fila[8]),
                            Discount = Convert.ToDecimal(fila[9]),
            }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return Lista;//retorna la lista
        }
        //lista detalles de matriculas facturadas
        public List<StudentEnrollDetail> ListarDetallesF(string condicion = "")
        {
            DataSet DS = new DataSet();//objeto para obtener la información
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//objeto sql para crear la conexion mediante una cadena de conexion
            SqlDataAdapter adapter;//objeto adaptador para establecer la sentencia y conexion
            List<StudentEnrollDetail> Lista = new List<StudentEnrollDetail>();//lista de detalles de matricula
            //sentencia sql
            string sentencia = "SELECT OpenSubjectsCode,License, BillNumber, Cost, NOMBREMATERIA, Requisito, PeriodO, YearO, DateM, Discount" +
                " FROM VIEW_DETALLES_MATRICULADOS";
            if (!string.IsNullOrEmpty(condicion))
            {//concatena la condicion si existe
                sentencia = string.Format("{0} where License = '{1}'", sentencia, condicion);
            }
            try
            {//ejecuta la sentencia
                adapter = new SqlDataAdapter(sentencia, conexion);
                //carga los datos en el data set
                adapter.Fill(DS, "VIEW_DETALLES_MATRICULA");
                //sentencia linq
                Lista = (from DataRow fila in DS.Tables[0].Rows
                         select new StudentEnrollDetail()//objeto default
                         {
                             //asigna los valores
                             MatterCode = (int)fila[0],
                             Bill = (int)fila[2],
                             CostMatter = Convert.ToDecimal(fila[3]),
                             Matter = fila[4].ToString(),
                             Requirement = fila[5].ToString(),
                             Period = Convert.ToByte(fila[6]),
                             Year = (short)fila[7],
                             Date = Convert.ToDateTime(fila[8]),
                             Discount = Convert.ToDecimal(fila[9]),
                         }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return Lista;//retorno de lista
        }
        //Obtiene costos de matricula de un estudiante
        public StudentEnrollDetail GetDetail(string license)
        {
            StudentEnrollDetail studentEnrollDetail = null;//objeto null para cargar datos
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//objeto sql que define la conexion
            SqlCommand comando = new SqlCommand();//comando sql que ejecuta la sentencia
            SqlDataReader dataReader;//objeto que obtiene los datos de la consulta
            //sentencia sql
            string sentencia = string.Format("SELECT DESCUENTOMATERIA,SUM(COSTOMATERIA),Amount " +
                "FROM VIEW_CALCULO_COSTOS WHERE CarnetEstudiante = '{0}' GROUP BY Amount,DESCUENTOMATERIA", license);
            comando.Connection = conexion;//define la conexion del comando sql
            comando.CommandText = sentencia;//define la sentencia para el comando sql
            try
            {
                conexion.Open();//abre la conexion
                dataReader = comando.ExecuteReader();//ejecuta el comando
                if (dataReader.HasRows)//comprueba los datos devueltos por la sentencia
                {
                    studentEnrollDetail = new StudentEnrollDetail();//objeto default
                    //lee los datos
                    dataReader.Read();
                    //asigna los valores
                    studentEnrollDetail.Discount = dataReader.GetDecimal(0);
                    studentEnrollDetail.CostMatter = dataReader.GetDecimal(1);
                    studentEnrollDetail.CostEnroll = dataReader.GetDecimal(2);
                }
                conexion.Close();//cierra la conexion
            }
            catch (Exception)
            {
                throw;
            }
            return studentEnrollDetail;//objeto retorno
        }
        //obtiene costos ya facturados
        public StudentEnrollDetail GetDetailF(string license)
        {
            StudentEnrollDetail studentEnrollDetail = null;//objeto nulo para cargar datos
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//objeto sql que defina la conexion
            SqlCommand comando = new SqlCommand();//objeto sql que define la sentencia a ajecutar
            SqlDataReader dataReader;//objeto sql que lee la información devuelta por la consulta
            //sentencia sql
            string sentencia = string.Format("SELECT DESCUENTOMATERIA,SUM(COSTOMATERIA),Amount " +
                "FROM VIEW_CALCULO_COSTOS_FAC WHERE CarnetEstudiante = '{0}' GROUP BY Amount,DESCUENTOMATERIA", license);
            comando.Connection = conexion;//asigna la conexion del comando
            comando.CommandText = sentencia;//asigna la sentencia del comando
            try
            {
                conexion.Open();//abre la conexion
                dataReader = comando.ExecuteReader();//ejecuta la sentencia sql
                if (dataReader.HasRows)//comprueba si existen datos
                {
                    studentEnrollDetail = new StudentEnrollDetail();//objeto default
                    dataReader.Read();//lee la información del sql data reader
                    //asigna los datos
                    studentEnrollDetail.Discount = dataReader.GetDecimal(0);
                    studentEnrollDetail.CostMatter = dataReader.GetDecimal(1);
                    studentEnrollDetail.CostEnroll = dataReader.GetDecimal(2);
                }
                conexion.Close();//cierra la conexion
            }
            catch (Exception)
            {
                throw;
            }
            return studentEnrollDetail;//objeto retorno
        }

        //modifica estado de un detalle de matricula
        public int Modificar(EnrollmentDetails details)
        {
            int resultado = -1;//retorno por defecto
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//objeto que define la conexion sql
            SqlCommand comando = new SqlCommand();//objeto sql que define el comando a ejecutar
            comando.Connection = conexion;//establece el comando de conexion
            comando.CommandText = "SP_AsignarNota";//procedimiento a ejecutar
            comando.CommandType = CommandType.StoredProcedure;//indica que debe ejecutar un procedimiento
            //parametro de entrada
            comando.Parameters.AddWithValue("@NumFactura", details.BillNumber);
            comando.Parameters.AddWithValue("@CodMateriaAbierta", details.OpenMatCode);
            comando.Parameters.AddWithValue("@NotaFinal", details.FinalNote);
            
            //parametro de salida
            comando.Parameters.Add("@msj", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                conexion.Open();//abre la conexion
                comando.ExecuteNonQuery();//ejecuta el comando
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
        //
        //elimina una materia matriculada
        public int Eliminar(EnrollmentDetails details)
        {
            int resultado = -1;//retorno por defecto
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//objeto sql que define la conexion
            SqlCommand comando = new SqlCommand();//comando sql que ejecuta la sentencia
            comando.Connection = conexion;//asigna la conexion al comando
            comando.CommandText = "SP_ELIMINAR_DET_MATRICULA";//procedimiento a ejecutar
            comando.CommandType = CommandType.StoredProcedure;//indica que debe ejecutar un procedimiento almacenado
            //parametro de entrada
            comando.Parameters.AddWithValue("@FAC", details.BillNumber);
            comando.Parameters.AddWithValue("@COD_MAT", details.OpenMatCode);
            //parametro de salida
            comando.Parameters.Add("@MSJ", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                conexion.Open();//abre la conexion
                comando.ExecuteNonQuery();//ejecuta el comando
                //leer el parametro de salida
                resultado = Convert.ToInt32(comando.Parameters["@retorno"].Value);
                _mensaje = comando.Parameters["@MSJ"].Value.ToString();
                conexion.Close();//cierra la conexion
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;//retorno del procedimiento almacenado
        }
        //lista detalles con data set para no crear entidad
        public DataSet ListarDetallesM(string Condicion)
        {
            DataSet dataSet = new DataSet();//objeto data set para retornar datos
            SqlConnection Conexion = new SqlConnection(_cadenaConexion);//objeto sql que define la conexion
            SqlDataAdapter DataAdapter;//adaptador sql que ejecuta la sentencia
            string sentencia = string.Empty;//sentencia sql

            try
            {
                //sentencia sql
                sentencia = "SELECT BillNumber,License,NOMBRE,FinalNote,DetailStatus,OpenMatCode from dbo.VIEW_CIERRE_CURSO";
                if (!string.IsNullOrEmpty(Condicion))
                {   //concatena condicion a sentencia si existe
                    sentencia = string.Format("{0} WHERE {1}", sentencia, Condicion);
                }
                //asigna valores de consulta a sqlDataAdapter
                DataAdapter = new SqlDataAdapter(sentencia, Conexion);
                DataAdapter.Fill(dataSet, "Detalles");//carga los datos en el data set
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Conexion.Dispose();//limpia datos de conexion
            }
            return dataSet;//retorna objeto data set 
        }

    }
}
