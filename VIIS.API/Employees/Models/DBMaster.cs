using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Customers.Models;
using VIIS.API.Data.DBObjects;
using VIIS.API.Employees.Passports;
using VIIS.API.GlobalModel;
using VIIS.Domain.Staff;
using VIIS.Domain.Staff.Decorators;

namespace VIIS.API.Employees.Models
{
    public class DBMaster : DecoratableMaster
    {
        private readonly EmployeesTt entity;
        private readonly DBQuery<EmployeesTt> query;
        private readonly DBQuery<PassportsTt> passportQuery;
        private readonly DBQuery<PersonsTt> personQuery;
        private readonly DBQuery<AddressesTt> addressQuery;

        public DBMaster(Master other, DBQuery<EmployeesTt> query, DBQuery<PassportsTt> passportQuery, DBQuery<PersonsTt> personQuery, DBQuery<AddressesTt> addressQuery) : base(other)
        {
            entity = new DBDetail(detail).EmployeeEntity(new EmployeesTt(masterID, id, position.ToString(), birthday, 0, new DateTime(), 0));
            this.query = query;
            this.passportQuery = passportQuery;
            this.personQuery = personQuery;
            this.addressQuery = addressQuery;
        }

        public override void Transfer()
        {
            var dbPassport = new DBPassport(passport, passportQuery);
            var dbClient = new TDBClient(this, personQuery, addressQuery);
            dbPassport.Transfer();
            dbClient.Transfer();
            entity.PassportId = dbPassport.Key;
            entity.PersonId = dbClient.Key;
            query.Transfer(entity);
        }
    }
}
