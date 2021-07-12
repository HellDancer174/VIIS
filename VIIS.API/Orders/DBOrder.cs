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

namespace VIIS.API.Orders
{
    public class DBOrder : OrderDecorator
    {
        private readonly DBQuery<OrdersTt> query;
        private readonly DBQuery<ServicesTt> serviceQuery;
        private readonly OrdersTt entity;
        private TDBClient dBClient;
        private DBMaster dBMaster;

        public DBOrder(Order other, DBQuery<OrdersTt> query, DBQuery<ServicesTt> serviceQuery, DBQuery<PersonsTt> personquery, DBQuery<AddressesTt> addressquery) : base(other)
        {
            this.query = query;
            this.serviceQuery = serviceQuery;
            dBClient = new TDBClient(client, personquery, addressquery);
            dBMaster = new DBMaster(master);
            entity = new OrdersTt(id, dBClient.Key, dBMaster.Key, ordersStart, sale, Convert.ToInt32(isFinished), comment);
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
                dBClient.Transfer();
                entity.ClientId = dBClient.Key;
            }
            query.Transfer(entity);
            var dbServices = services.Select(service => new DBService(service, serviceQuery, this)).ToArray();
            foreach (var service in dbServices)
                service.Transfer();

        }

        public int Key => entity.Id;
    }
}
