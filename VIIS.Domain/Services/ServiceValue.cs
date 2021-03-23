using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Services
{
    public class ServiceValue
    {
        protected readonly string name;
        protected readonly decimal sale;

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
        public decimal Sale => sale;

        public override string ToString()
        {
            return name;
        }

    }
}
