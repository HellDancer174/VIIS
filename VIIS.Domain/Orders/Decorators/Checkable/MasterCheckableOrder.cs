using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Staff;

namespace VIIS.Domain.Orders.Decorators.Checkable
{
    public class MasterCheckableOrder : BaseCheckableOrder
    {
        private readonly Master checkableMaster;

        public MasterCheckableOrder(CheckableOrder order, Master master) : base(order)
        {
            this.checkableMaster = master;
        }

        public override bool Check()
        {
            return master.Equals(checkableMaster) && checkableOther.Check();
        }
    }
}
