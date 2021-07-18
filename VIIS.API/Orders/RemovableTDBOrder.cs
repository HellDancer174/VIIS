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
    public class RemovableTDBOrder : TDBOrder
    {
        public RemovableTDBOrder(Order other, DBQuery<OrdersTt> query, DBQuery<ServicesTt> serviceQuery) : base(other, query, serviceQuery)
        {
        }

        public override void Transfer()
        {
            //var dbServices = services.Select(service => new DBService(service, serviceQuery, this)).ToArray();
            //foreach (var service in dbServices)
            //    service.Transfer();
            dbServices.Transfer();
            base.Transfer();
        }
    }
}
