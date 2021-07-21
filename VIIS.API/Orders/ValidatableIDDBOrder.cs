using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.GlobalModel;

namespace VIIS.API.Orders
{
    public class ValidatableIDDBOrder : TDBOrder
    {
        private readonly TDBOrder dBOrder;

        public ValidatableIDDBOrder(TDBOrder dBOrder) : base(dBOrder)
        {
            this.dBOrder = dBOrder;
        }

        public override void Transfer()
        {
            new ValidID(id).Validate();
            dBOrder.Transfer();
        }
    }
}
