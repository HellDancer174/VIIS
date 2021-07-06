using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Data.DBObjects;
using VIIS.Domain.Staff.ValueClasses;
using VIIS.Domain.Staff.ValueClasses.Decorators;

namespace VIIS.API.Customers.Addresses
{
    public class InsertableDBAddress : DecoratableDBAddress
    {
        public InsertableDBAddress(DBAddress other) : base(other)
        {
        }

        protected override void ExecuteTransfer(VIISDBContext context, AddressesTt dataAddress) => context.AddressesTt.Add(dataAddress);
    }
}
