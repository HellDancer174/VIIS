using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Orders.Decorators.Checkable
{
    public class BaseCheckableOrder : CheckableOrder
    {
        protected readonly CheckableOrder checkableOther;

        public BaseCheckableOrder(CheckableOrder checkableOther) : base(checkableOther)
        {
            this.checkableOther = checkableOther;
        }
    }
}
