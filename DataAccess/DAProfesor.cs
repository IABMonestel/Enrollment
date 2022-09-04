using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace DataAccess
{
    public class DAProfesor
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
        public DAProfesor()
        {
            _cadenaConexion = string.Empty;
            _mensaje = string.Empty;
        }

        public DAProfesor(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        public List<Profesor> ListarProfesor(string condicion = "", string orden = "")
        {
            DataSet DS = new DataSet();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            List<Profesor> Lista = new List<Profesor>();
            string sentencia = "SELECT Code,Id,NameP,FLastName,SLastName,Phone,"+
                "Email,Erased FROM TBL_Profesors";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = string.Format("{0} where {1}", sentencia, condicion);
            }

            sentencia = string.Format("{0} order by {1}", sentencia, orden);

            try
            {
                adapter = new SqlDataAdapter(sentencia, conexion);
                adapter.Fill(DS, "TBL_Profesores");
                //sentencia linq
                Lista = (from DataRow fila in DS.Tables[0].Rows
                         select new Profesor()
                         {                             
                             Codigo = (int)fila[0],
                             Id = fila[1].ToString(),
                             Name = fila[2].ToString(),
                             FLastName = fila[3].ToString(),
                             SLastName = fila[4].ToString(),
                             Phone = fila[5].ToString(),
                             Email = fila[6].ToString(),
                             Erased = (bool)fila[7],
                             Exists = true
                         }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return Lista;
        }

        public Profesor ObtenerProfesor(int id)
        {
            Profesor profesor = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;
            string sentencia = string.Format("SELECT Code,Id,NameP,FLastName,SLastName,Phone,Email,Erased FROM TBL_Profesors where Code ={0}", id);
            comando.Connection = conexion;
            comando.CommandText = sentencia;
            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    profesor = new Profesor();
                    dataReader.Read();
                    profesor.Codigo = dataReader.GetInt32(0);
                    profesor.Id = dataReader.GetString(1);
                    profesor.Name = dataReader.GetString(2);
                    profesor.FLastName = dataReader.GetString(3);
                    profesor.SLastName = dataReader.GetString(4);
                    profesor.Phone = dataReader.GetString(5);
                    profesor.Email = dataReader.GetString(6);
                    profesor.Erased = dataReader.GetBoolean(7);
                    profesor.Exists = true;
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return profesor;
        }
    }
}
