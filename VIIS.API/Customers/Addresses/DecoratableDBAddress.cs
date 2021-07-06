using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.Domain.Staff.ValueClasses;

namespace VIIS.API.Customers.Addresses
{
    public class DecoratableDBAddress : DBAddress
    {
        protected readonly DBAddress dbAddress;

        public DecoratableDBAddress(DBAddress other) : base(other)
        {
            this.dbAddress = other;
        }
    }
}
