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
            ClientNames = new ObservableCollection<ViewClient>(clients.Select(client => new ViewClient(client)).ToList());
        }
        public ExistingViewClient(Clients other, Client current): this(other)
        {
            SelectedClient = new ViewClient(current);
        }

        public ObservableCollection<ViewClient> ClientNames { get; }
        public ViewClient SelectedClient { get; set; }

        public void Clear()
        {
            SelectedClient = new ViewClient(new AnyClient());
        }

        public Client Model()
        {
            return SelectedClient.Model();
        }
    }
}
