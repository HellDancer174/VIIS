using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.ViewModels;
using VIIS.Domain.Clients;
using VIIS.Domain.Orders;
using VIIS.Domain.Services;

namespace VIIS.App.OrdersJournal.Models.OrdersDecorators
{
    public class ViewTransferableOrder : Order
    {
        private readonly Order other;
        private readonly PageTimes times;

        public ViewTransferableOrder(Order other, PageTimes times) : base(other)
        {
            this.other = other;
            this.times = times;
        }

        public override void Transfer()
        {
            foreach(var service in services)
            {
                times.AddContent(new PageContent(client.ToString(), "", comment, service));
            }
            //Сервисы будут делать PageContent, а этот класс будет добавлять их в PageTimes.
        }
    }
}
