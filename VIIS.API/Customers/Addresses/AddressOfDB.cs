using ElegantLib.Validate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.GlobalModel;
using VIIS.Domain.Staff.ValueClasses;
using VIIS.Domain.Staff.ValueClasses.Decorators;

namespace VIIS.API.Customers.Addresses
{
    public class AddressOfDB : DecoratableAddress, IValidatable<Address>
    {
        public AddressOfDB(Address other) : base(other)
        {
        }

        public Address Safe()
        {
            return UnSafe();
        }

        public Address UnSafe()
        {
            new ValidID(id).Validate();
            return this;
        }
    }
}
