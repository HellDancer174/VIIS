using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Finance;
using VIIS.Domain.Finance.Decorators;
using VIIS.Domain.Orders;
using VIIS.Domain.Staff;
using VIIS.Domain.Staff.ValueClasses;
using VIMVVM.Detail;

namespace VIIS.App.Finance.MasterPay.ViewModels
{
    public class ViewMasterCash : DecoratableMasterCash, IDetailedViewModel<MasterCash>
    {
        public ViewMasterCash(MasterCash other) : base(other)
        {
        }

        public ViewMasterCash(Master master, Orders orders, DateTime startDate, DateTime finishDate, MastersPercent percent):
            this(new MasterCash(master, startDate, finishDate, percent.CashOfMaster(new Orders(orders, startDate, finishDate, master).TotalSale)))
        {

        }

        public string MasterName => master.FullName;

        public decimal Cash { get => value; set => this.value = value; }

        public string DateSpan => String.Format("{0} - {1}", startDate.ToShortDateString(), finishDate.ToShortDateString());

        public bool IsSelected { get; set; }

        public virtual MasterCash Model()
        {
            return new MasterCash(master, startDate, finishDate, value);
        }

        public Transaction Transaction => new Transaction(String.Format("Заработная плата: Maстер - {0}", MasterName), 0 - Cash);

        public virtual void NotifySelector()
        {
            ChangeProperties(nameof(MasterName), nameof(Cash));
        }
    }
}
