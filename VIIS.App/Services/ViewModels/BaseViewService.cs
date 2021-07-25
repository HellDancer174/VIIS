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
        //public DateTime Start { get => new DateTime()+ordersStart; set => ordersStart = value.TimeOfDay; }
        public int TimeSpan { get => (int)timeSpan.TotalMinutes; set => timeSpan = new TimeSpan(0, value, 0); }

    }
}
