using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Customers;
using VIMVVM;

namespace VIIS.App.Customers.ViewModels
{
    public class ViewNewClient : ViewClient
    {
        public ViewNewClient(ViewClients clients) : this(new ViewClient(clients))
        {
        }

        public ViewNewClient(ViewClient viewClient) : base(viewClient)
        {
        }

        public override RelayCommand Save => new RelayCommand(async (obj) =>
        {
            await clients.AddAsync(new Client(this));
        });

        public override RelayCommand End => new RelayCommand((obj) => { });
    }
}
