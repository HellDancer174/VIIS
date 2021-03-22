using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VIIS.App.OrdersJournal.Models.OrdersDecorators;
using VIIS.Domain.Orders;
using VIIS.Domain.Staff;
using VIMVVM;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class Journal: ViewModel<Orders>
    {
        private ViewJournalEmployees staff;
        private readonly ViewTrasferableOrders orders;
        private DateTime currentDate;

        public Journal(Orders orders, Employees employees)
        {
            this.orders = new ViewTrasferableOrders(this, employees, orders);
            currentDate = DateTime.Now.Date;
            this.orders.Transfer(currentDate);
        }
        public Journal():this(new Orders(), new Employees())
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
                orders.Transfer(currentDate);
            }
        }

        public void ChangeStaff(ViewJournalEmployees staff)
        {
            this.staff = staff;
            ChangeProperty(nameof(Staff));
        }

        public RelayCommand Add => new RelayCommand((obj) => staff.CreateOrder());

    }
}
