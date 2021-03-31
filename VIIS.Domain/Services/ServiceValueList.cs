using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Global;

namespace VIIS.Domain.Services
{
    public class ServiceValueList: Repository<ServiceValue>
    {

        public ServiceValueList(List<ServiceValue> services):base(services)
        {
        }
        public ServiceValueList(ServiceValueList other): this(other.ToList())
        {
        }
        public ServiceValueList(): this(new List<ServiceValue>() { new ServiceValue("Стрижка", 500), new ServiceValue("Укладка", 500), new ServiceValue("Еще что-то", 500) })
        {
        }


    }
}
