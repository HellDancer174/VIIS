using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Customers.Addresses;
using VIIS.API.Data.DBObjects;

namespace VIIS.API.Customers.Models
{
    public class InsertableDBClient : DecoratableDBClient
    {
        public InsertableDBClient(DBClient dBClient) : base(dBClient)
        {
            dbAddress = new InsertableDBAddress(dbAddress);
        }

        protected override void PersonTransfer(VIISDBContext context, PersonsTt dataClient) => context.Add(dataClient);
    }
}
