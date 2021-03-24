using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.ViewModels;
using VIIS.Domain.Clients;
using VIIS.Domain.Orders;
using VIIS.Domain.Orders.Decorators;
using VIIS.Domain.Services;
using VIIS.Domain.Staff;

namespace VIIS.App.OrdersJournal.Models.OrdersDecorators
{
    public class JournalOrder : OrderDecorator
    {
        private readonly ServiceValueList serviceValueList;
        private readonly Clients clients;

        public JournalOrder(Order other, ServiceValueList serviceValueList, Clients clients) : base(other)
        {
            this.serviceValueList = serviceValueList;
            this.clients = clients;
        }

        public KeyValuePair<Master, List<PageOrder>> PageOrders => 
            new KeyValuePair<Master, List<PageOrder>>(master, services.Select(service => new PageOrder(this, service, serviceValueList, clients)).ToList());
    }
}
