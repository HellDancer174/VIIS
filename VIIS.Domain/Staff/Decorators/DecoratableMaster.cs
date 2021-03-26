using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Staff.Decorators
{
    public class DecoratableMaster : Master
    {
        protected readonly Master other;

        public DecoratableMaster(Master other) : base(other)
        {
            this.other = new Master(other);
        }
    }
}
