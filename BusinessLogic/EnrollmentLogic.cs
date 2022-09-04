using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class EnrollmentLogic
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
        public EnrollmentLogic(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        //Para almacenar matriculas, con carné y codido de materia
        public int Matricular(string carne, int cod_mat)
        {
            int resultado;
            DAEnrollment AD = new DAEnrollment(_cadenaConexion);
            try
            {
                resultado = AD.Matricular(carne, cod_mat);
                _mensaje = AD.Mensaje;
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }
        //Modifica estado de factura
        public int Modificar(Enrollment enrollment)
        {
            int filasAfectadas = 0;
            DAEnrollment  AccesoDatos = new DAEnrollment(_cadenaConexion);
            try
            {
                filasAfectadas = AccesoDatos.Modificar(enrollment);
            }
            catch (Exception)
            {

                throw;
            }
            return filasAfectadas;
        }

        //
        //Método para obtener un detalle de matrícula
        public Enrollment Obtener(int num)
        {
            Enrollment enrollment = null;
            DAEnrollment AccesoDatos = new DAEnrollment(_cadenaConexion);
            try
            {
                enrollment = AccesoDatos.Obtener(num);
            }
            catch (Exception)
            {
                throw;
            }
            return enrollment;
        }
    }
}
