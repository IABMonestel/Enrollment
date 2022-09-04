using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class StudentLogic
    {
        //atributos
        private string _cadenaConexion;
        private string _mensaje;

        //propiedad
        public string Mensaje
        {
            get => _mensaje;
        }
        //constructor
        public StudentLogic(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        //** methods **//
        //Obtiene la lista de estudiantes
        public List<Student> ListarStudent(string condicion = "", string orden = "")
        {
            List<Student> Lista;
            DAStudent AccesoDatos = new DAStudent(_cadenaConexion);
            try
            {
                Lista = AccesoDatos.ListarStudent(condicion, orden);
            }
            catch (Exception)
            {

                throw;
            }
            return Lista;
        }
        //Obtiene el estudiante por carné
        public Student GetStudent(string licenseStudent)
        {
            Student student;
            DAStudent accesoDatos = new DAStudent(_cadenaConexion);
            try
            {
                student = accesoDatos.GetStudent(licenseStudent);
            }
            catch (Exception)
            {
                throw;
            }
            return student;
        }
    }
}
