using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VIIS.API.Data.DBObjects;
using VIIS.API.GlobalModel;
using VIIS.API.Orders;

namespace VIIS.API.ServicesDir
{
    public class UpdateServicesDBQuery : UpdatableDBQuery<ServicesTt>
    {
        private readonly DBOrder dBOrder;

        public UpdateServicesDBQuery(DbSet<ServicesTt> collection, VIISDBContext context, DBOrder dBOrder) : base(collection, context)
        {
            this.dBOrder = dBOrder;
        }
        public UpdateServicesDBQuery(VIISDBContext context, DBOrder dBOrder): this(context.ServicesTt, context, dBOrder)
        {

        }

        protected override void ExecuteCommand(IEnumerable<ServicesTt> entities)
        {
            collection.RemoveRange(collection.Where(service => service.OrderId == dBOrder.Key).ToArray());
            context.SaveChanges();
            collection.AddRange(entities);
        }
    }
}
