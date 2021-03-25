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
        protected readonly decimal sale;

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

        public Order(Master master, DateTime orderDate): this(new Client(), new List<Service>(), master, "", orderDate.Date, 0)
        {
        }

        public Order(Order other)
        {
            client = other.client;
            services = other.services;
            comment = other.comment;
            master = other.master;
            ordersDate = other.ordersDate;
            sale = other.sale;
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
    }
}
