using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Staff;

namespace VIIS.Domain.Orders.Decorators
{
    public class MasterCheckableOrder : CheckableOrder<Master>
    {
        public MasterCheckableOrder(Order order, Master master) : base(order, master)
        {
        }

        public override bool Check()
        {
            return master.Equals(checker) && checkableOther.Check();
        }
    }
}
