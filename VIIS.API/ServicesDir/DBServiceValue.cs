using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Data.DBObjects;
using VIIS.API.GlobalModel;
using VIIS.Domain.Services;
using VIIS.Domain.Services.Decorators;

namespace VIIS.API.ServicesDir
{
    public class DBServiceValue : DecoratableServiceValue, IDocument
    {
        private readonly DBQuery<ServiceValuesTs> query;
        private readonly ServiceValuesTs entity;

        public DBServiceValue(ServiceValue other, DBQuery<ServiceValuesTs> query) : base(other)
        {
            this.query = query;
            entity = new ServiceValuesTs(id, name, sale);
        }
        public DBServiceValue(DBServiceValue other): this(other, other.query)
        {
        }

        public int Key => entity.Id;

        public virtual void Transfer()
        {
            query.Transfer(entity);
        }
    }
}
