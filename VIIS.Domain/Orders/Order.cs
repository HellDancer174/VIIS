using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Clients;
using VIIS.Domain.Staff;
using VIIS.Domain.Services;
using VIMVVM;

namespace VIIS.Domain.Orders
{
    public class Order: Notifier, IDocument, IEquatable<Order>
    {
        protected readonly Client client;
        protected readonly List<Service> services;
        protected readonly Master master;
        protected string comment;
        protected readonly DateTime ordersDate;

        public Order(Client client, List<Service> services, Master master, string comment, DateTime ordersDate)
        {
            this.client = client;
            this.services = services;
            this.master = master;
            this.comment = comment;
            this.ordersDate = ordersDate;
        }

        public Order(Master master, DateTime orderDate): this(new Client(), new List<Service>(), master, "", orderDate.Date)
        {
        }

        public Order(Order other)
        {
            client = other.client;
            services = other.services;
            comment = other.comment;
            master = other.master;
            ordersDate = other.ordersDate;
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

        public virtual KeyValuePair<string, Order> KeyValue()
        {
            return new KeyValuePair<string, Order>(master.ToString(), this);
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
    }
}
