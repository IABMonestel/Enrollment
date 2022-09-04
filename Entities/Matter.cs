using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Matter
    {
        protected string code;
        protected string name;
        protected byte credits;
        protected bool erased;
        protected bool exists;

        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public byte Credits { get => credits; set => credits = value; }
        public bool Erased { get => erased; set => erased = value; }
        public bool Exists { get => exists; set => exists = value; }

        public Matter(string code, string name, byte credits, bool erased, bool exists)
        {
            this.code = code;
            this.name = name;
            this.credits = credits;
            this.erased = erased;
            this.exists = exists;
        }

        public Matter()
        {
            code = string.Empty;
            name = string.Empty;
            credits = 0;
            erased = false;
            exists = false;
        }


        public override string ToString()
        {
            return string.Format("{0} - {1} - {0} - {1} - {0} - {1} - {0} ", code, name, credits, erased,
                exists);
        }

    }
}
