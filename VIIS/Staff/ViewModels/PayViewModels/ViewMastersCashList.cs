using ElegantLib.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.GlobalViewModel;
using VIIS.Domain.Orders;
using VIIS.Domain.Staff;
using VIMVVM;

namespace VIIS.App.Staff.ViewModels.PayViewModels
{
    public class ViewMastersCashList : ViewFilterableModel<DateTime>
    {
        private ObservableCollection<ViewMastersCash> collection;
        private readonly Employees masters;
        private readonly Orders orders;
        private DateTime selected;

        public ViewMastersCashList(Employees masters, Orders orders)
        {
            this.masters = masters;
            this.orders = orders;
            Selected = DateTime.Now;
        }

        public ObservableCollection<ViewMastersCash> Collection => collection;

        //public DateTime Selected
        //{
        //    get => selected;
        //    set
        //    {
        //        if (value == selected) return;
        //        collection = new ObservableCollection<ViewMastersCash>(masters.Select(master => new ViewMastersCash(master, orders, selected)));
        //    }
        //}

        protected override void Refresh()
        {
            collection = new ObservableCollection<ViewMastersCash>(masters.Select(master => new ViewMastersCash(master, orders, selected)));
        }
    }
}
