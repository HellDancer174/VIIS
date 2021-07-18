using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Finance
{
    public class DecoratableTransaction : Transaction
    {
        protected readonly Transaction other;

        public DecoratableTransaction(Transaction other) : base(other)
        {
            this.other = other; //Убрал new
        }
    }
}
