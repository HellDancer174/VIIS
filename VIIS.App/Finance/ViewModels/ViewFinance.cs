using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VIIS.App.Finance.MasterPay.ViewModels;
using VIIS.App.Finance.MasterPay.Views;
using VIIS.App.Finance.Views;
using VIIS.Domain.Orders;
using VIIS.Domain.Staff;

namespace VIIS.App.Finance.ViewModels
{
    public class ViewFinance
    {
        public ViewFinance(Page finance, Page masterCash, Page additionalMasterCash)
        {
            Finance = finance;
            MasterCash = masterCash;
            AdditionalMasterCash = additionalMasterCash;
        }

        public ViewFinance(ViewTransactions transactions, ViewMasterCashList cashes, ViewAdditionalMasterCashList addCashes):
            this(new FinanceView(transactions), new MasterCashCommonView(cashes), new MasterCashView(addCashes))
        {
        }
        public ViewFinance(ViewTransactions transactions, ViewMasterCashList cashes, Orders orders, Employees masters):
            this(transactions, cashes, new ViewAdditionalMasterCashList(cashes, masters, orders))
        {
        }

        public Page Finance { get; }
        public Page MasterCash { get; }
        public Page AdditionalMasterCash { get; }
    }
}
