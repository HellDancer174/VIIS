using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Services;
using VIMVVM;

namespace VIIS.App.OrdersJournal.OrderDetail.ViewModels
{
    public class ViewServiceValue: ServiceValue
    {
        protected ServiceValue serviceValue;

        public ViewServiceValue(ServiceValue service): base(service)
        {
            this.serviceValue = service;
        }

        public string Name => serviceValue.ToString();

    }
}
