using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Data.DBObjects;
using VIIS.API.GlobalModel;
using VIIS.Domain.Staff.ValueClasses;
using VIIS.Domain.Staff.ValueClasses.Decorators;

namespace VIIS.API.Employees.Passports
{
    public class DBPassport : DecoratablePassport, IDocument
    {
        private readonly DBQuery<PassportsTt> query;
        private readonly PassportsTt entity;

        public DBPassport(Passport other, DBQuery<PassportsTt> query) : base(other)
        {
            this.query = query;
            entity = new PassportsTt(id, series, passportID, issusiesDate, organization);
            
        }
        public DBPassport(PassportsTt row, DBQuery<PassportsTt> query) : this(new Passport(row.Id, row.Series, row.PassportNumber, row.IssusiesDate, row.Organization), query)
        {
        }
        public DBPassport(PassportsTt row): this(row, new AnyDBQuery<PassportsTt>())
        {
        }

        public void Transfer()
        {
            query.Transfer(entity);
        }

        public int Key => entity.Id;
    }
}
