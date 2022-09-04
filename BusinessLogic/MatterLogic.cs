using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class MatterLogic
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
        public MatterLogic(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        //methods
        //Lista de materias
        public List<Matter> ListarMaterias(string condicion = "", string orden = "")
        {
            List<Matter> Lista;
            DAMatter AccesoDatos = new DAMatter(_cadenaConexion);
            try
            {
                Lista = AccesoDatos.ListarMaterias(condicion,orden);
            }
            catch (Exception)
            {

                throw;
            }
            return Lista;
        }
        //Obtiene una materia
        public Matter GetMatter(string code)
        {
            Matter matter;
            DAMatter accesoDatos = new DAMatter(_cadenaConexion);
            try
            {
                matter = accesoDatos.GetMatter(code);
            }
            catch (Exception)
            {
                throw;
            }
            return matter;
        }

        //Eliminar materia
        public int DeleteMatter(string code)
        {
            int result;
            DAMatter accesoDatos = new DAMatter(_cadenaConexion);
            try
            {
                result = accesoDatos.DeleteMatter(code);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        //Crear actualizar materia
        public int UpdateMatter(Matter matter)
        {
            int result;
            DAMatter accesoDatos = new DAMatter(_cadenaConexion);
            try
            {
                result = accesoDatos.UpdateMatter(matter);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
