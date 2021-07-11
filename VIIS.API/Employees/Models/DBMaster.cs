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
using VIIS.Domain.Staff.ValueClasses;

namespace VIIS.API.Employees.Models
{
    public class DBMaster : DecoratableMaster
    {
        protected readonly EmployeesTt entity;
        protected readonly DBQuery<EmployeesTt> query;
        protected readonly DBQuery<PassportsTt> passportQuery;
        protected readonly DBQuery<PersonsTt> personQuery;
        protected readonly DBQuery<AddressesTt> addressQuery;

        public DBMaster(Master other, DBQuery<EmployeesTt> query, DBQuery<PassportsTt> passportQuery, DBQuery<PersonsTt> personQuery, DBQuery<AddressesTt> addressQuery) : base(other)
        {
            entity = new DBDetail(detail).EmployeeEntity(new EmployeesTt(masterID, id, position.ToString(), birthday, 0, new DateTime(), 0));
            this.query = query;
            this.passportQuery = passportQuery;
            this.personQuery = personQuery;
            this.addressQuery = addressQuery;
        }
        public DBMaster(EmployeesTt row): 
            base(new Master(row.Id, new Position(row.Position), new WorkDaysList(row.WorkDaysTt.Where(day => day.MasterId == row.Id).Select(day => day.WorkDate).ToList()), 
                new DBPassport(row.Passport), new EmployeeDetail(row.StartDate, row.ContractId), row.Birthday, new TDBClient(row.Person)))
        {
            entity = row;
            this.query = new AnyDBQuery<EmployeesTt>();
            this.passportQuery = new AnyDBQuery<PassportsTt>();
            this.personQuery = new AnyDBQuery<PersonsTt>();
            this.addressQuery = new AnyDBQuery<AddressesTt>();
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
