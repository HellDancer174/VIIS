using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.Models.OrdersDecorators;
using VIIS.Domain.Clients;
using VIIS.Domain.Orders;
using VIIS.Domain.Services;
using VIIS.Domain.Staff;
using VIIS.Domain.Staff.Decorators;
using VIIS.Domain.Staff.ValueClasses;
using VIMVVM;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class ViewJournalEmployees: EmployeesDecorator
    {
        private readonly WorkDaysPage daysPage;

        public ViewJournalEmployees(Employees other, DateTime workDay) : base(other)
        {
            var mastersPosition = new Position("Мастер - парикмахер");
            var manicurePosition = new Position("Мастер маникюра");
            var pedicurePosition = new Position("Мастер педикюра");
            Masters = masters.Where(master => master.Equals(mastersPosition) && master.IsWork(workDay)).ToList();
            Manicure = masters.Where(master => master.Equals(manicurePosition) && master.IsWork(workDay)).ToList();
            Pedicure = masters.Where(master => master.Equals(pedicurePosition) && master.IsWork(workDay)).ToList();
            daysPage = new WorkDaysPage(masters);
        }

        public List<Master> Manicure { get; }
        public List<Master> Pedicure { get; }
        public List<Master> Masters { get; }

        private Master selectedMaster;
        public Master SelectedMaster
        {
            get => selectedMaster;
            set
            {
                selectedMaster = value;
                DaysPage.ChangeMaster(selectedMaster);
            }
        }

        public void AddOrdersList(List<Order> orders, ServiceValueList serviceValueList, Clients clients)
        {
            foreach (var order in orders)
                daysPage.AddOrder(order, serviceValueList, clients);
        }

        public WorkDaysPage DaysPage => daysPage;

        public void CreateOrder() => daysPage.CreateOrder();
    }
}
