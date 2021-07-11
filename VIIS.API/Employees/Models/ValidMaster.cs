using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.Domain.Staff;
using VIIS.Domain.Staff.Decorators;

namespace VIIS.API.Employees.Models
{
    public class ValidMaster : DecoratableMaster
    {
        public ValidMaster(Master other) : base(other)
        {
        }

        public override void Transfer()
        {
            new MasterOfDB(this).UnSafe();
            other.Transfer();
        }
    }
}
