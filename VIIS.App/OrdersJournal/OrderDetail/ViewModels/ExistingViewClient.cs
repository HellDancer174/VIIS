using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Customers;
using VIIS.Domain.Customers.Decorators;
using VIMVVM;

namespace VIIS.App.OrdersJournal.OrderDetail.ViewModels
{
    public class ExistingViewClient: ClientDecorator
    {
        //public ExistingViewClient(): this(new Clients())
        //{
        //}

        public ExistingViewClient(Clients other, ViewClients clientNames):base(other.First())
        {
            this.clientNames = clientNames;
            Clients = new ObservableCollection<ViewClient>(other.Select(client => new ViewClient(client)).ToList());
            Clients.Add(new ViewClient(new AnyClient()));
            Clear();
        }
        public ExistingViewClient(Clients other, Client current, ViewClients clientNames) : this(other, clientNames)
        {
            if(current.IsNew) Clear();
            else SelectedClient = Clients.FirstOrDefault(client => client.Equals(new ViewClient(current)));
        }

        public ObservableCollection<ViewClient> Clients { get; }
        private ViewClient selectedClient;
        private readonly ViewClients clientNames;

        public ViewClient SelectedClient
        {
            get => selectedClient;
            set
            {
                selectedClient = value;
                if(selectedClient != null) clientNames.ChangeClient(selectedClient);
                ChangeProperty();
            }
        }

        public void Clear()
        {
            SelectedClient = Clients.FirstOrDefault(client => client.IsAnyClient);
        }

        public Client Model()
        {
            if (selectedClient != null) return SelectedClient.Model();
            else return new AnyClient();
        }

        public override string ToString()
        {
            if (selectedClient == null) return new AnyClient().ToString();
            else return selectedClient.ToString();
        }
    }
}
