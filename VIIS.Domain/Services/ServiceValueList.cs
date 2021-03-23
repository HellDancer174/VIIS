using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Services
{
    public class ServiceValueList
    {
        protected readonly List<ServiceValue> services;

        public ServiceValueList(List<ServiceValue> services)
        {
            this.services = services;
        }
        public ServiceValueList(ServiceValueList other): this(other.services)
        {
        }
        public ServiceValueList(): this(new List<ServiceValue>() { new ServiceValue("Стрижка", 500), new ServiceValue("Укладка", 500), new ServiceValue("Еще что-то", 500) })
        {
        }


    }
}
