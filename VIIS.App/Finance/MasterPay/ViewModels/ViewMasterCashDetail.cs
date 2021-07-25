using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.GlobalViewModel;
using VIIS.App.Staff.ViewModels;
using VIIS.Domain.Finance;
using VIIS.Domain.Staff;
using VIMVVM;

namespace VIIS.App.Finance.MasterPay.ViewModels
{
    public class ViewMasterCashDetail : ViewNewDetail<ViewMasterCashList, ViewMasterCash, MasterCash>
    {
        public ViewMasterCashDetail(ViewMasterCashList repository, List<ViewEmployee> masters): 
            base(repository, new ViewAdditionalMasterCash(masters), new ViewAdditionalMasterCash(masters))
        {
        }

        //public override RelayCommand Save => new RelayCommand(async (obj) =>
        //{
        //    await repository.UpdateViewAsync(oldViewModel, new ViewMasterCash(ViewModel.Model()));
        //    ViewModel.NotifySelector();
        //});
    }
}
