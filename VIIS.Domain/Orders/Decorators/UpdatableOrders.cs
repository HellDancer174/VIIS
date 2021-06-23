using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Orders.Decorators
{
    public class UpdatableOrders : OrdersDecorator
    {
        public UpdatableOrders(Orders other) : base(other)
        {
        }

        protected virtual async Task UpdateAsync()
        {
            await Task.CompletedTask;
        }
    }
}
