namespace Entities
{
    public abstract class Person
    {
        //Atributos
        protected string id;
        protected string name;
        protected string fLastName;
        protected string sLastName;
        protected string phone;
        protected string email;
        protected bool erased;
        protected bool exists;
        //Properties
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string FLastName { get => fLastName; set => fLastName = value; }
        public string SLastName { get => sLastName; set => sLastName = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public bool Erased { get => erased; set => erased = value; }
        public bool Exists { get => exists; set => exists = value; }

        //Constructor
        public Person()
        {
            id = string.Empty;
            name = string.Empty;
            fLastName = string.Empty;
            sLastName = string.Empty;
            phone = string.Empty;
            email = string.Empty;
            erased = false;
            exists = false;
        }

        public Person(string id, string name, string fLastName, string sLastName, string phone, string email, bool erased, bool exists):base()
        {
            this.id = id;
            this.name = name;
            this.fLastName = fLastName;
            this.sLastName = sLastName;
            this.phone = phone;
            this.email = email;
            this.erased = erased;
            this.exists = exists;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {0} - {1} - {0} - {1} - {0} ", id, name, fLastName, sLastName,
                phone, email);
        }
    }
}