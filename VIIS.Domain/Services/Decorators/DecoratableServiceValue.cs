using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Services.Decorators
{
    public class DecoratableServiceValue : ServiceValue
    {
        protected readonly ServiceValue other;

        public DecoratableServiceValue(ServiceValue other) : base(other)
        {
            this.other = other;
        }
    }
}
