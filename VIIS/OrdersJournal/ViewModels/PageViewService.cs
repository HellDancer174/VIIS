using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.Models.OrdersDecorators;
using VIIS.App.OrdersJournal.OrderDetail.ViewModels;
using VIIS.App.OrdersJournal.OrderDetail.Views;
using VIIS.App.Services.ViewModel;
using VIIS.Domain.Orders;
using VIIS.Domain.Services;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class PageViewService: BaseViewService, IEquatable<Order>, IEquatable<Service>
    {
        private readonly Service service;
        private readonly Order order;

        public string Customer { get; set; }
        public string Phone { get; set; }

        public PageViewService(string customer, string phone, ViewService selectedService, TimeSpan start, TimeSpan timeSpan, Order order): base(selectedService.Model(), start, timeSpan)
        {
            
            ChangeContent(customer, phone, selectedService, start, timeSpan);
            this.order = order;
        }

        public PageViewService(string customer, string phone, ViewService selectedService, Service service, Order order):this(customer, phone, selectedService, new TimeSpan(), new TimeSpan(), order)
        {
            this.service = new ViewTransferableService(service, this);
            this.service.Transfer();
            this.order = order;
        }

        public int ContentIndex()
        {
            return Start.Hours;
        }

        public bool IsOwnerIndex(int index)
        {
            return index == Start.Hours;
        }

        public bool CheckOrders(PageViewService other)
        {
           return service.CheckYourSelf(other.service);
        }

        public void ChangeContent(string customer, string phone, ViewServiceValue selectedService, TimeSpan orderTime, TimeSpan timeSpan)
        {
            Customer = customer;
            Phone = phone;
            SelectedService = selectedService;
            Start = orderTime;
            TimeSpan = timeSpan;
        }


        public void ShowDetail(PageTime currentTime)
        {
            new OrderDetailView(new OrderDetailVM()).Show();//Прокинуть туда currentTime и this(PageContent).
        }
        public override string ToString()
        {
            return String.Format("Заказ: {0}, {1}, {2}, {3}", Start, Customer, Phone, SelectedService);
        }

        public bool Equals(Order other)
        {
           return order.Equals(other);
        }

        public bool Equals(Service other)
        {
            return service.Equals(other);
        }
    }
}
