using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.ViewModels;
using VIIS.Domain.Orders;

namespace VIIS.App.OrdersJournal.Models.OrdersDecorators
{
    public class ViewTrasferableOrders : Orders
    {
        private readonly Journal journal;
        private readonly Orders orders;

        public ViewTrasferableOrders(Journal journal, Orders orders)
        {
            this.journal = journal;
            this.orders = orders;
        }

        public override async Task Transfer()
        {
            ////////////journal.ChangeStaff
        }
    }
}
