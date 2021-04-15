using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Orders;
using VIIS.Domain.Staff;

namespace VIIS.App.Staff.Models
{
    public class MastersOrderPerMonth : Master
    {
        private readonly Orders orders;

        public MastersOrderPerMonth(Master other, Orders orders) : base(other)
        {
            this.orders = orders.OrdersOfMaster(this);

        }
    }
}
