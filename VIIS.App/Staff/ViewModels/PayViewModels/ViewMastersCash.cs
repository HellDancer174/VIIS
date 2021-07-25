using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Orders;
using VIIS.Domain.Staff;
using VIIS.Domain.Staff.ValueClasses;

namespace VIIS.App.Staff.ViewModels.PayViewModels
{
    public class ViewMastersCash
    {
        public ViewMastersCash(string masterName, decimal cash)
        {
            MasterName = masterName;
            Cash = cash;
        }
        public ViewMastersCash(Master master, Orders orders, DateTime monthOfYear, MastersPercent percent): 
            this(master.FullName, percent.CashOfMaster(new Orders(orders, monthOfYear, master).TotalSale))
        {
        }

        public ViewMastersCash(Master master, Orders orders, DateTime monthOfYear) : this(master, orders, monthOfYear, new MastersPercent())
        {
        }

        public string MasterName { get; set; }

        public decimal Cash { get; set; }

    }
}
