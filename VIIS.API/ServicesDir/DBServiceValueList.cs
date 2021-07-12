using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Data.DBObjects;
using VIIS.Domain.Services;

namespace VIIS.API.ServicesDir
{
    public class DBServiceValueList : ServiceValueList
    {
        public DBServiceValueList(List<ServiceValue> services) : base(services)
        {
        }
        public DBServiceValueList(VIISDBContext context): this(context.ServiceValuesTs.Select(entity => new ServiceValue(entity.Id, entity.Name, entity.Sale)).ToList())
        {
        }
    }
}
