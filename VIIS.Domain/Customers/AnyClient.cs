using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Customers
{
    public class AnyClient: Client
    {
        public AnyClient():base(-1,"", "", "", "")
        {
        }

        public override string FullName => "Клиент не выбран";
    }
}
