using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Customers.Addresses;
using VIIS.API.Data.DBObjects;

namespace VIIS.API.Customers.Models
{
    public class UpdatableDBClient: DecoratableDBClient
    {
        public UpdatableDBClient(DBClient dBClient) : base(dBClient)
        {
            dbAddress = new UpdatableDBAddress(dbAddress);
        }

        protected override void PersonTransfer(VIISDBContext context, PersonsTt dataClient) => context.Update(dataClient);
    }
}
