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
        public ViewMain(MainView view): this(new OrdersJournalView(), new ClientsView(new ViewClients(new Clients())), new EmployeesTabs(), new ServicesView(), new UsersWindow(), view)
        {

        }
        public ViewMain(): this(new MainView())
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
