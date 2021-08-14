using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.Finance.ViewModels;
using VIIS.App.GlobalViewModel;
using VIIS.App.OrdersJournal.Models.OrdersDecorators;
using VIIS.App.OrdersJournal.OrderDetail.ViewModels;
using VIIS.App.OrdersJournal.OrderDetail.Views;
using VIIS.App.Services.ViewModels;
using VIIS.Domain.Customers;
using VIIS.Domain.Finance;
using VIIS.Domain.Orders;
using VIIS.Domain.Orders.Decorators;
using VIIS.Domain.Services;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class PageOrder : OrderDecorator, IComparable<PageOrder>
    {
        //private readonly BaseViewService service;
        private readonly ViewClient viewClient;
        private readonly ServiceValueList serviceValueList;
        private readonly Clients clients;

        public PageOrder(Order other, ServiceValueList serviceValueList, Clients clients) : base(other)
        {
            viewClient = new ViewClient(person);
            this.serviceValueList = serviceValueList;
            this.clients = clients;
        }

        public string Customer => viewClient.FullName;
        public string Phone => viewClient.Phone;
        public string OrderInfo => string.Join(", ", services.Select(service => service.ToString()));


        public int ContentIndex()
        {
            return ordersStart.TimeOfDay.Hours;
        }

        public bool IsOwnerIndex(int index)
        {
            return index == ordersStart.TimeOfDay.Hours;
        }

        public bool CheckOrders(PageOrder other)
        {
            var finish = OrdersFinish();
            var otherFinish = other.OrdersFinish();
            return !(ordersStart >= other.ordersStart && ordersStart < otherFinish) && !(finish > other.ordersStart && finish <= otherFinish);

        }

        protected DateTime OrdersFinish()
        {
            var ordersFinish = ordersStart;
            foreach (var service in services)
                ordersFinish = ordersFinish.Date + service.TimesSum(ordersFinish.TimeOfDay);
            return ordersFinish;
        }

        public virtual void ShowDetail(Journal journal, ViewRepository<ViewTransaction, Transaction> transactions)
        {
            new WindowOrderDetail(new OrderDetailVM(this, journal, serviceValueList, clients, transactions), new OrderDetailView());
        }
        public override string ToString()
        {
            return String.Format("Заказ: {0}, {1}, {2}, {3}", ordersStart, Customer, Phone, string.Join(", " ,services.Select(service => service.ToString())));
        }

        //public bool Equals(Service other)
        //{
        //    return service.Equals(other);
        //}

        public int CompareTo(PageOrder other)
        {
            return ordersStart.CompareTo(other.ordersStart);
        }
    }
}
