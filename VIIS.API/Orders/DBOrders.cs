using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Data.DBObjects;
using VIIS.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using VIIS.Domain.Orders.Decorators;

namespace VIIS.API.Orders
{
    public class DBOrders : OrdersDecorator
    {

        public DBOrders(VIISDBContext context) : base(new Domain.Orders.Orders(context.OrdersTt
            .Include(order => order.Client).ThenInclude(client => client.Address)
            .Include(order => order.Master).ThenInclude(master => master.Person).ThenInclude(person => person.Address)
            .Include(order => order.Master).ThenInclude(master => master.Passport)
            .Include(order => order.Master).ThenInclude(master => master.WorkDaysTt)
            .Include(order => order.ServicesTt)
            .Select(order => new TDBOrder(ServiceLoad(order)) as Order).ToList()))
        {
        }

        private static OrdersTt ServiceLoad(OrdersTt ordersTt)
        {
            using (var context = new VIISDBContext())
            {
                ordersTt.ServicesTt = ordersTt.ServicesTt.Select(service =>
                {
                    service.ServiceValue = context.ServiceValuesTs.Single(value => value.Id == service.ServiceValueId);
                    return service;
                }).ToList();
                return ordersTt;
            }
        }
    }
}
