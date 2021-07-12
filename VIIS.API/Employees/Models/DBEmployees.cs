using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VIIS.Domain.Staff.Decorators;
using VIIS.Domain.Staff;
using VIIS.API.Data.DBObjects;

namespace VIIS.API.Employees.Models
{
    public class DBEmployees : EmployeesDecorator
    {
        public DBEmployees(VIISDBContext context) : base(new Domain.Staff.Employees(context.EmployeesTt.Include(master => master.Person).ThenInclude(person => person.Address)
            .Include(master => master.Passport).Include(master => master.WorkDaysTt)
            .Select(master => new DBMaster(master) as Master).ToList()))
        {
        }

    }
}
