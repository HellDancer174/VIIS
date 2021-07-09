using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Customers.Addresses;
using VIIS.Domain.Customers;
using VIIS.Domain.Customers.Decorators;

namespace VIIS.API.Customers.Models
{
    public class ValidDBClient : ClientDecorator
    {
        public ValidDBClient(Client dBClient) : base(dBClient)
        {
        }

        public override void Transfer()
        {
            new AddressOfDB(address).UnSafe();
            new ClientOfDB(this).UnSafe();
            other.Transfer();
        }
    }
}
