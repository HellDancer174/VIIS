using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Services
{
    public class Service: ServiceValue, IDocument
    {
        protected readonly TimeSpan start;
        protected readonly TimeSpan timeSpan;

        public Service(string name, decimal sale, TimeSpan start, TimeSpan timeSpan): base(name, sale)
        {
            this.start = start;
            this.timeSpan = timeSpan;
        }
        public Service(ServiceValue serviceValue, TimeSpan start, TimeSpan timeSpan): base(serviceValue)
        {
            this.start = start;
            this.timeSpan = timeSpan;
        }
        public Service(Service other) : base(other.name, other.sale)
        {
            start = other.start;
            timeSpan = other.timeSpan;
        }

        public bool CheckTime(int timeIndex)
        {
            return start.Hours == timeIndex;
        }

        public bool CheckYourSelf(Service other)
        {
            var finish = start + timeSpan;
            var otherFinish = other.start + timeSpan;
            return !(start >= other.start && start < otherFinish) && !(finish > other.start && finish <= otherFinish);
        }


        public virtual void Transfer()
        {
            return;
        }

    }
}
