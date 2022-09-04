using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class CareerMatter : Matter
    {
        //Atributos
        protected int codeCareerMatter;
        protected int careerCode;
        protected string careerName;
        protected string matterCode;
        protected string requirement;
        protected string corequisite;
        protected bool existsCarrerMatter;
        //Properties
        public int CodeCareerMatter { get => codeCareerMatter; set => codeCareerMatter = value; }
        public int CareerCode { get => careerCode; set => careerCode = value; }
        public string MatterCode { get => matterCode; set => matterCode = value; }
        public string Requirement { get => requirement; set => requirement = value; }
        public string Corequisite { get => corequisite; set => corequisite = value; }
        public bool ExistsCarrerMatter { get => existsCarrerMatter; set => existsCarrerMatter = value; }
        public string CareerName { get => careerName; set => careerName = value; }

        //Constructor
        public CareerMatter(string code, string name, byte credits, bool erased, bool exists, int codeCareerMatter, int careerCode, string careerName, string matterCode, string requirement, string corequisite, bool existsCarrerMatter):base()
        {
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
        }
        //Constructor
        public CareerMatter()
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
        }
        //ToString
        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3} - {4} - {5}", codeCareerMatter, careerCode, careerName, matterCode, requirement,
                corequisite);
        }
    }
}
