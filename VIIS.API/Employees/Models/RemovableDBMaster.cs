using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Customers.Models;
using VIIS.API.Data.DBObjects;
using VIIS.API.Employees.Passports;
using VIIS.API.GlobalModel;
using VIIS.Domain.Staff;

namespace VIIS.API.Employees.Models
{
    public class RemovableDBMaster : DBMaster
    {

        public RemovableDBMaster(Master other, DBQuery<EmployeesTt> query, DBQuery<PassportsTt> passportQuery, DBQuery<PersonsTt> personQuery, DBQuery<AddressesTt> addressQuery) : base(other, query, passportQuery, personQuery, addressQuery)
        {
        }

        public override void Transfer()
        {
            var dbPassport = new DBPassport(passport, passportQuery);
            var dbClient = new RemovableTDBClient(this, personQuery, addressQuery);
            entity.PassportId = dbPassport.Key;
            entity.PersonId = dbClient.Key;
            query.Transfer(entity);
            dbPassport.Transfer();
            dbClient.Transfer();
        }
    }
}
