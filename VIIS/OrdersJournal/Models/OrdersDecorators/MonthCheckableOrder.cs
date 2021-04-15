using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Orders;
using VIIS.Domain.Orders.Decorators;

namespace VIIS.App.OrdersJournal.Models.OrdersDecorators
{
    public class MonthCheckableOrder : CheckableOrder<DateTime>
    {
        public MonthCheckableOrder(Order other) : base(other)
        {
        }

        public override bool Check(DateTime value)
        {
            return ordersDate.Month == value.Month && ordersDate.Year == value.Year;
        }
    }
}
