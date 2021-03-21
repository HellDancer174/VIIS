using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.ViewModels;
using VIIS.Domain.Employees;
using VIIS.Domain.Orders;

namespace VIIS.App.OrdersJournal.Models.OrdersDecorators
{
    public class ViewTrasferableOrders : Orders
    {
        private readonly WorkDaysPage workDaysPage;
        private readonly Orders orders;

        public ViewTrasferableOrders(WorkDaysPage workDaysPage, Orders orders): base(orders)
        {
            this.workDaysPage = workDaysPage;
            this.orders = orders;
        }

        public override Task Transfer()
        {
            foreach(var order in ordersList)
            {
                workDaysPage.AddOrder(order);
            }
            return Task.CompletedTask;
        }
    }
}
