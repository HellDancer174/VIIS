using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Orders.Decorators.Checkable
{
    public class DateSpanCheckableOrder : BaseCheckableOrder
    {
        private readonly DateTime startDate;
        private readonly DateTime finishDate;

        public DateSpanCheckableOrder(CheckableOrder other, DateTime startDate, DateTime finishDate) : base(other)
        {
            this.startDate = startDate;
            this.finishDate = finishDate;
        }

        public override bool Check()
        {
            return ordersStart.Month >= startDate.Month && 
                ordersStart.Month <= finishDate.Month && 
                ordersStart.Year >= startDate.Year && 
                ordersStart.Year <= finishDate.Year &&
                ordersStart.Day >= startDate.Day &&
                ordersStart.Day <= finishDate.Day &&
                checkableOther.Check();
        }
    }
}
