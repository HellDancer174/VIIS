using ElegantLib.Validate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Customers.Models;
using VIIS.API.Employees.Passports;
using VIIS.API.GlobalModel;
using VIIS.Domain.Staff;
using VIIS.Domain.Staff.Decorators;

namespace VIIS.API.Employees.Models
{
    public class MasterOfDB : DecoratableMaster, IValidatable<Master>
    {
        public MasterOfDB(Master other) : base(other)
        {
        }

        public Master Safe()
        {
            throw new NotImplementedException();
        }

        public Master UnSafe()
        {
            new ValidID(masterID).Validate();
            new PassportOfDB(passport).UnSafe();
            new ClientOfDB(this).UnSafe();
            return this;
        }
    }
}
