using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Services.Comparers
{
    public class ServiceComparer : IEqualityComparer<Service>
    {
        public bool Equals(Service x, Service y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(Service obj)
        {
            return obj.GetHashCode();
        }
    }
}
