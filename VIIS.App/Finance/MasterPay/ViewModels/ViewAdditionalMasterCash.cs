using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.Staff.ViewModels;
using VIIS.Domain.Finance;
using VIIS.Domain.Staff;

namespace VIIS.App.Finance.MasterPay.ViewModels
{
    public class ViewAdditionalMasterCash : ViewMasterCash
    {

        public ViewAdditionalMasterCash(IEnumerable<ViewEmployee> masters): this(new MasterCash(masters.First(), DateTime.Now, DateTime.Now, 0), masters)
        {

        }
        public ViewAdditionalMasterCash(MasterCash other, IEnumerable<ViewEmployee> masters) : base(other)
        {
            Masters = new ObservableCollection<ViewEmployee>(masters);
            SelectedMaster = Masters.SingleOrDefault(master => master.Equals(this.master));
        }


        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime FinishDate { get => finishDate; set => finishDate = value; }

        public ObservableCollection<ViewEmployee> Masters { get; }

        public ViewEmployee SelectedMaster { get; set; }

        public override MasterCash Model()
        {
            if (SelectedMaster == null) throw new InvalidOperationException();
            return new MasterCash(SelectedMaster, StartDate, FinishDate, Cash);
        }

        public override void NotifySelector()
        {
            if (SelectedMaster == null) throw new NullReferenceException();
            master = SelectedMaster;
            base.NotifySelector();
        }
    }
}
