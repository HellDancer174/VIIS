using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Staff.ValueClasses.Decorators
{
    public class DecoratableAddress : Address
    {
        private readonly Address other;

        public DecoratableAddress(Address other) : base(other)
        {
            this.other = new Address(other);
        }
    }
}
