using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Services;
using VIMVVM;

namespace VIIS.App.OrdersJournal.OrderDetail.ViewModels
{
    public class ViewServiceValue : ViewModel<ServiceValue>
    {
        protected ServiceValue serviceValue;

        public ViewServiceValue(ServiceValue service)
        {
            this.serviceValue = service;
        }

        public string Name => serviceValue.ToString();

        public virtual decimal Sale => serviceValue.Sale;

        public override ServiceValue Model()
        {
            return serviceValue;
        }
    }
}
