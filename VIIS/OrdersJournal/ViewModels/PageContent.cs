using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Orders;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class PageContent
    {
        public string Customer { get; set; }
        public string Phone { get; set; }
        public string OrderInfo { get; set; }
        public TimeSpan OrderTime { get; set; }
        private OrderTime time = new Domain.Orders.OrderTime(new TimeSpan(), new TimeSpan());
        

        public PageContent(string customer, string phone, string orderInfo, TimeSpan orderTime)
        {
            Customer = customer;
            Phone = phone;
            OrderInfo = orderInfo;
            OrderTime = orderTime;
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
           return time.CheckYourSelf(other.time);
        }

        public override string ToString()
        {
            return String.Format("Заказ: {0}, {1}, {2}, {3}", OrderTime, Customer, Phone, OrderInfo);
        }
    }
}
