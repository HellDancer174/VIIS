using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.ViewModels;
using VIIS.Domain.Services;

namespace VIIS.App.OrdersJournal.Models.OrdersDecorators
{
    public class ViewTransferableService : Service
    {
        private readonly Service other;
        private readonly PageContent pageContent;

        public ViewTransferableService(Service other, PageContent pageContent) : base(other)
        {
            this.other = other;
            this.pageContent = pageContent;
        }

        public override void Transfer()
        {
            pageContent.ChangeContent(start);
        }
    }
}
