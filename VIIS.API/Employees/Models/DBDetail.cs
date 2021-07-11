using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Data.DBObjects;
using VIIS.Domain.Staff.ValueClasses;
using VIIS.Domain.Staff.ValueClasses.Decorators;

namespace VIIS.API.Employees.Models
{
    public class DBDetail : DecoratableEmployeeDetail
    {
        public DBDetail(EmployeeDetail other) : base(other)
        {
        }
        public EmployeesTt EmployeeEntity(EmployeesTt entity)
        {
            return new EmployeesTt(entity.Id, entity.PersonId, entity.Position, entity.Birthday, contractID, start, entity.PassportId);
        }
    }
}
