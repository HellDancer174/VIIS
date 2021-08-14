using ElegantLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Services
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Service: ServiceValue, IDocument, IEquatable<Service>, IComparable<Service>
    {
        [JsonProperty("service_orderStart")] protected DateTime ordersStart;
        [JsonProperty] protected TimeSpan timeSpan;

        public Service(string name, decimal sale, DateTime ordersStart, TimeSpan timeSpan): this(0, name, sale, ordersStart, timeSpan)
        {
        }
        public Service(int id, string name, decimal sale, DateTime ordersStart, TimeSpan timeSpan): base(id, name, sale)
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
        public Service(Service other) : base(other.id, other.name, other.sale)
        {
            ordersStart = other.ordersStart;
            timeSpan = other.timeSpan;
        }
        public Service(): base()
        {
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
        public TimeSpan TimesSum(TimeSpan other)
        {
            return this.timeSpan + other;
        }

        public bool Equals(Service other)
        {
            return id == other.id;
/*            return other.ordersStart == ordersStart && other.timeSpan == timeSpan && other.name == name*/;
        }

        public int CompareTo(Service other)
        {
            return ordersStart.CompareTo(other.ordersStart);
        }

        public virtual void Transfer()
        {
            return;
        }

        public override bool Equals(object obj)
        {
            var service = obj as Service;
            return obj is Service && Equals(service);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
            //var hashCode = -1661691646;
            //hashCode = hashCode * -1521134295 + base.GetHashCode();
            //hashCode = hashCode * -1521134295 + ordersStart.GetHashCode();
            //hashCode = hashCode * -1521134295 + EqualityComparer<TimeSpan>.Default.GetHashCode(timeSpan);
            //return hashCode;
        }
    }
}
