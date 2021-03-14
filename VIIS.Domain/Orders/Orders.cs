using ElegantLib;
using ElegantLib.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Orders
{
    public class Orders : IDocumentAsync
    {
        public virtual async Task Transfer()
        {
            await new AnyAsyncDocument().Transfer();
        }
    }
}
