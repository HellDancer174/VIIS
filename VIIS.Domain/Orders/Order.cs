using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Clients;
using VIIS.Domain.Employees;
using VIIS.Domain.Services;

namespace VIIS.Domain.Orders
{
    public class Order: IDocument
    {
        protected readonly Client client;
        protected readonly List<Service> services;
        protected readonly Master master;
        protected string comment;

        public Order(Client client, List<Service> services, Master master, string comment)
        {
            this.client = client;
            this.services = services;
            this.master = master;
            this.comment = comment;
        }

        public Order(Order other)
        {
            client = other.client;
            services = other.services;
            comment = other.comment;
            master = other.master;
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

        public virtual KeyValuePair<string, Order> KeyValue()
        {
            return new KeyValuePair<string, Order>(master.ToString(), this);
        }

        public virtual void Transfer()
        {
            client.Transfer();
        }
    }
}
