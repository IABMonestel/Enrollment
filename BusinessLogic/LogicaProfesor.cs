using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class LogicaProfesor
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
        public LogicaProfesor(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        //Obtiene la lista de profesores
        public List<Profesor> ListarProfesores(string condicion, string orden)
        {
            List<Profesor> Lista;
            DAProfesor AccesoDatos = new DAProfesor(_cadenaConexion);
            try
            {
                Lista = AccesoDatos.ListarProfesor(condicion, orden);
            }
            catch (Exception)
            {

                throw;
            }
            return Lista;
        }
        //Obtiene un profesor por id
        public Profesor ObtenerProfesor(int id)
        {
            Profesor profesor;
            DAProfesor accesoDatos = new DAProfesor(_cadenaConexion);
            try
            {
                profesor = accesoDatos.ObtenerProfesor(id);
            }
            catch (Exception)
            {
                throw;
            }
            return profesor;
        }
    }
}
