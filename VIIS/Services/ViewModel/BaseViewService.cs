using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.OrderDetail.ViewModels;
using VIIS.Domain.Services;
using VIIS.Domain.Services.Decorators;
using VIMVVM;

namespace VIIS.App.Services.ViewModel
{
    public class BaseViewService : ServiceDecorator
    {
        public BaseViewService(Service service) : base(service)
        {
        }

        public TimeSpan Start { get => start; set => start = value; }
        public TimeSpan TimeSpan { get => timeSpan; set => timeSpan = value; }

    }
}
