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
        protected readonly DateTime ordersDate;
        protected decimal sale;

        public Order(Client client, List<Service> services, Master master, string comment, DateTime ordersDate, decimal sale)
        {
            this.client = client;
            this.services = services;
            this.master = master;
            this.comment = comment;
            this.ordersDate = ordersDate;
            this.sale = sale;
        }
        public Order(Client client, List<Service> services, Master master, string comment, DateTime ordersDate):
            this(client, services, master, comment, ordersDate, services.Select(service => service.Sale).Sum())
        {
        }

        public Order(Order other) : this(other.client, other.services, other.master, other.comment, other.ordersDate, other.sale)
        {
        }


        public Order(Master master, DateTime orderDate): this(new Client(), new List<Service>(), master, "", orderDate.Date, 0)
        {
        }


        public bool CheckYourSelf(Order other)
        {
            foreach(var service in services)
            {
                foreach(var otherServices in other.services)
                {
                    if(service.CheckYourSelf(otherServices) == false) return false;
                }
            }
            return !client.Equals(other.client) && !master.Equals(other.master);
        }
        public bool CheckDate(DateTime date) => ordersDate.Date == date.Date;

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
            client.Transfer();
        }

        public bool Equals(Order other)
        {
            //Проверить сервисы
            return client == other.client && master == other.master && client == other.client;
        }

        public bool IsEmpty => client.Equals(new AnyClient()) && services.Count == 0 && string.IsNullOrEmpty(comment) && sale == 0;

        public bool IsIncomplete => client.IsIncomplete ||services.Count == 0 || ordersDate == new DateTime() || sale == 0 || master.IsIncomplete || !master.IsWork(ordersDate);

        public bool IsOwner(Master master)
        {
            return this.master.Equals(master);
        }

        public decimal CashOfMaster(MastersPercent percent)
        {
            return percent.CashOfMaster(sale);
        }

        public decimal CashOfMaster() => CashOfMaster(new MastersPercent());

        public override string ToString()
        {
            return String.Format("Заказ от {0}; Клиент - {1}; Мастер - {2}, Сервисы - {3}", ordersDate, client.ToString(), master.ToString(), services.Count);
        }
    }
}
