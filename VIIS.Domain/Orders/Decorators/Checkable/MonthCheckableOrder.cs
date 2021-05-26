using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Orders.Decorators.Checkable
{
    public class MonthCheckableOrder : BaseCheckableOrder
    {
        private readonly DateTime monthOfYear;

        public MonthCheckableOrder(CheckableOrder other, DateTime monthOfYear) : base(other)
        {
            this.monthOfYear = monthOfYear;
        }

        public override bool Check()
        {
            return ordersStart.Month == monthOfYear.Month && ordersStart.Year == monthOfYear.Year && checkableOther.Check();
        }
    }
}
