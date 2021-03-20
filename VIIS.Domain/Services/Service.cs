using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Services
{
    public class Service: IDocument
    {
        private readonly string name;
        protected readonly DateTime start;
        private readonly TimeSpan timeSpan;
        private readonly decimal sale;

        public Service(string name, decimal sale, DateTime start, TimeSpan timeSpan)
        {
            this.name = name;
            this.sale = sale;
            this.start = start;
            this.timeSpan = timeSpan;
        }
        public Service(Service other)
        {
            name = other.name;
            sale = other.sale;
            start = other.start;
            timeSpan = other.timeSpan;
        }

        public bool CheckTime(int timeIndex)
        {
            return start.Hour == timeIndex;
        }

        public bool CheckYourSelf(Service other)
        {
            var finish = start + timeSpan;
            var otherFinish = other.start + timeSpan;
            return !(start >= other.start && start <= otherFinish) && !(finish >= other.start && finish <= otherFinish);
        }

        public decimal Sale => sale;

        public virtual void Transfer()
        {
            return;
        }
    }
}
