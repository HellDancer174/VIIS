using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Customers.Addresses;
using VIIS.API.Data.DBObjects;
using VIIS.Domain.Customers;
using VIIS.Domain.Customers.Decorators;
using VIIS.Domain.Staff.ValueClasses;

namespace VIIS.API.Customers.Models
{
    public class DBClient : ClientDecorator
    {
        protected DBAddress dbAddress;

        public DBClient(PersonsTt row, AddressesTt addressRow) : this(new Client(row.Id, row.FirstName, row.LastName, row.MiddleName, row.Phone, row.Email, new DBAddress(addressRow), row.Comment), new DBAddress(addressRow))
        {
        }
        public DBClient(PersonsTt row) : this(row, row.Address)
        {
        }
        public DBClient(Client other, DBAddress dbAddress) : base(other)
        {
            this.dbAddress = dbAddress;
        }
        public DBClient(Client other):base(other)
        {
            dbAddress = new DBAddress(address);
        }
        public DBClient(DBClient other): this(other, other.dbAddress)
        {
        }

        public override void Transfer()
        {
            using (var context = new VIISDBContext())
            {
                dbAddress.Transfer();
                var dataClient = new PersonsTt(id, firstName, middleName, lastName, phone, email, dbAddress.Key, comment);
                PersonTransfer(context, dataClient);
                context.SaveChanges();
                Key = dataClient.Id;
            }
        }

        protected virtual void PersonTransfer(VIISDBContext context, PersonsTt dataClient) => context.Add(dataClient);

        public int Key { get; protected set; }

    
    }
}
