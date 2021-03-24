using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.ViewModels;
using VIIS.Domain.Staff;
using VIIS.Domain.Staff.ValueClasses;

namespace VIIS.App.OrdersJournal.Models.EmployeesDecorators
{
    public class GroupedEmployees : Employees
    {
        private readonly Employees primary;

        public GroupedEmployees(Employees other) : base(other)
        {
            this.primary = other;
        }

    }
}
