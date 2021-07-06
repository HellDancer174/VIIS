using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Data.DBObjects;
using VIIS.API.GlobalModel;
using VIIS.Domain.Staff.ValueClasses;

namespace VIIS.API.Customers.Addresses
{
    public class UpdatableDBAddress : DecoratableDBAddress
    {
        public UpdatableDBAddress(DBAddress other) : base(other)
        {
        }

        protected override void ExecuteTransfer(VIISDBContext context, AddressesTt dataAddress) => context.Update(dataAddress);
    }
}
