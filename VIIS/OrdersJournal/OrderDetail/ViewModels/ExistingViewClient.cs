using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Clients;
using VIMVVM;

namespace VIIS.App.OrdersJournal.OrderDetail.ViewModels
{
    public class ExistingViewClient: ViewModel<Client>
    {
        public ExistingViewClient(ObservableCollection<ViewClient> clientNames, ViewClient selectedClient)
        {
            ClientNames = clientNames;
            SelectedClient = selectedClient;
        }
        public ExistingViewClient(ObservableCollection<ViewClient> clientNames):this(clientNames, new ViewClient(new AnyClient()))
        {
        }
        public ExistingViewClient(): this(new ObservableCollection<ViewClient>())
        {
        }


        public ObservableCollection<ViewClient> ClientNames { get; }
        public ViewClient SelectedClient { get; set; }

        public void Clear()
        {
            SelectedClient = new ViewClient(new AnyClient());
        }

        public override Client Model()
        {
            return SelectedClient.Model();
        }
    }
}
