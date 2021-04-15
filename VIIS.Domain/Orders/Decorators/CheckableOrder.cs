using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Orders.Decorators
{
    public abstract class CheckableOrder<T> : OrderDecorator
    {
        public CheckableOrder(Order other) : base(other)
        {
        }

        public abstract bool Check(T value);

    }
}
