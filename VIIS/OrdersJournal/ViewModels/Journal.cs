using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VIIS.App.OrdersJournal.Models.OrdersDecorators;
using VIIS.Domain.Orders;
using VIMVVM;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class Journal: ViewModel<Orders>
    {
        private Staff staff;
        private readonly Orders orders;
        private DateTime currentDate;

        public Journal(Staff staff, Orders orders)
        {
            this.staff = staff;
            this.orders = new ViewTrasferableOrders(this, orders);
            currentDate = DateTime.Now;
        }

        public Staff Staff => staff;

        public DateTime CurrentDate
        {
            get => currentDate;
            set
            {
                if (value == currentDate) return;
                currentDate = value;
                Task.Run(async () => await orders.Transfer());
            }
        }

        public void ChangeStaff(Staff staff)
        {
            this.staff = staff;
        }

        public RelayCommand Add => new RelayCommand((obj) => staff.CreateOrder());

    }
}
