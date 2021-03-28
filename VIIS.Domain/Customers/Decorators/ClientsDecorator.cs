using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Customers.Decorators
{
    public class ClientsDecorator : Clients
    {
        private readonly Clients other;

        public ClientsDecorator(Clients other) : base(other)
        {
            this.other = new Clients(other);
        }
    }
}
