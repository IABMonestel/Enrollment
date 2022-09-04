using DataAccess;
using Entities;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class OpenMatterLogic
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
        public OpenMatterLogic(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Methods
        public int Insertar(OpenSubject openSubject, Schedule schedule)
        {
            int resultado;
            DAOpenSubjects AD = new DAOpenSubjects(_cadenaConexion);
            try
            {
                resultado = AD.Insertar(openSubject, schedule);
                _mensaje = AD.Mensaje;
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }
        //Materias disponibles a matricular
        public List<OpenSubject> ListarMateriasMatricular(string condicion)
        {
            List<OpenSubject> Lista;
            DAOpenSubjects AccesoDatos = new DAOpenSubjects(_cadenaConexion);
            try
            {
                Lista = AccesoDatos.ListarMateriasMatricular(condicion);
            }
            catch (Exception)
            {

                throw;
            }
            return Lista;
        }
        //Lista de materias abiertas
        public List<OpenSubject> ListarMatAbiertas(string condicion, string orden)
        {
            List<OpenSubject> Lista;
            DAOpenSubjects AccesoDatos = new DAOpenSubjects(_cadenaConexion);
            try
            {
                Lista = AccesoDatos.ListarMatAbiertas(condicion, orden);
            }
            catch (Exception)
            {

                throw;
            }
            return Lista;
        }
        //Asignar profesor a materia abierta
        public int AsignarProfesor(int matterCode, int profCode)
        {
            int resultado;
            DAOpenSubjects AD = new DAOpenSubjects(_cadenaConexion);
            try
            {
                resultado = AD.AsignarProfesor(matterCode, profCode);
                _mensaje = AD.Mensaje;
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }
        //Asignar aula a materia abierta
        public int AsignarAula(int matterCode, int aulaCode)
        {
            int resultado;
            DAOpenSubjects AD = new DAOpenSubjects(_cadenaConexion);
            try
            {
                resultado = AD.AsignarAula(matterCode, aulaCode);
                _mensaje = AD.Mensaje;
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }
        //Obtener materia abierta por id de materia
        public OpenSubject GetOpenSubject(int idMatAbierta)
        {
            OpenSubject openSubject;
            DAOpenSubjects accesoDatos = new DAOpenSubjects(_cadenaConexion);
            try
            {
                openSubject = accesoDatos.GetOpenSubject(idMatAbierta);
            }
            catch (Exception)
            {
                throw;
            }
            return openSubject;
        }
        //Obtener materia abierta 
        public OpenSubject GetOpenSubjectD(int idMatAbierta)
        {
            OpenSubject openSubject;
            DAOpenSubjects accesoDatos = new DAOpenSubjects(_cadenaConexion);
            try
            {
                openSubject = accesoDatos.GetOpenSubjectD(idMatAbierta);
            }
            catch (Exception)
            {
                throw;
            }
            return openSubject;
        }
        //Eliminar materia abierta con SP
        public int EliminarSP(int id)
        {
            int resultado;
            DAOpenSubjects AD = new DAOpenSubjects(_cadenaConexion);
            try
            {
                resultado = AD.EliminarSP(id);
                _mensaje = AD.Mensaje;
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }
        //Comprobar choques de horario de materias 
        public int CompChoqHoraOtrasMat(int id,string carne)
        {
            int resultado;
            DAOpenSubjects AD = new DAOpenSubjects(_cadenaConexion);
            try
            {
                resultado = AD.CompChoqHoraOtrasMat(id,carne);
                _mensaje = AD.Mensaje;
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }
        //Desasigna un profesor
        public int DesasignarProfe(int v)
        {
            int result = -1;
            DAOpenSubjects dAccess = new DAOpenSubjects(_cadenaConexion);
            try
            {
                result = dAccess.DesasignarProfe(v);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        //Desasigna un Aula
        public int DesasignarAula(int v)
        {
            int result = -1;
            DAOpenSubjects dAccess = new DAOpenSubjects(_cadenaConexion);
            try
            {
                result = dAccess.DesasignarAula(v);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
