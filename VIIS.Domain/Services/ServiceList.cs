using ElegantLib;
using ElegantLib.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Services
{
    public class ServiceList : VirtualCollection<Service>, IDocument
    {
        public ServiceList(IList<Service> list) : base(list)
        {
        }

        public virtual void Transfer()
        {
            throw new NotImplementedException();
        }
    }
}
