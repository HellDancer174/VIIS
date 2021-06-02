using ElegantLib.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VIIS.App.Finance.ViewModels;
using VIIS.Domain.Finance;
using VIIS.Domain.Global;
using VIIS.Domain.Orders;
using VIIS.Domain.Staff;
using VIIS.Domain.Staff.ValueClasses;
using VIMVVM;

namespace VIIS.App.Finance.MasterPay.ViewModels
{
    public class ViewAdditionalMasterCashList : ViewMasterCashList
    {
        private readonly ViewMasterCashList other;
        private readonly Employees masters;
        private readonly Orders orders;

        public ViewAdditionalMasterCashList(ViewMasterCashList other, Employees masters, Orders orders) : base(new Repository<MasterCash>(new List<MasterCash>()), other)
        {
            this.other = other;
            this.masters = masters;
            this.orders = orders;
            StartDate = DateTime.Now.Date;
            FinishDate = DateTime.Now.Date;
            Percent = 40;
        }

        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public int Percent { get; set; }

        public ICommand СalcCommand => new RelayCommand((obj) =>
        {
            Collection.Clear();
            foreach (var master in masters)
            {
                Collection.Add(new ViewMasterCash(master, orders, StartDate, FinishDate, new MastersPercent(Percent)));
            }
        }, (obj) => CanExecute());

        private bool CanExecute() => FinishDate.Date > StartDate.Date && FinishDate > new DefaultDateTime().Value && StartDate > new DefaultDateTime().Value;

        public ICommand AdditionalSum => new RelayCommand(async (obj) =>
        {
            await other.AddRange(Collection.Where(cash => cash.IsSelected).Select(cash => new ViewMasterCash(cash.Model())).ToArray(), StartDate, FinishDate);
        }, (obj) => CanExecute() && Collection.Where(cash => cash.IsSelected).ToList().Count != 0);



    }
}
