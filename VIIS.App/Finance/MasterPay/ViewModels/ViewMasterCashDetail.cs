using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.GlobalViewModel;
using VIIS.App.Staff.ViewModels;
using VIIS.Domain.Finance;

namespace VIIS.App.Finance.MasterPay.ViewModels
{
    public class ViewMasterCashDetail : ViewDetail<ViewMasterCashList, ViewMasterCash, MasterCash>
    {
        public ViewMasterCashDetail(ViewMasterCashList repository, ViewMasterCash viewModel, List<ViewEmployee> masters) : base(repository, 
            new ViewAdditionalMasterCash(viewModel, masters), new ViewAdditionalMasterCash(viewModel, masters))
        {
        }
    }
}
