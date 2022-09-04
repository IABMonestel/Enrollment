using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class CareersLogic
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
        public CareersLogic(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //methods
        //Método para obtener lista de carreras
        public List<Careers> ListarCareers(string condicion)
        {
            List<Careers> Lista;
            DACareers AccesoDatos = new DACareers(_cadenaConexion);
            try
            {
                Lista = AccesoDatos.ListarCareers(condicion);
            }
            catch (Exception)
            {

                throw;
            }
            return Lista;
        }
        //Método para obtener una carrera
        public Careers GetCareer(int idCarrera)
        {
            Careers career;
            DACareers accesoDatos = new DACareers(_cadenaConexion);
            try
            {
                career = accesoDatos.GetCareer(idCarrera);
            }
            catch (Exception)
            {
                throw;
            }
            return career;
        }        
        //Método para eliminar una carrera
        public int Delete(Careers career)
        {
            int resultado;
            DACareers AD = new DACareers(_cadenaConexion);
            try
            {
                resultado = AD.Delete(career);
                _mensaje = AD.Mensaje;
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }
        //Método para insertar una carrera
        public int Insertar(Careers career)
        {
            int id_career = 0;
            DACareers AccesoDatos = new DACareers(_cadenaConexion);
            try
            {
                id_career = AccesoDatos.Insertar(career);
            }
            catch (Exception)
            {

                throw;
            }
            return id_career;
        }
    }
}
