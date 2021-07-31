using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VIIS.App.OrdersJournal.OrderDetail.Views.ClientNamePages;
using VIIS.Domain.Customers;
using VIMVVM;

namespace VIIS.App.OrdersJournal.OrderDetail.ViewModels
{
    public class ViewClients : Notifier<Client>
    {
        private readonly NewClient newClientPage;
        private readonly ExistingClient existingClientPage;
        private readonly ViewClient newClient;
        private ViewClient currentViewClient;
        private readonly ExistingViewClient existingClient;
        private bool _isNew;
        //private bool _isExist;

        public ViewClients(ViewClient current, Clients clients)
        {
            this.newClient = new ViewClient(new Client());
            this.newClientPage = new NewClient(newClient);
            var existingClient = new ExistingViewClient(clients, current, this);
            this.existingClientPage = new ExistingClient(existingClient);
            this.existingClient = existingClient;
        }
        //public ViewClients(Clients clients):this(new ViewClient(new Client()), clients)
        //{

        //}

        //public ViewClients(ViewClient newClient, Clients clients)
        //{

        //}
        public Page New => (Page)newClientPage;

        public Page Exist => (Page)existingClientPage;

        public bool IsNew { get => _isNew; set { _isNew = value; ChangeProperty(); } }

        public ViewClient CurrentViewClient
        {
            get => currentViewClient;
            private set
            {
                currentViewClient = value;
                newClientPage.DataContext = currentViewClient;
            }
        }

        //public bool IsExist { get => _isExist; set { _isExist = value; ChangeProperty(); } }

        public void ChangeClient(ViewClient client)
        {
            if (client.IsAnyClient)
            {
                CurrentViewClient = newClient;
                IsNew = true;
            }
            else
            {
                CurrentViewClient = client;
                IsNew = false;
            }
        }

        public override Client Model()
        {
            var anyClient = new AnyClient();
            var newModel = newClient.Model();
            var existingModel = existingClient.Model();
            if (newModel.Equals(anyClient) && !existingModel.Equals(anyClient)) return existingModel;
            else if (!newModel.Equals(anyClient) && existingModel.Equals(anyClient)) return newModel;
            else throw new InvalidOperationException(String.Format("Выберите одного клиента: Новый - {0}, Существующий - {1}", newClient.ToString(), existingClient.ToString()));
        }

        public void Clear()
        {
            newClient.Clear();
            existingClient.Clear();
        }

        //public RelayCommand WorkWithNewClient => new RelayCommand((obj) => Current = newClientPage);
        //public RelayCommand WorkWithExistingClient => new RelayCommand((obj) => Current = existingClientPage);

    }
}
