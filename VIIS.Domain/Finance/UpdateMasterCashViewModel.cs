using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIIS.Domain.Finance
{
    public class UpdateMasterCashViewModel: IDocumentAsync
    {
        public UpdateMasterCashViewModel(MasterCash oldMasterCash, MasterCash newMasterCash)
        {
            OldMasterCash = oldMasterCash;
            NewMasterCash = newMasterCash;
        }

        public MasterCash OldMasterCash { get; set; }
        public MasterCash NewMasterCash { get; set; }

        public Task TransferAsync()
        {
            throw new NotImplementedException();
        }
    }
}
