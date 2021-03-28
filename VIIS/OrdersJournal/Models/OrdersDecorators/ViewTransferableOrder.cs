using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.OrderDetail.ViewModels;
using VIIS.App.OrdersJournal.ViewModels;
using VIIS.Domain.Customers;
using VIIS.Domain.Orders;
using VIIS.Domain.Services;

namespace VIIS.App.OrdersJournal.Models.OrdersDecorators
{
    public class ViewTransferableOrder : Order
    {
        private readonly Order other;
        private readonly Dictionary<string, PageTimes> masterTimes;

        public ViewTransferableOrder(Order other, Dictionary<string, PageTimes> masterTimes) : base(other)
        {
            this.other = other;
            this.masterTimes = masterTimes;
        }

        public override void Transfer()
        {
            return;
            //Сервисы будут делать PageContent, а этот класс будет добавлять их в PageTimes.
        }
    }
}
