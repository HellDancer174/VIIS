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

        public UpdateServicesDBQuery(DbSet<ServicesTt> collection, VIISDBContext context) : base(collection, context)
        {
        }
        public UpdateServicesDBQuery(VIISDBContext context): this(context.ServicesTt, context)
        {

        }

        protected override void ExecuteCommand(IEnumerable<ServicesTt> entities)
        {
            var orderID = entities.First().OrderId;
            collection.RemoveRange(collection.Where(service => service.OrderId == orderID).ToArray());
            context.SaveChanges();
            context.ServicesTt.AddRange(entities);
        }
    }
}
