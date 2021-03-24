using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Staff.Decorators
{
    public class EmployeesDecorator : Employees
    {
        private readonly Employees other;

        public EmployeesDecorator(Employees other) : base(other)
        {
            this.other = new Employees(other);
        }
    }
}
