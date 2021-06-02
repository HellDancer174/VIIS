using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Finance.Decorators
{
    public class MasterCashTransaction : DecoratableTransaction
    {
        private readonly MasterCash masterCash;

        public MasterCashTransaction(Transaction other, MasterCash masterCash) : base(other)
        {
            this.masterCash = masterCash;
        }

        public override async Task Transfer()
        {
            await Task.CompletedTask;
        }
    }
}
