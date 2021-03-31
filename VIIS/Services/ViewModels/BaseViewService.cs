using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.OrderDetail.ViewModels;
using VIIS.Domain.Services;
using VIIS.Domain.Services.Decorators;
using VIMVVM;

namespace VIIS.App.Services.ViewModels
{
    public class BaseViewService : ServiceDecorator, INotifyPropertyChanged
    {
        public BaseViewService(Service service) : base(service)
        {
        }

        public string Name { get => name; set => name = value; }
        public DateTime Start { get => new DateTime()+start; set => start = value.TimeOfDay; }
        public DateTime TimeSpan { get => new DateTime() + timeSpan; set => timeSpan = value.TimeOfDay; }

    }
}
