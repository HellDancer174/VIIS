using ElegantLib;
using ElegantLib.Collections;
using ElegantLib.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Customers;
using VIIS.Domain.Staff;
using VIIS.Domain.Services;
using VIIS.Domain.Staff.ValueClasses;
using VIMVVM;
using VIIS.Domain.Orders.Decorators;
using VIIS.Domain.Orders.Decorators.Checkable;

namespace VIIS.Domain.Orders
{
    public class Orders : VirtualObservableCollection<Order>, IDocumentAsync
    {
        //protected readonly VirtualCollection<Order> ordersList;

        public Orders(List<Order> orders): base(orders)
        {
        }
        public Orders(Orders other): base(other)
        {
        }
        public Orders(Master testMaster): 
            base(new VirtualCollection<Order>(new List<Order>()
            {
                new Order(new Client("Виктор", "Игнатьев", "", "265664699589"), new List<Service>() { new Service("Стрижка", 500, DateTime.Now.Date + new TimeSpan(9, 10, 0), new TimeSpan(0,30,0)) }, testMaster, "", DateTime.Now.Date + new TimeSpan(9,10,0)),
                new Order(new Client("Виктор", "Кот", "", "16542389"), new List<Service>() { new Service("Стрижка", 500, DateTime.Now.Date + new TimeSpan(9,40,0), new TimeSpan(0,30,0)) }, testMaster,"", DateTime.Now.Date + new TimeSpan(9,40,0)),
                new Order(new Client("Виктор", "Игнатов", "", "268596564"), new List<Service>() { new Service("Стрижка", 500, DateTime.Now.Date + new TimeSpan(10,10,0), new TimeSpan(0,30,0)) }, testMaster,"", DateTime.Now.Date + new TimeSpan(10,10,0))

            }))
        {
        }

        public Orders(IList<Order> orders, DateTime startDate, DateTime finishDate, Master master):
            this(orders.Select(order => new MasterCheckableOrder(new DateSpanCheckableOrder(new CheckableOrder(order), startDate, finishDate), master)).Where(checkableOrder => checkableOrder.Check()).Select(checkableOrder => (Order)checkableOrder).ToList())
        {

        }
        public Orders(IList<Order> orders, DateTime monthOfYear, Master master): 
            this(orders, new DateTime(monthOfYear.Year, monthOfYear.Month, 1), new DateTime(monthOfYear.Year, monthOfYear.Month, DateTime.DaysInMonth(monthOfYear.Year, monthOfYear.Month)), master)
        {
        }


        public virtual async Task AddAsync(Order order)
        {
            Add(order);
            //Отправить на сервер
            await Task.CompletedTask;
        }

        public virtual async Task Update(Order oldOrder, Order newOrder)
        {
            var index = IndexOf(oldOrder);
            this[index] = newOrder;
            //Отправить на сервер
            await Task.CompletedTask;
        }

        public virtual async Task RemoveAsync(Order order)
        {
            Remove(order);
            //Отправить на сервер
            await Task.CompletedTask;
        }

        public Orders OrdersOfMaster(Master master) => new Orders(this.Where(order => order.IsOwner(master)).ToList());

        public decimal TotalSale => this.Sum(order => order.Sale);

        public virtual Task TransferAsync()
        {
            return Task.CompletedTask;
        }
    }
}
