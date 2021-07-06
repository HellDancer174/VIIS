using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Customers.Addresses;

namespace VIIS.API.Customers.Models
{
    public class ValidDBClient : DecoratableDBClient
    {
        public ValidDBClient(DBClient dBClient) : base(dBClient)
        {
        }

        public override void Transfer()
        {
            new AddressOfDB(dbAddress).UnSafe();
            new ClientOfDB(this).UnSafe();
            dBClient.Transfer();
        }
    }
}
