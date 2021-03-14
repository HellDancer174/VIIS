using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Orders
{
    public class OrderTime
    {
        private readonly TimeSpan start;
        private readonly TimeSpan finish;

        public OrderTime(TimeSpan start, TimeSpan finish)
        {
            this.start = start;
            this.finish = finish;
        }
        public OrderTime(TimeSpan start, int timeInMinutes) : this(start, start.Add(new TimeSpan(0, timeInMinutes, 0)))
        {
        }
        public virtual bool CheckYourSelf(OrderTime other)
        {
            return true;
        }
    }
}
