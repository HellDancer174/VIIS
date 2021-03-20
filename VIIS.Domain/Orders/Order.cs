using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Clients;
using VIIS.Domain.Services;

namespace VIIS.Domain.Orders
{
    public class Order: IDocument
    {
        protected readonly Client client;
        protected readonly List<Service> services;
        protected string comment;

        public Order(Client client, List<Service> services, string comment)
        {
            this.client = client;
            this.services = services;
            this.comment = comment;
        }

        public Order(Order other)
        {
            client = other.client;
            services = other.services;
            comment = other.comment;
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
            return !client.Equals(other.client);
        }

        public virtual void Transfer()
        {
            client.Transfer();
        }
    }
}
