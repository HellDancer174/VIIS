using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.ViewModels;
using VIIS.Domain.Staff;
using VIIS.Domain.Orders;
using VIIS.Domain.Orders.Decorators;
using VIIS.App.OrdersJournal.Models.EmployeesDecorators;

namespace VIIS.App.OrdersJournal.Models.OrdersDecorators
{
    public class ViewTrasferableOrders : Orders
    {
        private readonly Journal journal;
        private readonly GroupedEmployees employees;
        private readonly Orders orders;

        public ViewTrasferableOrders(Journal journal, Employees employees, Orders orders): base(orders)
        {
            this.journal = journal;
            this.employees = new GroupedEmployees(employees);
            this.orders = orders;
        }

        public virtual void Transfer(DateTime workDay)
        {
            var currentOrders = ordersList.Where(order => new DateCheckableOrder(order).CheckDate(workDay.Date)).ToList();
            Transfer(currentOrders, employees.ViewEmployees(workDay.Date));

        }
        public void Transfer(IEnumerable<Order> orders, ViewJournalEmployees staff)
        {
            foreach (var order in orders)
            {
                staff.DaysPage.AddOrder(order);
            }
            journal.ChangeStaff(staff);
        }
    }
}
