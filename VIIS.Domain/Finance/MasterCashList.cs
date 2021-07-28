using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Finance
{
    public class MasterCashList : List<MasterCash>, IDocumentAsync
    {
        public MasterCashList(IEnumerable<MasterCash> collection) : base(collection)
        {
        }

        public virtual Task TransferAsync()
        {
            throw new NotImplementedException();
        }
    }
}
