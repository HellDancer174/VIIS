using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Clients;
using VIIS.Domain.Clients.Decorators;
using VIMVVM;

namespace VIIS.App.OrdersJournal.OrderDetail.ViewModels
{
    public class ExistingViewClient: ClientsDecorator
    {
        public ExistingViewClient(): this(new Clients())
        {
        }

        public ExistingViewClient(Clients other) : base(other)
        {
            Clients = new ObservableCollection<ViewClient>(clients.Select(client => new ViewClient(client)).ToList());
        }
        public ExistingViewClient(Clients other, Client current): this(other)
        {
            SelectedClient = new ViewClient(current);
        }

        public ObservableCollection<ViewClient> Clients { get; }
        private ViewClient selectedClient;
        public ViewClient SelectedClient
        {
            get => selectedClient;
            set
            {
                selectedClient = value;
                ChangeProperty();
            }
        }

        public void Clear()
        {
            SelectedClient = new ViewClient(new AnyClient());
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
