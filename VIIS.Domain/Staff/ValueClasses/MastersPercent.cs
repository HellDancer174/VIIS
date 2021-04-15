using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Staff.ValueClasses
{
    public class MastersPercent
    {
        private readonly int percentValue;

        public MastersPercent(int percentValue)
        {
            this.percentValue = percentValue;
        }
        public MastersPercent(): this(40)
        {
        }

        public decimal CashOfMaster(decimal orderSale) => orderSale * ((decimal)percentValue / 100);
    }
}
