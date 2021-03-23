using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.OrderDetail.ViewModels;
using VIIS.Domain.Clients;

namespace VIIS.App.OrdersJournal.OrderDetail.Models
{
    public class NamingClients : Clients
    {
        private readonly Clients other;

        public NamingClients(Clients other) : base(other)
        {
            this.other = other;
        }

        public List<string> Names()
        {
            return clients.Select(client => client.FullName).ToList();
        }
        public List<ViewClient> ViewNames()
        {
            return clients.Select(client => new ViewClient(client)).ToList();
        }
    }
}
