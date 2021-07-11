using ElegantLib.Validate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.GlobalModel;
using VIIS.Domain.Staff.ValueClasses;
using VIIS.Domain.Staff.ValueClasses.Decorators;

namespace VIIS.API.Employees.Passports
{
    public class PassportOfDB : DecoratablePassport, IValidatable<Passport>
    {
        public PassportOfDB(Passport other) : base(other)
        {
        }

        public Passport Safe()
        {
            return UnSafe();
        }

        public Passport UnSafe()
        {
            new ValidID(id).Validate();
            return this;

        }
    }
}
