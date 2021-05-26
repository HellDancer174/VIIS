using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Services
{
    public class Service: ServiceValue, IDocument, IEquatable<Service>, IComparable<Service>
    {
        protected DateTime ordersStart;
        protected TimeSpan timeSpan;

        public Service(string name, decimal sale, DateTime ordersStart, TimeSpan timeSpan): base(name, sale)
        {
            this.ordersStart = ordersStart;
            this.timeSpan = timeSpan;
        }
        public Service(ServiceValue serviceValue, DateTime ordersStart, TimeSpan timeSpan): base(serviceValue)
        {
            this.ordersStart = ordersStart;
            this.timeSpan = timeSpan;
        }
        public Service(ServiceValue serviceValue): this(serviceValue, new DateTime(1900, 1, 1), new TimeSpan())
        {
        }
        public Service(Service other) : base(other.name, other.sale)
        {
            ordersStart = other.ordersStart;
            timeSpan = other.timeSpan;
        }

        //public bool CheckTime(int timeIndex)
        //{
        //    return ordersStart.TimeOfDay.Hours == timeIndex;
        //}

        //public bool CheckYourSelf(Service other)
        //{
        //    var finish = ordersStart + timeSpan;
        //    var otherFinish = other.ordersStart + timeSpan;
        //    return !(ordersStart >= other.ordersStart && ordersStart < otherFinish) && !(finish > other.ordersStart && finish <= otherFinish);
        //}
        public TimeSpan TimesSummary(TimeSpan other)
        {
            return this.timeSpan + other;
        }

        public bool Equals(Service other)
        {
            return other.ordersStart == ordersStart && other.timeSpan == timeSpan && other.name == name;
        }

        public int CompareTo(Service other)
        {
            return ordersStart.CompareTo(other.ordersStart);
        }

        public virtual void Transfer()
        {
            return;
        }
    }
}
