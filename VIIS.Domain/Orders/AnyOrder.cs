using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Staff;

namespace VIIS.Domain.Orders
{
    public class AnyOrder: Order
    {
        public AnyOrder(Master master, DateTime date): base(master, date)
        {
        }
    }
}
