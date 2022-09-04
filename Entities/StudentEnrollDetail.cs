using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class StudentEnrollDetail
    {
        private int matterCode;
        private int bill;
        private decimal costMatter;
        private string matter;
        private string requirement;
        private byte period;
        private short year;
        private DateTime date;
        private decimal discount;
        private decimal costEnroll;

        public StudentEnrollDetail()
        {
            matterCode = 0;
            requirement = string.Empty;
            date = new DateTime();
            bill = 0;
            matter = string.Empty;
            discount = 0;
            costMatter = 0;
            period = 0;
            year = 0;
            costEnroll = 0;
        }

        public StudentEnrollDetail(int matterCode, int bill, decimal costMatter, string matter, string requirement, byte period, short year, DateTime date, decimal discount, decimal costEnroll)
        {
            this.matterCode = matterCode;
            this.bill = bill;
            this.costMatter = costMatter;
            this.matter = matter;
            this.requirement = requirement;
            this.period = period;
            this.year = year;
            this.date = date;
            this.discount = discount;
            this.costEnroll = costEnroll;
        }

        public int Bill { get => bill; set => bill = value; }
        public decimal CostMatter { get => costMatter; set => costMatter = value; }
        public string Matter { get => matter; set => matter = value; }
        public string Requirement { get => requirement; set => requirement = value; }
        public byte Period { get => period; set => period = value; }
        public DateTime Date { get => date; set => date = value; }
        public short Year { get => year; set => year = value; }
        public decimal Discount { get => discount; set => discount = value; }
        public int MatterCode { get => matterCode; set => matterCode = value; }
        public decimal CostEnroll { get => costEnroll; set => costEnroll = value; }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7} - {8} - {9}",
                matterCode, bill, costMatter, matter, requirement, period, date, year,
                discount, costEnroll);
        }
    }
}
