using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Orders.Decorators
{
    public class OrderDecorator : Order
    {
        protected readonly Order primary;

        public OrderDecorator(Order other) : base(other)
        {
            this.primary = other;
        }
    }
}
