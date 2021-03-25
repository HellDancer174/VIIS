using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.Models.OrdersDecorators;
using VIIS.App.OrdersJournal.OrderDetail.ViewModels;
using VIIS.App.OrdersJournal.OrderDetail.Views;
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
        private readonly DateTime workDay;
        private readonly ServiceValueList serviceValueList;
        private readonly Clients clients;
        private readonly Journal journal;

        public ViewJournalEmployees(Employees other, DateTime workDay, ServiceValueList serviceValueList, Clients clients, Journal journal, List<Order> orders) : base(other)
        {
            var mastersPosition = new Position("Мастер - парикмахер");
            var manicurePosition = new Position("Мастер маникюра");
            var pedicurePosition = new Position("Мастер педикюра");
            Masters = masters.Where(master => master.Equals(mastersPosition) && master.IsWork(workDay)).ToList();
            Manicure = masters.Where(master => master.Equals(manicurePosition) && master.IsWork(workDay)).ToList();
            Pedicure = masters.Where(master => master.Equals(pedicurePosition) && master.IsWork(workDay)).ToList();
            daysPage = new WorkDaysPage(masters, journal);
            this.workDay = workDay;
            this.serviceValueList = serviceValueList;
            this.clients = clients;
            this.journal = journal;
            AddOrdersList(orders, serviceValueList, clients);
            SelectedMaster = masters.First();
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

        public RelayCommand CreateOrder => new RelayCommand((obj) => new OrderDetailView(new ViewNewOrderDetail(selectedMaster, workDay, journal, serviceValueList, clients)).Show());

    }
}
