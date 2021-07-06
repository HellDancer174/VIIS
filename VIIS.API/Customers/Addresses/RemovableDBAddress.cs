using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Data.DBObjects;

namespace VIIS.API.Customers.Addresses
{
    public class RemovableDBAddress : DecoratableDBAddress
    {
        public RemovableDBAddress(DBAddress other) : base(other)
        {
        }

        protected override void ExecuteTransfer(VIISDBContext context, AddressesTt dataAddress) => context.Remove(dataAddress);
    }
}
