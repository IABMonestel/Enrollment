using System;

namespace Entities
{
    public class Aula
    {
        //Atributos
        private short codigo;
        private string tipo;
        private byte numero;
        private byte capacidad;
        private bool existe;
        
        //Properties
        public short Codigo { get => codigo; set => codigo = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public byte Numero { get => numero; set => numero = value; }
        public byte Capacidad { get => capacidad; set => capacidad = value; }
        public bool Existe { get => existe; set => existe = value; }

        //Constructor
        public Aula()
        {
            codigo = 0;
            tipo = string.Empty;
            numero = 0;
            capacidad = 0;
            existe = false;
        }
        public Aula(short codigo, string tipo, byte numero, byte capacidad, bool existe)
        {
            this.codigo = codigo;
            this.tipo = tipo;
            this.numero = numero;
            this.capacidad = capacidad;
            this.existe = existe;
        }
        //
        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3}", codigo, tipo, numero, capacidad);
        }
    }
}
