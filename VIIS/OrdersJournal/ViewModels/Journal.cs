using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VIIS.App.OrdersJournal.Models.OrdersDecorators;
using VIIS.Domain.Customers;
using VIIS.Domain.Orders;
using VIIS.Domain.Orders.Decorators;
using VIIS.Domain.Services;
using VIIS.Domain.Staff;
using VIMVVM;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class Journal: OrdersDecorator, INotifyPropertyChanged
    {
        private ViewJournalEmployees staff;
        private DateTime currentDate;
        private readonly Employees employees;
        private readonly ServiceValueList serviceValueList;
        private readonly Clients clients;

        public Journal(Orders orders, Employees employees, ServiceValueList serviceValueList, Clients clients): base(orders)
        {
            this.employees = employees;
            this.serviceValueList = serviceValueList;
            this.clients = clients;
            CurrentDate = DateTime.Now.Date;
        }
        public Journal():this(new Orders(), new Employees(), new ServiceValueList(), new Clients())
        {
        }

        public ViewJournalEmployees Staff => staff;

        public DateTime CurrentDate
        {
            get => currentDate;
            set
            {
                if (value == currentDate) return;
                currentDate = value;
                var staff = new ViewJournalEmployees(employees, currentDate, serviceValueList, clients, this, this.Where(order => order.CheckDate(currentDate)).ToList());
                ChangeStaff(staff);
            }
        }

        public void ChangeStaff(ViewJournalEmployees staff)
        {
            this.staff = staff;
            ChangeProperty(nameof(Staff));
        }

        public override async Task AddAsync(Order order)
        {
            staff.DaysPage.AddOrder(order, serviceValueList, clients);
            await base.AddAsync(order);
        }

        public override async Task Update(Order oldOrder, Order newOrder)
        {
            staff.DaysPage.RemoveOrder(oldOrder);
            staff.DaysPage.AddOrder(newOrder, serviceValueList, clients);
            await base.Update(oldOrder, newOrder);
        }

        public override async Task RemoveAsync(Order order)
        {
            staff.DaysPage.RemoveOrder(order);
            await base.RemoveAsync(order);
        }
    }
}
