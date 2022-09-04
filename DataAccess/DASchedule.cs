using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace DataAccess
{
    public class DASchedule
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
        public DASchedule()
        {
            _cadenaConexion = string.Empty;
            _mensaje = string.Empty;
        }

        public DASchedule(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        //métodos
        public int UpdateSP(Schedule newSchedule)
        {
            int resultado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = "SP_AgregarModificarHorarioMateriaAbierta";
            comando.CommandType = CommandType.StoredProcedure;
            //parametro de entrada            
            comando.Parameters.AddWithValue("@ID_MATERIA_ABIERTA", newSchedule.OpenSubjectCode);                        
            comando.Parameters.AddWithValue("@DIA", newSchedule.Dia);
            comando.Parameters.AddWithValue("@HORA_INICIO", DateTime.Parse(newSchedule.StartTime));
            comando.Parameters.AddWithValue("@HORA_FIN", DateTime.Parse(newSchedule.EndTime));
            //parametro de salida
            comando.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                //leer el parametro de salida
                resultado = Convert.ToInt32(comando.Parameters["@retorno"].Value);
                _mensaje = comando.Parameters["@MENSAJE"].Value.ToString();
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }

        public int Delete(Schedule schedule)
        {
            int resultado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = "SP_Eliminar_Horario";
            comando.CommandType = CommandType.StoredProcedure;
            //parametro de entrada
            comando.Parameters.AddWithValue("@COD_MAT_ABIERTA", schedule.OpenSubjectCode);
            comando.Parameters.AddWithValue("@ID", schedule.Id);
            //comando.Parameters.AddWithValue("@HORA_INICIO", DateTime.Parse(schedule.StartTime));
            //comando.Parameters.AddWithValue("@HORA_FIN", DateTime.Parse(schedule.EndTime));
            //parametro de salida
            comando.Parameters.Add("@msj", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                //leer el parametro de salida
               resultado = Convert.ToInt32(comando.Parameters["@retorno"].Value);
                //_mensaje = comando.Parameters["@msj"].Value.ToString();
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }

        public List<Schedule> ListarScheduler(int condicion)
        {
            DataSet DS = new DataSet();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            List<Schedule> Lista = new List<Schedule>();
            string sentencia = "SELECT ID,OpenSubjectCode,Dia,StartTime,EndTime FROM TBL_Schedule";
            //if (!string.IsNullOrEmpty(condicion))
            //{
                sentencia = string.Format("{0} where OpenSubjectCode = {1}", sentencia, condicion);
            //}
            try
            {
                adapter = new SqlDataAdapter(sentencia, conexion);
                adapter.Fill(DS, "TBL_Horarios");
                //sentencia linq
                Lista = (from DataRow fila in DS.Tables[0].Rows
                         select new Schedule()
                         {               
                             Id = (int)fila[0],
                             OpenSubjectCode = (int)fila[1],
                             Dia = Convert.ToChar(fila[2]),
                             StartTime = fila[3].ToString(),
                             EndTime = fila[4].ToString()
                         }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }
    }
}
