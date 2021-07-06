using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Customers.Addresses;
using VIIS.Domain.Customers;

namespace VIIS.API.Customers.Models
{
    public class DecoratableDBClient : DBClient
    {
        protected readonly DBClient dBClient;

        public DecoratableDBClient(DBClient dBClient) : base(dBClient)
        {
            this.dBClient = dBClient;
        }
    }
}
