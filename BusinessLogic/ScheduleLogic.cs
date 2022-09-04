using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class ScheduleLogic
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
        public ScheduleLogic(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        //actualiza horario de materia abierta
        public int UpdateSP(Schedule newSchedule)
        {
            int result = 0;
            DASchedule AccesoDatos = new DASchedule(_cadenaConexion);
            try
            {
                result = AccesoDatos.UpdateSP(newSchedule);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        //Muestra horarios de una materia a bierta
        public List<Schedule> ListarScheduler(int condicion)
        {
            List<Schedule> Lista;
            DASchedule AccesoDatos = new DASchedule(_cadenaConexion);
            try
            {
                    Lista = AccesoDatos.ListarScheduler(condicion);
            }
            catch (Exception)
            {

                throw;
            }
            return Lista;            
        }
        //Elimina un horario
        public int Delete(Schedule schedule)
        {
            int resultado = -1;
            DASchedule AccesoDatos = new DASchedule(_cadenaConexion);
            try
            {
                resultado=AccesoDatos.Delete(schedule);
            }
            catch (Exception)
            {

                throw;
            }
            return resultado;
        }
    }
}
