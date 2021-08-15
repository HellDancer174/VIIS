using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VIIS.App.Finance.ViewModels;
using VIIS.App.GlobalViewModel;
using VIIS.App.OrdersJournal.Models.OrdersDecorators;
using VIIS.App.OrdersJournal.OrderDetail.ViewModels;
using VIIS.App.OrdersJournal.OrderDetail.Views;
using VIIS.Domain.Customers;
using VIIS.Domain.Finance;
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
        private readonly ViewWorkDay daysPage;
        private readonly DateTime workDay;
        private readonly ServiceValueList serviceValueList;
        private readonly Clients clients;
        private readonly Journal journal;
        private readonly ViewRepository<ViewTransaction, Transaction> transactions;

        public ViewJournalEmployees(Employees other, DateTime workDay, ServiceValueList serviceValueList, Clients clients, Journal journal, List<Order> orders, ViewRepository<ViewTransaction, Transaction> transactions) : base(other)
        {
            var mastersPosition = new Position("Мастер-парикмахер");
            var manicurePosition = new Position("Мастер маникюра");
            var pedicurePosition = new Position("Мастер педикюра");
            Masters = this.Where(master => master.Equals(mastersPosition) && master.IsWork(workDay)).ToList();
            Manicure = this.Where(master => master.Equals(manicurePosition) && master.IsWork(workDay)).ToList();
            Pedicure = this.Where(master => master.Equals(pedicurePosition) && master.IsWork(workDay)).ToList();
            daysPage = new ViewWorkDay(this.ToList(), journal, transactions);
            this.workDay = workDay;
            this.serviceValueList = serviceValueList;
            this.clients = clients;
            this.journal = journal;
            this.transactions = transactions;
            AddOrdersList(orders, serviceValueList, clients);
            SelectedMaster = this.FirstOrDefault(first => Masters.Contains(first)|| Manicure.Contains(first)|| Pedicure.Contains(first));
        }

        public List<Master> Manicure { get; }
        public List<Master> Pedicure { get; }
        public List<Master> Masters { get; }

        private Master selectedMaster;
        public Master SelectedMaster
        {
            get => null;
            set
            {
                if (value == null) return;
                selectedMaster = value;
                DaysPage.ChangeMaster(selectedMaster);
            }
        }


        public void AddOrdersList(List<Order> orders, ServiceValueList serviceValueList, Clients clients)
        {
            try
            {
                foreach (var order in orders)
                    daysPage.AddOrder(order, serviceValueList, clients);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
        }

        public ViewWorkDay DaysPage => daysPage;

        public RelayCommand CreateOrder => new RelayCommand((obj) => new WindowOrderDetail(new ViewNewOrderDetail(selectedMaster, workDay, journal, serviceValueList, clients, transactions), new OrderDetailView()), (obj) => selectedMaster is Master);

        public virtual ICommand RefreshCommand => new RelayCommand(async (obj) => await journal.UpdateAsync());
    }
}
