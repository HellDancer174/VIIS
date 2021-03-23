using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.OrderDetail.ViewModels;
using VIIS.Domain.Services;
using VIMVVM;

namespace VIIS.App.Services.ViewModel
{
    public class BaseViewService : ViewServiceValue, IViewModel<Service>, IEquatable<BaseViewService>
    {
        private ViewServiceValue selectedService;
        public BaseViewService(ServiceValue service, TimeSpan start, TimeSpan timeSpan) : base(service)
        {
            Start = start;
            TimeSpan = timeSpan;
            SelectedService = this;
        }

        public ViewServiceValue SelectedService
        {
            get => selectedService;
            set
            {
                selectedService = value;
                serviceValue = selectedService.Model();
            }
        }

        public TimeSpan Start { get; set; }
        public TimeSpan TimeSpan { get; set; }

        public void ChangeContent(TimeSpan orderTime, TimeSpan timeSpan)
        {
            Start = orderTime;
            TimeSpan = timeSpan;
        }

        public virtual bool Equals(BaseViewService other)
        {
            return Start == other.Start;
        }

        public new Service Model()
        {
            return new Service(SelectedService.Model(), Start, TimeSpan);
        }
    }
}
