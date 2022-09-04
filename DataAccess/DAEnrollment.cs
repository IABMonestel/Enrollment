using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess
{
    public class DAEnrollment
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
        public DAEnrollment()
        {
            _cadenaConexion = string.Empty;
            _mensaje = string.Empty;
        }
        //constructor con cadena de conexion
        public DAEnrollment(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        //métodos
        //crea una matricula con al menos un horario
        public int Matricular(string carne, int cod_mat)
        {
            int resultado = -1;//retorno por defecto
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//objeto sql que define la conexion
            SqlCommand comando = new SqlCommand();//comando sql que ejecuta la sentencia
            comando.Connection = conexion;//asigna la conexion al comando
            comando.CommandText = "SP_MATRICULAR";//procedimiento a ejecutar
            comando.CommandType = CommandType.StoredProcedure;//indica que debe ejecutar un procedimiento almacenado 
            //parametro de entrada
            comando.Parameters.AddWithValue("@CARNE", carne);
            comando.Parameters.AddWithValue("@COD_MAT_ABI", cod_mat);
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
        //modifica estado de factura cancelado
        public int Modificar(Enrollment enrollment)
        {
            int filasAfectadas = -1;//valor de retorno por defecto
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//objeto sql que establece la conexion
            SqlCommand comando = new SqlCommand();//comando sql que define la sentencia
            //sentencia sql
            string sentencia = "UPDATE TBL_Enrollments SET StateFac = 'CAN', TypePayment = @TYPE, PurchasePayment=@PURCHASEPAYMENT WHERE NumFact = @FACT " +
                "AND Meat = @CARNE";
            comando.CommandText = sentencia;//asigna sentencia a comando
            comando.Connection = conexion;//asigna conexion a
            //Parametros por defecto
            comando.Parameters.AddWithValue("@TYPE", enrollment.TypePayment);
            comando.Parameters.AddWithValue("@FACT", enrollment.NumFact);
            comando.Parameters.AddWithValue("@PURCHASEPAYMENT", enrollment.PurchasePayment);
            comando.Parameters.AddWithValue("@CARNE", enrollment.Meat);
            try
            {
                conexion.Open();//abre la conexion
                filasAfectadas = comando.ExecuteNonQuery();//ejecuta la sentencia
                conexion.Close();//cierra la conexion
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Dispose();//limpia datos temporales
                comando.Dispose();
            }
            return filasAfectadas;//retorna filas a fectadas
        }
        //obtiene una factura para consultar tipo de pago y comprobante
        public Enrollment Obtener(int num)
        {
            Enrollment enrollment = null;//objeto null para cargar datos
            SqlConnection conexion = new SqlConnection(_cadenaConexion);//objeto sql que define la conexion
            SqlCommand comando = new SqlCommand();//comando sql que ejecuta la sentencia
            SqlDataReader dataReader;//objeto que obtiene los datos de la consulta
            //sentencia sql
            string sentencia = string.Format("SELECT TypePayment, PurchasePayment from TBL_Enrollments where NumFact = {0}", num);
            comando.Connection = conexion;//define la conexion del comando sql
            comando.CommandText = sentencia;//define la sentencia para el comando sql
            try
            {
                conexion.Open();//abre la conexion
                dataReader = comando.ExecuteReader();//ejecuta el comando
                if (dataReader.HasRows)//comprueba los datos devueltos por la sentencia
                {
                    enrollment = new Enrollment();//objeto default
                    //lee los datos
                    dataReader.Read();
                    //asigna los valores
                    enrollment.TypePayment = dataReader.GetString(0);
                    enrollment.PurchasePayment = dataReader.GetString(1);
                }
                conexion.Close();//cierra la conexion
            }
            catch (Exception)
            {
                throw;
            }
            return enrollment;//objeto retorno
        }
    }
}
