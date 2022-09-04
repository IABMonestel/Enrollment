using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    [Serializable]
    public class ReferenceValuesLogic
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
        public ReferenceValuesLogic(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //methods
        //Obtiene valores por referencia
        public ReferenceValues GetReferenceValues()
        {
            ReferenceValues referenceValues;
            DAReferenceValues accesoDatos = new DAReferenceValues(_cadenaConexion);
            try
            {
                referenceValues = accesoDatos.GetReferenceValues();
            }
            catch (Exception)
            {
                throw;
            }
            return referenceValues;
        }
        //Establece valores por referencia
        public int SetReferenceValues(ReferenceValues referenceValues)
        {
            int resultado;
            DAReferenceValues AD = new DAReferenceValues(_cadenaConexion);
            try
            {
                resultado = AD.SetReferenceValues(referenceValues);
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
