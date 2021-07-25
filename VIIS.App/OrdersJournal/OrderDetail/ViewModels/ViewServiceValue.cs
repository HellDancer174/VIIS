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

        public string Name { get => name; set => name = value; }

        public decimal Price { get => Sale; set => sale = value; }

        public override bool Equals(object obj)
        {
            var value = obj as ViewServiceValue;
            return value != null && name == value.name;
        }
    }
}
