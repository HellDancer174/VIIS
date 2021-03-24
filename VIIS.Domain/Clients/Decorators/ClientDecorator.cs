using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Clients.Decorators
{
    public class ClientDecorator : Client
    {
        protected readonly Client other;

        public ClientDecorator(Client other) : base(other)
        {
            this.other = new Client(other);
        }
    }
}
