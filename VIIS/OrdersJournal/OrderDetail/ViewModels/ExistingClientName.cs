using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;

namespace VIIS.App.OrdersJournal.OrderDetail.ViewModels
{
    public class ExistingClientName: ViewModel<string>
    {
        public ExistingClientName(ObservableCollection<ClientName> clientNames, ClientName selectedClient)
        {
            ClientNames = clientNames;
            SelectedClient = selectedClient;
        }
        public ExistingClientName(ObservableCollection<ClientName> clientNames):this(clientNames, new ClientName())
        {
        }
        public ExistingClientName(): this(new ObservableCollection<ClientName>())
        {
        }


        public ObservableCollection<ClientName> ClientNames { get; }
        public ClientName SelectedClient { get; set; }
    }
}
