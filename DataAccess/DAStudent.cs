using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace DataAccess
{
    public class DAStudent
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
        public DAStudent()
        {
            _cadenaConexion = string.Empty;
            _mensaje = string.Empty;
        }

        public DAStudent(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        //métodos

        public List<Student> ListarStudent(string condicion = "", string orden = "")
        {
            DataSet DS = new DataSet();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            List<Student> Lista = new List<Student>();
            string sentencia = "SELECT License, Id, NameS, FLastName, SLastName, Phone, Email, Province, Canton, District," +
            "OthersSigns, AdmissionDate, Discount, StateS, Erased FROM TBL_Students";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = string.Format("{0} where {1}", sentencia, condicion);
            }

            if (!string.IsNullOrEmpty(orden))
            {//si orden no esta vacia entonces concatene ese orden a la sentencia
                sentencia = string.Format("{0} order by {1}", sentencia, orden);
            }

            try
            {
                adapter = new SqlDataAdapter(sentencia, conexion);
                adapter.Fill(DS, "TBL_Estudiantes");
                //sentencia linq
                Lista = (from DataRow fila in DS.Tables[0].Rows
                         select new Student()
                         {
                             License = fila[0].ToString(),
                             Id = fila[1].ToString(),
                             Name = fila[2].ToString(),
                             FLastName = fila[3].ToString(),
                             SLastName = fila[4].ToString(),
                             Phone = fila[5].ToString(),
                             Email = fila[6].ToString(),
                             Province = fila[7].ToString(),
                             Canton = fila[8].ToString(),
                             District = fila[9].ToString(),
                             OthersSigns = fila[10].ToString(),
                             AdmissionDate = DateTime.Parse(fila[11].ToString()),
                             Discount = (byte)fila[12],
                             State = fila[13].ToString(),
                             Erased = (bool)fila[14],
                             Exists = true
                         }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return Lista;
        }

        public Student GetStudent(string licenseStudent)
        {
            Student student = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;
            string sentencia = string.Format("SELECT License, Id, NameS, FLastName, SLastName, Phone, Email, Province, Canton, District,"+
            "OthersSigns, AdmissionDate, Discount, StateS, Erased FROM TBL_Students where License = '{0}'", licenseStudent);
            comando.Connection = conexion;
            comando.CommandText = sentencia;
            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    student = new Student();
                    dataReader.Read();
                    student.License = dataReader.GetString(0);
                    student.Id = dataReader.GetString(1);
                    student.Name = dataReader.GetString(2);
                    student.FLastName = dataReader.GetString(3);
                    student.SLastName = dataReader.GetString(4);
                    student.Phone = dataReader.GetString(5);
                    student.Email = dataReader.GetString(6);
                    student.Province = dataReader.GetString(7);
                    student.Canton = dataReader.GetString(8);
                    student.District = dataReader.GetString(9);
                    student.OthersSigns = dataReader.GetString(10);
                    student.AdmissionDate = dataReader.GetDateTime(11);
                    student.Discount = dataReader.GetByte(12);
                    student.State = dataReader.GetString(13);
                    student.Erased = dataReader.GetBoolean(14);
                    student.Exists = true;                    
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return student;
        }
    }
}
