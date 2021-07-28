using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIIS.App.Finance.MasterPay.Views;
using VIIS.App.GlobalViewModel;
using VIIS.App.Staff.ViewModels;
using VIIS.Domain.Finance;

namespace VIIS.App.Finance.MasterPay.ViewModels
{
    public class WindowMasterCashDetail : ViewWindowDetail<ViewMasterCashList, ViewMasterCash, MasterCash>
    {
        public WindowMasterCashDetail(ViewMasterCashList repository, List<ViewEmployee> masters) : base(new ViewNewMasterCashDetail(repository, masters), new MasterCashDetailView())
        {
        }
        public WindowMasterCashDetail(ViewMasterCashList repository, ViewMasterCash selected, List<ViewEmployee> masters) : base(new ViewMasterCashDetail(repository, selected, masters), new MasterCashDetailView())
        {
        }

    }
}
