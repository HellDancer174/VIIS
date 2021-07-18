using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Data.DBObjects;
using VIIS.API.GlobalModel;
using VIIS.Domain.Orders;

namespace VIIS.API.Orders
{
    public class AddOrUpdatableTDBOrder : TDBOrder
    {
        public AddOrUpdatableTDBOrder(Order other, DBQuery<OrdersTt> query, DBQuery<ServicesTt> serviceQuery) : base(other, query, serviceQuery)
        {
        }

        public override void Transfer()
        {
            base.Transfer();
            dbServices.Transfer();
        }
    }
}
