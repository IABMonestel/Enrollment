using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class ReferenceValues
    {
        private decimal activeEnroll;
        private decimal year;
        private decimal period;
        private decimal tax;
        private decimal costEnroll;

        public ReferenceValues()
        {
            activeEnroll = 0;
            year = 0;
            period = 0;
            tax = 0;
            costEnroll = 0;
        }

        public ReferenceValues(decimal activeEnroll, decimal year, decimal period, decimal tax, decimal costEnroll)
        {
            this.activeEnroll = activeEnroll;
            this.year = year;
            this.period = period;
            this.tax = tax;
            this.costEnroll = costEnroll;
        }

        public decimal ActiveEnroll { get => activeEnroll; set => activeEnroll = value; }
        public decimal Year { get => year; set => year = value; }
        public decimal Period { get => period; set => period = value; }
        public decimal Tax { get => tax; set => tax = value; }
        public decimal CostEnroll { get => costEnroll; set => costEnroll = value; }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3} - {4}", activeEnroll, year, period, tax, costEnroll);
        }
    }
}
