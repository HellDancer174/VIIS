using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.Models.OrdersDecorators;
using VIIS.App.Staff.ViewModels;
using VIIS.Domain.Orders;
using VIIS.Domain.Staff;

namespace VIIS.App.Staff.Models
{
    public class MastersOrderPerMonth : Master
    {
        private readonly Orders orders;
        private readonly DateTime monthOfYear;

        public MastersOrderPerMonth(Master other, Orders orders, DateTime monthOfYear) : base(other)
        {
            this.monthOfYear = monthOfYear;
            this.orders = new OrdersPerMonth(orders, monthOfYear).OrdersOfMaster(this);
        }
        public MastersOrderPerMonth(Master other, Orders orders, int month, int year): this(other, orders, new DateTime(year, month, 1))
        {
        }
    }
}
