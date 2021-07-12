using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Services.Decorators
{
    public class ServiceDecorator : Service
    {
        protected readonly Service other;

        public ServiceDecorator(Service other) : base(other)
        {
            this.other = other;
        }
    }
}
