using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Orders;
using VIIS.Domain.Orders.Decorators;

namespace VIIS.App.OrdersJournal.Models.OrdersDecorators
{
    public class OrdersPerMonth : OrdersDecorator
    {
        public OrdersPerMonth(List<Order> orders, DateTime monthOfYear) : 
            base(new Orders(orders.Select(order => new MonthCheckableOrder(order)).Where(checkableOrder => checkableOrder.Check(monthOfYear)).Select(checkableOrder => (Order)checkableOrder).ToList()))
        {
        }
    }
}
