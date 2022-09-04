using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class CareerMatterLogic
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
        public CareerMatterLogic(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Methods
        //Método para insertar materia carrera
        public int Insertar(CareerMatter career)
        {
            int id_career = 0;
            DACareerMatter AccesoDatos = new DACareerMatter(_cadenaConexion);
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
        //Método para mostrar materias carreras
        public List<CareerMatter> ListarMateriasCarrera(string condicion = "", string orden = "")//
        {
            List<CareerMatter> Lista;
            DACareerMatter AccesoDatos = new DACareerMatter(_cadenaConexion);
            try
            {
                Lista = AccesoDatos.ListarMateriasCarrera(condicion, orden) ;//
            }
            catch (Exception)
            {

                throw;
            }
            return Lista;
        }
        //Método para obtener materia carrera por Id
        public CareerMatter ObtenerMateriaCarrera(int id)
        {
            CareerMatter careerMatter = null;
            DACareerMatter accesoDatos = new DACareerMatter(_cadenaConexion);
            try
            {
                careerMatter = accesoDatos.ObtenerMateriaCarrera(id);
            }
            catch (Exception)
            {
                throw;
            }
            return careerMatter;
        }
    }
}
