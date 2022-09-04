using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;

namespace BusinessLogic
{
    public class LogicaAula
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
        public LogicaAula(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        //Methods
        //Obtiene la lista de aulas 
        public List<Aula> ListarAulas(string condicion = "", string orden= "")
        {
            List<Aula> Lista;
            DAAula AccesoDatos = new DAAula(_cadenaConexion);
            try
            {
                Lista = AccesoDatos.ListarAulas(condicion, orden);
            }
            catch (Exception)
            {

                throw;
            }
            return Lista;
        }
        //Obtiene información de un aula por id
        public Aula ObtenerAula(byte id)
        {
            Aula aula;
            DAAula accesoDatos = new DAAula(_cadenaConexion);
            try
            {
                aula = accesoDatos.ObtenerAula(id);
            }
            catch (Exception)
            {
                throw;
            }
            return aula;
        }
        //Inserta un aula
        public int Insertar(Aula aula)
        {
            int id_aula = 0;
            DAAula AccesoDatos = new DAAula(_cadenaConexion);
            try
            {
                id_aula = AccesoDatos.Insertar(aula);
            }
            catch (Exception)
            {

                throw;
            }
            return id_aula;
        }
        //Borrado lógico de un aula
        public int Delete(int aula)
        {
            int resultado;
            DAAula AD = new DAAula(_cadenaConexion);
            try
            {
                resultado = AD.Delete(aula);
                _mensaje = AD.Mensaje;
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }
    }
}
