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
        public ExistingClientName(ObservableCollection<ViewClient> clientNames, ViewClient selectedClient)
        {
            ClientNames = clientNames;
            SelectedClient = selectedClient;
        }
        public ExistingClientName(ObservableCollection<ViewClient> clientNames):this(clientNames, new ViewClient())
        {
        }
        public ExistingClientName(): this(new ObservableCollection<ViewClient>())
        {
        }


        public ObservableCollection<ViewClient> ClientNames { get; }
        public ViewClient SelectedClient { get; set; }
    }
}
