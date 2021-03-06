using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Data.DBObjects;
using VIIS.API.GlobalModel;
using VIIS.API.Orders;
using VIIS.Domain.Services;
using VIIS.Domain.Services.Decorators;

namespace VIIS.API.ServicesDir
{
    public class DBService : ServiceDecorator, IEquatable<ServicesTt>
    {
        private readonly DBQuery<ServicesTt> query;
        private readonly DBServiceValue serviceValue;
        //private readonly DBOrder dBOrder;
        private readonly ServicesTt entity;
        private readonly OrdersTt order;

        public DBService(Service other, DBQuery<ServicesTt> query, DBOrder dBOrder) : base(other)
        {
            this.query = query;
            this.serviceValue = new DBServiceValue(this, new AnyDBQuery<ServiceValuesTs>());
            //this.dBOrder = dBOrder;
            entity = new ServicesTt(serviceValue.Key, dBOrder.Key, timeSpan);
        }
        public DBService(Service other, OrdersTt order):base(other)
        {
            this.order = order;
            entity = new ServicesTt(id, order.Id, timeSpan);
            if(entity.OrderId == 0) entity.Order = order;
        }

        public bool Equals(ServicesTt other)
        {
            return entity.OrderId == other.OrderId && entity.ServiceValueId == other.ServiceValueId;
        }

        //public override void Transfer()
        //{
        //    if (entity.OrderId == 0 || entity.ServiceValueId == 0) throw new ArgumentException("ID == 0");
        //    //query.Transfer(entity);
        //}

        public ServicesTt Entity()
        {
            if ((entity.OrderId == 0 && entity.Order == null) || (entity.ServiceValue == null && entity.ServiceValueId == 0)) throw new ArgumentException("ID == 0");
            else return entity;

        }
    }
}
