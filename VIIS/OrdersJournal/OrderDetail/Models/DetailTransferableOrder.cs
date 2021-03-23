using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.OrderDetail.ViewModels;
using VIIS.App.OrdersJournal.OrderDetail.Views.ClientNamePages;
using VIIS.Domain.Clients;
using VIIS.Domain.Orders;
using VIIS.Domain.Orders.Decorators;
using VIIS.Domain.Services;

namespace VIIS.App.OrdersJournal.OrderDetail.Models
{
    public class DetailTransferableOrder : OrderDecorator
    {
        private readonly OrderDetailVM detailVM;
        private readonly ViewTransferableServiceValueList serviceValueList;
        private readonly NamingClients clients;

        public DetailTransferableOrder(Order other, OrderDetailVM detailVM, Clients clients, ServiceValueList serviceValueList) : base(other)
        {
            this.detailVM = detailVM;
            this.serviceValueList = new ViewTransferableServiceValueList(serviceValueList);
            this.clients = new NamingClients(clients);
        }

        public override void Transfer()
        {
            ViewClient newClient = new ViewClient(client);
            ExistingViewClient existingClient;
            if (clients.Find(client) == new AnyClient()) existingClient = new ExistingViewClient();
            else existingClient = new ExistingViewClient(new ObservableCollection<ViewClient>(clients.ViewNames()), newClient);
            detailVM.ChangeContent(new ViewClients(new NewClient(newClient), new ExistingClient(existingClient), newClient, existingClient), ordersDate,
                new ObservableCollection<ViewService>(services.Select(service => new ViewService(serviceValueList.ViewServices, service))),
                comment, "Сохранить", "Удалить", serviceValueList.ViewServices.ToList());
        }
    }
}
