using ElegantLib.Validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Data.DBObjects;
using VIIS.API.GlobalModel;

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
            new Catcher<ArgumentNullException>(() => context.EmployeesTt.Single(emp => emp.Id == entity.MasterId),
                (ex) => throw new InvalidOperationException(String.Format("Мастера с id:{0} не найдено. Исключение:{1}.", entity.MasterId, ex.Message))).Execute();
                            
            var serviceValuesID = dbServices.Entities().Select(service => service.ServiceValueId).ToList();
            foreach (var serviceID in serviceValuesID)
            {
                new Catcher<ArgumentNullException>(() => context.ServiceValuesTs.Single(serviceValue => serviceValue.Id == serviceID),
                (ex) => throw new InvalidOperationException(String.Format("Сервиса с id:{0} не найдено. Исключение:{1}.", serviceID, ex.Message))).Execute();
            }
            dBOrder.Transfer();
        }
    }
}
