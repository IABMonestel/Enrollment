using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Student : Person
    {
        //Atributos
        private string license;
        private string province;
        private string canton;
        private string district;
        private string othersSigns;
        private DateTime admissionDate;
        private byte discount;
        private string state;
           
        //Constructor
        public Student(string id, string name, string fLastName, string sLastName, string phone, string email, bool erased, bool exists, string license, string province, string canton, string district, string othersSigns, DateTime admissionDate, byte discount, string state) 
        {

            this.id = id;
            this.name = name;
            this.fLastName = fLastName;
            this.sLastName = sLastName;
            this.phone = phone;
            this.email = email;
            this.erased = erased;
            this.exists = exists;
            this.license = license;
            this.province = province;
            this.canton = canton;
            this.district = district;
            this.othersSigns = othersSigns;
            this.admissionDate = admissionDate;
            this.discount = discount;
            this.state = state;
        }

        public Student()
        {
            id = string.Empty;
            name = string.Empty;
            fLastName = string.Empty;
            sLastName = string.Empty;
            phone = string.Empty;
            email = string.Empty;
            erased = false;
            exists = true;
            license = string.Empty;
            province = string.Empty;
            canton = string.Empty;
            district = string.Empty;
            othersSigns = string.Empty;
            admissionDate = new DateTime();
            discount = 0;
            state = string.Empty;
        }

        //Properties
        public string License { get => license; set => license = value; }
        public string Province { get => province; set => province = value; }
        public string Canton { get => canton; set => canton = value; }
        public string District { get => district; set => district = value; }
        public string OthersSigns { get => othersSigns; set => othersSigns = value; }
        public DateTime AdmissionDate { get => admissionDate; set => admissionDate = value; }
        public byte Discount { get => discount; set => discount = value; }
        public string State { get => state; set => state = value; }

        //toString
        public override string ToString()
        {   //variables heredadas ?
            return string.Format("{0} - {1} - {2} - {3} - {4} - {6} - {7} - {8}",license, province, canton,
                district, othersSigns, admissionDate, discount, state);
        }


    }
}
