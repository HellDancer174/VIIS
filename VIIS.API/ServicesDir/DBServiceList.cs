using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Data.DBObjects;
using VIIS.API.GlobalModel;
using VIIS.API.Orders;
using VIIS.Domain.Services;

namespace VIIS.API.ServicesDir
{
    public class DBServiceList : ServiceList
    {
        private readonly IList<DBService> list;
        private readonly DBOrder dBOrder;
        private readonly DBQuery<ServicesTt> query;

        public DBServiceList(IList<DBService> list, DBOrder dBOrder, DBQuery<ServicesTt> query) : base(list.Select(dbservice => dbservice as Service).ToList())
        {
            this.list = list;
            this.dBOrder = dBOrder;
            this.query = query;
        }
        public DBServiceList(IList<DBService> list, DBOrder dBOrder): this(list, dBOrder, new UpdateServicesDBQuery(new VIISDBContext(), dBOrder))
        {

        }

        public override void Transfer()
        {
            query.Transfer(list.Select(service => service.Entity).ToArray());
        }
    }
}
