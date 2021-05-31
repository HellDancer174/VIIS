using ElegantLib.Validate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIIS.Domain.Global;
using VIIS.Domain.Services;
using VIIS.Domain.Services.Decorators;

namespace VIIS.App.Services.Model
{
    public class ServiceValueOfViewService : DecoratableServiceValue, IValidatable<ServiceValue>
    {
        private ValidProperty<string> validName;
        private ValidProperty<decimal> validSale;

        public ServiceValueOfViewService(ServiceValue other) : base(other)
        {
            validName = new ValidProperty<string>("Название услуги", name, !(String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name)));
            validSale = new ValidProperty<decimal>("Цена услуги", sale, sale > 0);
        }

        public ServiceValue Safe()
        {
            try
            {
                return UnSafe();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public ServiceValue UnSafe()
        {
            validSale.Validate();
            validName.Validate();
            return this;
        }
    }
}
