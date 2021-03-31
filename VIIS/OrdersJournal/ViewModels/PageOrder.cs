using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.Models.OrdersDecorators;
using VIIS.App.OrdersJournal.OrderDetail.ViewModels;
using VIIS.App.OrdersJournal.OrderDetail.Views;
using VIIS.App.Services.ViewModels;
using VIIS.Domain.Customers;
using VIIS.Domain.Orders;
using VIIS.Domain.Orders.Decorators;
using VIIS.Domain.Services;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class PageOrder: OrderDecorator, IComparable<PageOrder>
    {
        private readonly BaseViewService service;
        private readonly ViewClient viewClient;
        private readonly ServiceValueList serviceValueList;
        private readonly Clients clients;

        public PageOrder(Order other, Service service, ServiceValueList serviceValueList, Clients clients) : base(other)
        {
            this.service = new BaseViewService(service);
            viewClient = new ViewClient(client);
            this.serviceValueList = serviceValueList;
            this.clients = clients;
        }

        public string Customer => viewClient.FullName;
        public string Phone => viewClient.Phone;
        public string OrderInfo => service.ToString();
        

        public int ContentIndex()
        {
            return service.Start.TimeOfDay.Hours;
        }

        public bool IsOwnerIndex(int index)
        {
            return index == service.Start.TimeOfDay.Hours;
        }

        public bool CheckOrders(PageOrder other)
        {
           return service.CheckYourSelf(other.service);
        }

        public virtual void ShowDetail(Journal journal)
        {
            new OrderDetailView(new OrderDetailVM(this, journal, serviceValueList, clients)).Show();
        }
        public override string ToString()
        {
            return String.Format("Заказ: {0}, {1}, {2}, {3}", service.Start, Customer, Phone, service.ToString());
        }

        public bool Equals(Service other)
        {
            return service.Equals(other);
        }

        public int CompareTo(PageOrder other)
        {
            return service.CompareTo(other.service);
        }
    }
}
