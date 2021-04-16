using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Orders.Decorators
{
    public class MonthCheckableOrder : CheckableOrder<DateTime>
    {
        public MonthCheckableOrder(Order other, DateTime monthOfYear) : base(other, monthOfYear)
        {
        }

        public override bool Check()
        {
            return ordersDate.Month == checker.Month && ordersDate.Year == checker.Year && checkableOther.Check();
        }
    }
}
