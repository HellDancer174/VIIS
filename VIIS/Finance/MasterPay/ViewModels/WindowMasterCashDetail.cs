using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIIS.App.Finance.MasterPay.Views;
using VIIS.App.GlobalViewModel;
using VIIS.Domain.Finance;

namespace VIIS.App.Finance.MasterPay.ViewModels
{
    public class WindowMasterCashDetail : ViewWindowDetail<ViewMasterCashList, ViewMasterCash, MasterCash>
    {
        public WindowMasterCashDetail(ViewMasterCashList repository, ViewMasterCash viewModel) : base(new ViewMasterCashDetail(repository, viewModel), new MasterCashDetailView())
        {
        }
    }
}
