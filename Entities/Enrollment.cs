using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Enrollment
    {
        int numFact;
        string meat;
        DateTime dateM;
        decimal amount;
        string typePayment;
        string purchasePayment;
        string stateFac;
        string stateMat;

        public Enrollment()
        {
            numFact = 0;
            meat = string.Empty;
            dateM = new DateTime();
            amount = 0;
            typePayment = string.Empty;
            purchasePayment = string.Empty;
            stateFac = string.Empty;
            stateMat = string.Empty;
        }

        public Enrollment(int numFact, string meat, DateTime date, decimal amount, string typePayment, string purchasePayment, string stateFac, string stateMat)
        {
            this.numFact = numFact;
            this.meat = meat;
            this.dateM = date;
            this.amount = amount;
            this.typePayment = typePayment;
            this.purchasePayment = purchasePayment;
            this.stateFac = stateFac;
            this.stateMat = stateMat;
        }

        public int NumFact { get => numFact; set => numFact = value; }
        public string Meat { get => meat; set => meat = value; }
        public DateTime Date { get => dateM; set => dateM = value; }
        public decimal Amount { get => amount; set => amount = value; }
        public string TypePayment { get => typePayment; set => typePayment = value; }
        public string PurchasePayment { get => purchasePayment; set => purchasePayment = value; }
        public string StateFac { get => stateFac; set => stateFac = value; }
        public string StateMat { get => stateMat; set => stateMat = value; }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7}", numFact, meat, dateM, amount, typePayment, purchasePayment,
                                    stateFac, stateMat);
        }
    }
}
