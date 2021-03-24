using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;

namespace VIIS.Domain.Services
{
    public class ServiceValue: Notifier
    {
        protected string name;
        protected decimal sale;

        public ServiceValue(string name, decimal sale)
        {
            this.name = name;
            this.sale = sale;
        }
        public ServiceValue(ServiceValue other)
        {
            name = other.name;
            sale = other.sale;
        }
        public ServiceValue(): this("", 0)
        {
        }
        public decimal Sale => sale;

        public override string ToString()
        {
            return name;
        }

    }
}
