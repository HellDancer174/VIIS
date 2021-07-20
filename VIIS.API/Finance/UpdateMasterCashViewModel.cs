using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.Domain.Finance;

namespace VIIS.API.Finance
{
    public class UpdateMasterCashViewModel
    {
        public UpdateMasterCashViewModel(MasterCash oldMasterCash, MasterCash newMasterCash)
        {
            OldMasterCash = oldMasterCash;
            NewMasterCash = newMasterCash;
        }

        public MasterCash OldMasterCash { get; }
        public MasterCash NewMasterCash { get; }
    }
}
