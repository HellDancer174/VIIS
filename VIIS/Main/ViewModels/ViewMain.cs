using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VIIS.App.OrdersJournal.Views;
using VIIS.App.Account.Views;
using VIMVVM;
using VIIS.App.Staff.Views;
using VIIS.App.Main.Views;
using VIIS.App.Customers.Views;
using VIIS.App.Customers.ViewModels;
using VIIS.Domain.Customers;
using VIIS.App.Services.Views;
using VIIS.App.Finance.Views;
using VIIS.App.Finance.ViewModels;
using VIIS.Domain.Orders;
using VIIS.Domain.Staff;
using VIIS.Domain.Services;
using VIIS.App.OrdersJournal.ViewModels;
using VIIS.Domain.Global;
using VIIS.Domain.Finance;
using VIIS.App.GlobalViewModel;
using VIIS.App.Finance.MasterPay.ViewModels;

namespace VIIS.App.Main.ViewModels
{
    public class ViewMain: Notifier
    {
        private readonly Page journal;
        private readonly Page clients;
        private readonly Page staff;
        private readonly Page finance;
        private readonly Page account;
        private readonly MainView view;

        public ViewMain(Page journal, Page clients, Page staff, Page finance, Page account, MainView view)
        {
            this.journal = journal;
            this.clients = clients;
            this.staff = staff;
            this.finance = finance;
            this.account = account;
            this.view = view;
            Current = journal;
        }
        //public ViewMain(MainView view): this(new OrdersJournalView(), new ClientsView(new ViewClients(new Clients())), new EmployeesTabs(), new FinanceView(new ViewTransactions()), new UsersWindow(), view)
        //{

        //}

        public ViewMain(Orders orders, Employees masters, Clients clients, ServiceValueList serviceValues, ViewTransactions transactions, Repository<MasterCash> cashes, MainView view):
            this(new OrdersJournalView(new Journal(orders, masters, serviceValues, clients, transactions)), new ClientsView(new ViewClients(clients)), 
                new EmployeesTabs(), 
                new FinanceTabs(new ViewFinance(transactions, new ViewMasterCashList(cashes, transactions), orders, masters)), new UsersWindow(), view)
        {

        }

        public ViewMain(MainView view) : this(new Orders(), new Employees(), new Clients(), new ServiceValueList(), new ViewTransactions(), new Repository<MasterCash>(new List<MasterCash>()), view)
        {

        }

        private Page current;
        public Page Current
        {
            get => current;
            private set
            {
                if (value == current) return;
                else
                {
                    current = value;
                    ChangeProperty(nameof(Current));
                }
            }
        }

        public RelayCommand Journal => new RelayCommand((obj) => Current = journal);
        public RelayCommand Staff => new RelayCommand((obj) => Current = staff);
        public RelayCommand Clients => new RelayCommand((obj) => Current = clients);
        public RelayCommand Finance => new RelayCommand((obj) => Current = finance);
        public RelayCommand Settings => new RelayCommand((obj) => Current = account);

        public RelayCommand Exit => new RelayCommand((obj) => { new LoginWindow().Show(); view.Close(); });
    }
}
