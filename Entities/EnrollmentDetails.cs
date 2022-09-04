using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class EnrollmentDetails
    {
        //Atributos
        private int billNumber;
        private int openMatCode;
        private decimal discountPercent;
        private decimal finalNote;
        private string detailStatus;
        private bool exists;
        //Constructor
        public EnrollmentDetails()
        {
            billNumber = 0;
            openMatCode = 0;
            discountPercent = 0;
            finalNote = 0;
            detailStatus = string.Empty;
            exists = false;
        }
        //Constructor
        public EnrollmentDetails(int billNumber, int openMatCode, decimal discountPercent, decimal finalNote, string detailStatus, bool exists)
        {
            this.billNumber = billNumber;
            this.openMatCode = openMatCode;
            this.discountPercent = discountPercent;
            this.finalNote = finalNote;
            this.detailStatus = detailStatus;
            this.exists = exists;
        }
        //Properties
        public int BillNumber { get => billNumber; set => billNumber = value; }
        public int OpenMatCode { get => openMatCode; set => openMatCode = value; }
        public decimal DiscountPercent { get => discountPercent; set => discountPercent = value; }
        public decimal FinalNote { get => finalNote; set => finalNote = value; }
        public string DetailStatus { get => detailStatus; set => detailStatus = value; }
        public bool Exists { get => exists; set => exists = value; }

        //toString
        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3} - {4}", billNumber, OpenMatCode,discountPercent,
                finalNote, detailStatus);
        }
    }
}
