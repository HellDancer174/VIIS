using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.GlobalViewModel;
using VIIS.Domain.Finance;
using VIMVVM;

namespace VIIS.App.Finance.MasterPay.ViewModels
{
    public class ViewMasterCashDetail : ViewDetail<ViewMasterCashList, ViewMasterCash, MasterCash>
    {
        public ViewMasterCashDetail(ViewMasterCashList repository, ViewMasterCash viewModel) : base(repository, new ViewMasterCash(viewModel), viewModel)
        {
        }

        public override RelayCommand Save => new RelayCommand(async (obj) =>
        {
            await repository.UpdateViewAsync(oldViewModel, new ViewMasterCash(ViewModel.Model()));
            ViewModel.NotifySelector();
        });
    }
}
