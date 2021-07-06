using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Customers;
using VIIS.Domain.Staff;
using VIIS.Domain.Services;
using VIMVVM;
using VIIS.Domain.Staff.ValueClasses;

namespace VIIS.Domain.Orders
{
    public class Order: Notifier, IDocument, IEquatable<Order>
    {
        protected readonly Client client;
        protected readonly List<Service> services;
        protected readonly Master master;
        protected string comment;
        protected DateTime ordersStart;
        protected decimal sale;
        protected bool isFinished;

        public Order(Client client, List<Service> services, Master master, string comment, DateTime ordersDate, decimal sale):
            this(client, services, master, comment, ordersDate, sale, false)
        {
        }
        public Order(Client client, List<Service> services, Master master, string comment, DateTime ordersDate, decimal sale, bool isFinished)
        {
            this.client = client;
            this.services = services;
            this.master = master;
            this.comment = comment;
            this.ordersStart = ordersDate;
            this.sale = sale;
            this.isFinished = isFinished;
        }
        public Order(Client client, List<Service> services, Master master, string comment, DateTime ordersDate):
            this(client, services, master, comment, ordersDate, services.Select(service => service.Sale).Sum())
        {
        }

        public Order(Order other) : this(other.client, other.services, other.master, other.comment, other.ordersStart, other.sale, other.isFinished)
        {
        }


        public Order(Master master, DateTime orderDate): this(new Client(), new List<Service>(), master, "", orderDate.Date, 0)
        {
        }


        //public bool CheckYourSelf(Order other)
        //{
        //    var finish = OrdersFinish();
        //    var otherFinish = other.OrdersFinish();
        //    return !(ordersStart >= other.ordersStart && ordersStart < otherFinish) && !(finish > other.ordersStart && finish <= otherFinish);

        //    return !client.Equals(other.client) && !master.Equals(other.master);
        //}
        public bool CheckDate(DateTime date) => ordersStart.Date == date.Date;

        public string MasterName()
        {
            return master.FullName;
        }

        public virtual KeyValuePair<Master, Order> KeyValue()
        {
            return new KeyValuePair<Master, Order>(master, this);
        }

        public virtual void Transfer()
        {
            client.TransferAsync();
        }

        public bool Equals(Order other)
        {
            //Проверить сервисы
            return client == other.client && master == other.master && client == other.client;
        }

        public bool IsEmpty => client.Equals(new AnyClient()) && services.Count == 0 && string.IsNullOrEmpty(comment) && sale == 0;

        public bool IsIncomplete => client.IsIncomplete ||services.Count == 0 || ordersStart == new DateTime() || sale == 0 || master.IsIncomplete || !master.IsWork(ordersStart);

        public bool IsOwner(Master master)
        {
            return this.master.Equals(master);
        }

        public decimal CashOfMaster(MastersPercent percent)
        {
            return percent.CashOfMaster(sale);
        }

        public decimal CashOfMaster() => CashOfMaster(new MastersPercent());

        public decimal Sale => sale;

        public override string ToString()
        {
            return String.Format("Заказ от {0}; Клиент - {1}; Мастер - {2}, Сервисы - {3}", ordersStart, client.ToString(), master.ToString(), services.Count);
        }
    }
}
