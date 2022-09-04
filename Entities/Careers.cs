using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Careers
    {
        //Atributos
        private int code;
        private string nameC;
        private short credits;
        private string degree;
        private bool exists;       

        //Properties
        public int Code { get => code; set => code = value; }
        public string Name { get => nameC; set => nameC = value; }
        public short Credits { get => credits; set => credits = value; }
        public string Degree { get => degree; set => degree = value; }
        public bool Exists { get => exists; set => exists = value; }
        //Constructor
        public Careers()
        {
            code = 0;
            nameC = string.Empty;
            credits = 0;
            degree = string.Empty;
            exists = false;
        }

        public Careers(int code, string name, short credits, string degree, bool exists)
        {
            this.code = code;
            this.nameC = name;
            this.credits = credits;
            this.degree = degree;
            this.exists = exists;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3}", code, nameC, credits, degree);
        }
    }
}
