using ElegantLib;
using ElegantLib.Collections;
using ElegantLib.Documents;
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
    public class Orders : IDocumentAsync
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
                new Order(new Client("Виктор", "Игнатьев", "", "265664699589"), new List<Service>() { new Service("Стрижка", 500, DateTime.Now.Date+new TimeSpan(9,10,0), new TimeSpan(0,30,0)) }, new Master("Игнатьева", "Валентина", "Иониктовна", ""), ""),
                new Order(new Client("Виктор", "Кот", "", "16542389"), new List<Service>() { new Service("Стрижка", 500, DateTime.Now.Date+new TimeSpan(9,40,0), new TimeSpan(0,30,0)) }, new Master("Игнатьева", "Валентина", "Иониктовна", ""),""),
                new Order(new Client("Виктор", "Игнатов", "", "268596564"), new List<Service>() { new Service("Стрижка", 500, DateTime.Now.Date+new TimeSpan(10,10,0), new TimeSpan(0,30,0)) }, new Master("Игнатьева", "Валентина", "Иониктовна", ""),"")

            });
        }
        public virtual async Task Transfer()
        {
            await new AnyAsyncDocument().Transfer();
        }
    }
}
