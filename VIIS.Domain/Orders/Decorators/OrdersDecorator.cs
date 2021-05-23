using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Orders.Decorators
{
    public class OrdersDecorator : Orders
    {
        protected readonly Orders other;

        public OrdersDecorator(Orders other) : base(other)
        {
            this.other = new Orders(other);
        }
    }
}
