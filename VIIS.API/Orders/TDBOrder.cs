using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Customers.Models;
using VIIS.API.Data.DBObjects;
using VIIS.API.Employees.Models;
using VIIS.API.GlobalModel;
using VIIS.API.ServicesDir;
using VIIS.Domain.Orders;
using VIIS.Domain.Orders.Decorators;
using VIIS.Domain.Services;

namespace VIIS.API.Orders
{
    public class TDBOrder: OrderDecorator
    {
        protected readonly DBQuery<OrdersTt> query;
        protected readonly DBQuery<ServicesTt> serviceQuery;
        protected readonly OrdersTt entity;
        protected readonly DBServiceList dbServices;
        protected TDBClient dBClient;
        protected DBMaster dBMaster;

        public TDBOrder(Order other, DBQuery<OrdersTt> query, DBQuery<ServicesTt> serviceQuery/*, DBQuery<PersonsTt> personquery, DBQuery<AddressesTt> addressquery*/) : base(other)
        {
            this.query = query;
            this.serviceQuery = serviceQuery;
            dBClient = new TDBClient(person, new AnyDBQuery<PersonsTt>(), new AnyDBQuery<AddressesTt>());
            dBMaster = new DBMaster(master);
            entity = new OrdersTt(id, dBClient.Key, dBMaster.Key, ordersStart, sale, Convert.ToInt32(isFinished), comment);
            dbServices = new DBServiceList(services.Select(service => new DBService(service, entity)).ToList(), entity, serviceQuery);
        }
        public TDBOrder(OrdersTt entity) :
        this(new Order(entity.Id, new TDBClient(entity.Client),
        entity.ServicesTt.Select(service => new Service(new DBServiceValue(service.ServiceValue), entity.Start, service.TimeSpan)).ToList(),
        new DBMaster(entity.Master), entity.Comment, entity.Start, entity.Sale, Convert.ToBoolean(entity.IsFinished)),
        new AnyDBQuery<OrdersTt>(), new AnyDBQuery<ServicesTt>())
        {

        }

        public override void Transfer()
        {
            var dbServiceValues = services.Select(service => new DBServiceValue(service, new AnyDBQuery<ServiceValuesTs>())).ToList();
            var filtered = dbServiceValues.Where(serviceValue => serviceValue.Key > 0).ToList();
            if (filtered.Count != dbServiceValues.Count)
                throw new ArgumentException(String.Format("В заказе есть услуги, не существуюшие на сервере: {0}",
                    String.Join(", ", dbServiceValues.Where(serviceValue => serviceValue.Key < 1).Select(serviceValue => serviceValue.ToString()).ToArray())));
            if (entity.MasterId < 1) throw new ArgumentException("Такого мастера не существует");
            if (entity.ClientId < 1)
            {
                entity.Client = dBClient.Entity();
            }
            //entity.ServicesTt = dbServices.Entities();
            query.Transfer(entity);
            //var dbServices = services.Select(service => new DBService(service, serviceQuery, this)).ToArray();
            //foreach (var service in dbServices)
            //    service.Transfer();
        }
    }
}
