using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Data.DBObjects;

namespace VIIS.API.Orders
{
    public class ValidDBOrder : TDBOrder
    {
        private readonly TDBOrder dBOrder;
        private readonly VIISDBContext context;

        public ValidDBOrder(TDBOrder dBOrder, VIISDBContext context) : base(dBOrder)
        {
            this.dBOrder = dBOrder;
            this.context = context;
        }

        public override void Transfer()
        {
            try
            {
                context.EmployeesTt.Single(emp => emp.Id == entity.MasterId);
                var serviceValuesID = dbServices.Entities().Select(service => service.ServiceValueId).ToList();
                var findedServiceValuesID = context.ServiceValuesTs.Where(serviceValue => serviceValuesID.Contains(serviceValue.Id)).ToList();
                foreach(var serviceID in serviceValuesID)
                {
                    if(!context.ServiceValuesTs.Si)
                }
            }
            catch (Exception)
            {
                
            }
            dBOrder.Transfer();
        }
    }
}
