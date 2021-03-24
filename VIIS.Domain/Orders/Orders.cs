using ElegantLib;
using ElegantLib.Collections;
using ElegantLib.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Clients;
using VIIS.Domain.Staff;
using VIIS.Domain.Services;
using VIIS.Domain.Staff.ValueClasses;
using VIMVVM;

namespace VIIS.Domain.Orders
{
    public class Orders : Notifier, IDocumentAsync
    {
        protected readonly VirtualCollection<Order> ordersList;

        public Orders(List<Order> orders)
        {
            this.ordersList = new VirtualCollection<Order>(orders);
        }
        public Orders(Orders other)
        {
            ordersList = other.ordersList;
        }
        public Orders()
        {
            ordersList = new VirtualCollection<Order>(new List<Order>()
            {
                new Order(new Client("Виктор", "Игнатьев", "", "265664699589"), new List<Service>() { new Service("Стрижка", 500, new TimeSpan(9,10,0), new TimeSpan(0,30,0)) }, new Master(), "", DateTime.Now.Date),
                new Order(new Client("Виктор", "Кот", "", "16542389"), new List<Service>() { new Service("Стрижка", 500, new TimeSpan(9,40,0), new TimeSpan(0,30,0)) }, new Master(),"", DateTime.Now.Date),
                new Order(new Client("Виктор", "Игнатов", "", "268596564"), new List<Service>() { new Service("Стрижка", 500, new TimeSpan(10,10,0), new TimeSpan(0,30,0)) }, new Master(),"", DateTime.Now.Date)

            });
        }
        public virtual Task Transfer()
        {
            return Task.CompletedTask;
        }
    }
}
