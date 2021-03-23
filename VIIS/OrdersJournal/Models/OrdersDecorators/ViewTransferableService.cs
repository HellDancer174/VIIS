using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.ViewModels;
using VIIS.App.Services.ViewModel;
using VIIS.Domain.Services;

namespace VIIS.App.OrdersJournal.Models.OrdersDecorators
{
    public class ViewTransferableService : Service
    {
        private readonly Service other;
        private readonly BaseViewService viewService;

        public ViewTransferableService(Service other, BaseViewService viewService) : base(other)
        {
            this.other = other;
            this.viewService = viewService;
        }

        public override void Transfer()
        {
            viewService.ChangeContent(start, timeSpan);
        }
    }
}
