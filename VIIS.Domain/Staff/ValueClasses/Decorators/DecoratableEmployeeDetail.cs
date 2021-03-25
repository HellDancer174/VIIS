using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Staff.ValueClasses.Decorators
{
    public class DecoratableEmployeeDetail : EmployeeDetail
    {
        private readonly EmployeeDetail other;

        public DecoratableEmployeeDetail(EmployeeDetail other) : base(other)
        {
            this.other = new EmployeeDetail(other);
        }
    }
}
