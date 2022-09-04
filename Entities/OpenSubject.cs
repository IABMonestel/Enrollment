using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    [Serializable]
    public class OpenSubject : CareerMatter
    {
        //Atributos
        private int openSubjectsCode;
        private int careerMatterCode;
        private int profesorCode;
        private short aulaCode;
        private byte groupO;
        private byte quota;
        private decimal cost;
        private byte period;
        private short year;
        private bool available;
        //Constructor
        public OpenSubject()
        {
            code = string.Empty;
            name = string.Empty;
            credits = 0;
            erased = false;
            exists = true;
            //
            codeCareerMatter = 0;
            careerCode = 0;
            careerName = string.Empty;
            matterCode = string.Empty;
            requirement = string.Empty;
            corequisite = string.Empty;
            existsCarrerMatter = false;
            //
            openSubjectsCode = 0;
            careerMatterCode = 0;
            profesorCode = 0;
            aulaCode = 0;
            groupO = 0;
            quota = 0;
            cost = 0;
            period = 0;
            year = 0;
            available = false;
        }
        //Constructor        
        public OpenSubject(string code, string name, byte credits, bool erased, bool exists, int codeCareerMatter, int careerCode, string careerName, string matterCode, string requirement, string corequisite, bool existsCarrerMatter,
            int openSubjectsCode, int careerMatterCode, int profesorCode, short aulaCode, byte group, byte quota, decimal cost, byte period, short year, bool available):base()
        {
            //Atributos de clase padre y abuelo
            this.code = code;
            this.name = name;
            this.credits = credits;
            this.erased = erased;
            this.exists = exists;
            //Atributos de clase padre
            this.codeCareerMatter = codeCareerMatter;
            this.careerCode = careerCode;
            this.careerName = careerName;
            this.matterCode = matterCode;
            this.requirement = requirement;
            this.corequisite = corequisite;
            this.existsCarrerMatter = existsCarrerMatter;
            //
            this.openSubjectsCode = openSubjectsCode;
            this.careerMatterCode = careerMatterCode;
            this.profesorCode = profesorCode;
            this.aulaCode = aulaCode;
            this.groupO = group;
            this.quota = quota;
            this.cost = cost;
            this.period = period;
            this.year = year;
            this.available = available;
        }
        //

        //Constructor para generar materia abierta
        public OpenSubject(int openSubjectsCode, int careerMatterCode, int profesorCode, short aulaCode, byte group, byte quota, 
            decimal cost, byte period, short year, bool available) : base()
        {           
            //
            this.openSubjectsCode = openSubjectsCode;
            this.careerMatterCode = careerMatterCode;
            this.profesorCode = profesorCode;
            this.aulaCode = aulaCode;
            this.groupO = group;
            this.quota = quota;
            this.cost = cost;
            this.period = period;
            this.year = year;
            this.available = available;
        }
        //Properties
        public int OpenSubjectsCode { get => openSubjectsCode; set => openSubjectsCode = value; }
        public int CareerMatterCode { get => careerMatterCode; set => careerMatterCode = value; }
        public int ProfesorCode { get => profesorCode; set => profesorCode = value; }
        public short AulaCode { get => aulaCode; set => aulaCode = value; }
        public byte Group { get => groupO; set => groupO = value; }
        public byte Quota { get => quota; set => quota = value; }
        public decimal Cost { get => cost; set => cost = value; }
        public byte Period { get => period; set => period = value; }
        public short Year { get => year; set => year = value; }
        public bool Available { get => available; set => available = value; }

        //toString()
        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7} - {8} - {9} - {10}", openSubjectsCode, careerMatterCode ,profesorCode, aulaCode,
                groupO, quota, cost , period, year, available);
        }
    }
}
