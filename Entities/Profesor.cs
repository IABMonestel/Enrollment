using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Profesor : Person
    {
        //Atributos
        private int code;
        //Properties
        public int Codigo { get => code; set => code = value; }
        //Constructor        

        public Profesor(int codigo, string id, string name, string fLastName, string sLastName, string phone, string email, bool erased, bool exists) : base()
        {
            this.id = id;
            this.name = name;
            this.fLastName = fLastName;
            this.SLastName = SLastName;
            this.phone = phone;
            this.email = email;
            this.erased = erased;
            this.exists = exists;
            this.code = codigo;
        }

        public Profesor()
        {
            this.id = string.Empty;
            this.name = string.Empty;
            this.fLastName = string.Empty;
            this.SLastName = string.Empty;
            this.phone = string.Empty;
            this.email = string.Empty;
            this.erased = false;
            this.exists = true;
            this.code = 0;
        }

        //ToString
        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7}", code ,id, name, fLastName, sLastName,
                phone, email);
        }


    }
}
