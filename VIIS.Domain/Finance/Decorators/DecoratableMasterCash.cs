using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Finance.Decorators
{
    public class DecoratableMasterCash : MasterCash
    {
        protected readonly MasterCash other;

        public DecoratableMasterCash(MasterCash other) : base(other)
        {
            this.other = other;
        }
    }
}
