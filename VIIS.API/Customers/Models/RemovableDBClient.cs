using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Customers.Addresses;
using VIIS.API.Data.DBObjects;

namespace VIIS.API.Customers.Models
{
    public class RemovableDBClient : DecoratableDBClient
    {
        public RemovableDBClient(DBClient dBClient) : base(dBClient)
        {
            dbAddress = new RemovableDBAddress(dbAddress);
        }

        protected override void ExecuteTransfer(VIISDBContext context, PersonsTt dataClient) => context.Remove(dataClient);
    }
}
