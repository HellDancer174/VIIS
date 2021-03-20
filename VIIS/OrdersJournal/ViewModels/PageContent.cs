using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.Models.OrdersDecorators;
using VIIS.Domain.Orders;
using VIIS.Domain.Services;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class PageContent
    {
        private readonly Service service;

        public string Customer { get; set; }
        public string Phone { get; set; }
        public string OrderInfo { get; set; }
        public TimeSpan OrderTime { get; set; }
        

        public PageContent(string customer, string phone, string orderInfo, TimeSpan orderTime)
        {
            ChangeContent(customer, phone, orderInfo, orderTime);
        }

        public PageContent(string customer, string phone, string orderInfo, Service service):this(customer, phone, orderInfo, new TimeSpan())
        {
            this.service = new ViewTransferableService(service, this);
            service.Transfer();
        }

        public int ContentIndex()
        {
            return OrderTime.Hours;
        }

        public bool IsOwnerIndex(int index)
        {
            return index == OrderTime.Hours;
        }

        public bool CheckOrders(PageContent other)
        {
           return service.CheckYourSelf(other.service);
        }

        public void ChangeContent(string customer, string phone, string orderInfo, TimeSpan orderTime)
        {
            Customer = customer;
            Phone = phone;
            OrderInfo = orderInfo;
            OrderTime = orderTime;
        }
        public void ChangeContent(TimeSpan orderTime)
        {
            OrderTime = orderTime;
        }


        public override string ToString()
        {
            return String.Format("Заказ: {0}, {1}, {2}, {3}", OrderTime, Customer, Phone, OrderInfo);
        }
    }
}
