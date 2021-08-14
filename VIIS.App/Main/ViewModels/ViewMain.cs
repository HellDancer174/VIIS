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
using VIIS.App.Staff.ViewModels;
using VIIS.App.Services.ViewModels;
using VIIS.App.Account.ViewModels;
using VIIS.App.Account.Models;
using ElegantLib.Requests;
using System.Net.Http;
using System.Net;
using System.Net.Security;
using ElegantLib.Authorize.Tokenize;
using VIIS.Domain.Account;

namespace VIIS.App.Main.ViewModels
{
    public class ViewMain: Notifier
    {
        private readonly Page journalPage;
        private readonly Page clients;
        private readonly Page staff;
        private readonly Page finance;
        private readonly Page serviceValues;
        private readonly Page account;
        private readonly MainView view;
        private readonly JwtAccount jwtAccount = new JwtAccount(new HttpClient(), new VIISJwtURL());
        private readonly Action<RefreshViewModel> saveToken = (token) => App.Token = token;

        public ViewMain(Page journal, Page clients, Page staff, Page finance, Page serviceValues, Page account, MainView view)
        {
            this.journalPage = journal;
            this.clients = clients;
            this.staff = staff;
            this.finance = finance;
            this.serviceValues = serviceValues;
            this.account = account;
            this.view = view;
            Current = journal;
        }
        //public ViewMain(Journal journal, ViewClients clients, ViewEmployees masters, ViewWorkGraph viewWorkGraph, )
        //{

        //}
        //public ViewMain(MainView view): this(new OrdersJournalView(), new ClientsView(new ViewClients(new Clients())), new EmployeesTabs(), new FinanceView(new ViewTransactions()), new UsersWindow(), view)
        //{

        //}

        public ViewMain(Orders orders, Employees masters, Clients clients, ServiceValueList serviceValues, ViewTransactions transactions, Repository<MasterCash> cashes, ViewUsers users, MainView view, Action<RefreshViewModel> saveToken)
            //this(new OrdersJournalView(new Journal(orders, new Employees(), serviceValues, clients, transactions)), new ClientsView(new ViewClients(clients, saveToken)), 
            //    new EmployeesTabs(new ViewEmployeesTabs(new EmployeesList(new ViewEmployees(masters, saveToken, )), new WorkGraph(new ViewWorkGraph(masters, DateTime.Now)), new PayView())), 
            //    new FinanceTabs(new ViewFinance(transactions, new ViewMasterCashList(cashes, saveToken, transactions, masters.Select(master => new ViewEmployee(master)).ToList()), orders, masters)),
            //    new ServicesView(new ViewServices(serviceValues, saveToken)), new UsersWindow(users), view)
        {
            Journal journal = new Journal(orders, masters, serviceValues, clients, transactions, saveToken);
            journalPage = new OrdersJournalView(journal);
            this.clients = new ClientsView(new ViewClients(clients, saveToken));
            staff = new EmployeesTabs(new ViewEmployeesTabs(new EmployeesList(new ViewEmployees(masters, saveToken, journal)), new WorkGraph(new ViewWorkGraph(masters, DateTime.Now, journal))));
            finance = new FinanceTabs(new ViewFinance(transactions, new ViewMasterCashList(cashes, saveToken, transactions, masters.Select(master => new ViewEmployee(master)).ToList()), orders, masters));
            this.serviceValues = new ServicesView(new ViewServices(serviceValues, saveToken));
            account = new UsersWindow(users);
            this.view = view;
            this.view.DataContext = this;
            Current = journalPage;
        }

        public ViewMain(MainView view) : this(new Orders(new Master()), new Employees(), new Clients(), new ServiceValueList(), new ViewTransactions(), new Repository<MasterCash>(new List<MasterCash>()), new ViewUsers(), view, (token) => App.Token = token)
        {
        }

        public string UserName { get => App.CurrentUser.ToString(); }

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

        public RelayCommand Journal => new RelayCommand((obj) => Current = journalPage);
        public RelayCommand Staff => new RelayCommand((obj) => Current = staff);
        public RelayCommand Clients => new RelayCommand((obj) => Current = clients);
        public RelayCommand Finance => new RelayCommand((obj) => Current = finance);
        public RelayCommand ServiceValues => new RelayCommand((obj) => Current = serviceValues);
        public RelayCommand Settings => new RelayCommand((obj) => Current = account);

        public RelayCommand Exit => new RelayCommand(async(obj) => 
        {
            await jwtAccount.LogOut(App.Token);
            new LoginWindow().Show(); view.Close();
        });

        public void ShowView() => view.Show();
    }
}
