using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess
{
    public class DAReferenceValues
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
        public DAReferenceValues()
        {
            _cadenaConexion = string.Empty;
            _mensaje = string.Empty;
        }

        public DAReferenceValues(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        //métodos
        public ReferenceValues GetReferenceValues()
        {
            ReferenceValues referenceValues = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;
            string sentencia = string.Format("SELECT TOP 1(SELECT VALOR FROM TBL_ReferenceValues WHERE DATO = 'ActiveEnroll') AS MatriAct," +
                "(SELECT VALOR FROM TBL_ReferenceValues WHERE DATO = 'Year') AS Anio," +
                    "(SELECT VALOR FROM TBL_ReferenceValues WHERE DATO = 'Period') AS PERIODO," +
                    "(SELECT VALOR FROM TBL_ReferenceValues WHERE DATO = 'Tax') AS IVA, " +
                    "(SELECT VALOR FROM TBL_ReferenceValues WHERE DATO = 'CostEnroll') AS MONTO_MATRICULA FROM TBL_ReferenceValues");
            comando.Connection = conexion;
            comando.CommandText = sentencia;
            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    referenceValues = new ReferenceValues();
                    dataReader.Read();
                    referenceValues.ActiveEnroll = dataReader.GetDecimal(0);
                    referenceValues.Year = dataReader.GetDecimal(1);
                    referenceValues.Period = dataReader.GetDecimal(2);
                    referenceValues.Tax = dataReader.GetDecimal(3);
                    referenceValues.CostEnroll = dataReader.GetDecimal(4);
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return referenceValues;
        }
        //set reference values
        public int SetReferenceValues(ReferenceValues values)
        {
            int resultado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = "SET_REFERENCE_VALUES";
            comando.CommandType = CommandType.StoredProcedure;
            //parametro de entrada
            comando.Parameters.AddWithValue("@MATRI", values.ActiveEnroll);
            comando.Parameters.AddWithValue("@ANIO", values.Year);
            comando.Parameters.AddWithValue("@PERIOD", values.Period);
            comando.Parameters.AddWithValue("@TAX", values.Tax);
            comando.Parameters.AddWithValue("@MONTO_MATRICULA", values.CostEnroll);
            //parametro de salida
            comando.Parameters.Add("@MSJ", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                //leer el parametro de salida
                resultado = Convert.ToInt32(comando.Parameters["@retorno"].Value);
                _mensaje = comando.Parameters["@MSJ"].Value.ToString();
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }
    }
}
