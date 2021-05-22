using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Orders.Decorators.Checkable
{
    public class CheckableOrder : OrderDecorator
    {

        public CheckableOrder(Order other) : base(other)
        {
        }

        public virtual bool Check() => true;

    }
}
