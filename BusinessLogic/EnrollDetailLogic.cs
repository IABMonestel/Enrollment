using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BusinessLogic
{
    public class EnrollDetailLogic
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
        public EnrollDetailLogic(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Método para obtener una lista de detalles de matrícula
        public List<StudentEnrollDetail> ListarDetalles(string condicion = "")
        {
            List<StudentEnrollDetail> Lista;
            DAEnrollDetail AccesoDatos = new DAEnrollDetail(_cadenaConexion);
            try
            {
                Lista = AccesoDatos.ListarDetalles(condicion);
            }
            catch (Exception)
            {

                throw;
            }
            return Lista;
        }
        //Lista para obtener detalles de matrículas facturadas
        public List<StudentEnrollDetail> ListarDetallesF(string condicion = "")
        {
            List<StudentEnrollDetail> Lista;
            DAEnrollDetail AccesoDatos = new DAEnrollDetail(_cadenaConexion);
            try
            {
                Lista = AccesoDatos.ListarDetallesF(condicion);
            }
            catch (Exception)
            {

                throw;
            }
            return Lista;
        }
        //Método para obtener un detalle de matrícula
        public StudentEnrollDetail GetDetail(string license)
        {
            StudentEnrollDetail studentEnrollDetail = null;
            DAEnrollDetail AccesoDatos = new DAEnrollDetail(_cadenaConexion);
            try
            {
                studentEnrollDetail = AccesoDatos.GetDetail(license);
            }
            catch (Exception)
            {

                throw;
            }
            return studentEnrollDetail;
        }
        //Método para obtener un detalle facturado
        public StudentEnrollDetail GetDetailF(string license)
        {
            StudentEnrollDetail studentEnrollDetail = null;
            DAEnrollDetail AccesoDatos = new DAEnrollDetail(_cadenaConexion);
            try
            {
                studentEnrollDetail = AccesoDatos.GetDetailF(license);
            }
            catch (Exception)
            {

                throw;
            }
            return studentEnrollDetail;
        }
        //Método para modificar un estado de detalle
        public int Modificar(EnrollmentDetails enrollment)
        {
            int filasAfectadas = 0;
            DAEnrollDetail AccesoDatos = new DAEnrollDetail(_cadenaConexion);
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
        //Método que elimina una materia matriculada
        public int Eliminar(EnrollmentDetails details)
        {
            int resultado;
            DAEnrollDetail AD = new DAEnrollDetail(_cadenaConexion);
            try
            {
                resultado = AD.Eliminar(details);
                _mensaje = AD.Mensaje;
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }
        //Muestra los detalles de matricula facturados
        //con un data set para no crear entidad
        public DataSet ListarDetallesM(string Condicion)
        {
            DataSet DS;
            DAEnrollDetail AD = new DAEnrollDetail(_cadenaConexion);
            try
            {
                DS = AD.ListarDetallesM(Condicion);
            }
            catch (Exception)
            {

                throw;
            }
            return DS;
        }
    }
}
