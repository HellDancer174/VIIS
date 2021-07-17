using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Data.DBObjects;
using VIIS.API.GlobalModel;
using VIIS.API.ServicesDir;
using VIIS.Domain.Orders;

namespace VIIS.API.Orders
{
    public class RemovableDBOrder : DBOrder
    {
        public RemovableDBOrder(Order other, DBQuery<OrdersTt> query, DBQuery<ServicesTt> serviceQuery) : base(other, query, serviceQuery, new AnyDBQuery<PersonsTt>(), new AnyDBQuery<AddressesTt>())
        {
        }

        public override void Transfer()
        {
            //var dbServices = services.Select(service => new DBService(service, serviceQuery, this)).ToArray();
            //foreach (var service in dbServices)
            //    service.Transfer();
            var dbServices = new DBServiceList(services.Select(service => new DBService(service, serviceQuery, this)).ToList(), this, serviceQuery);
            dbServices.Transfer();
            query.Transfer(entity);
        }
    }
}
