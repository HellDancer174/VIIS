using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Customers.Addresses;
using VIIS.API.Data.DBObjects;
using VIIS.API.GlobalModel;
using VIIS.Domain.Customers;
using VIIS.Domain.Customers.Decorators;

namespace VIIS.API.Customers.Models
{
    public class TDBClient: ClientDecorator
    {
        protected readonly DBQuery<PersonsTt> personQuery;
        protected readonly DBQuery<AddressesTt> addressQuery;
        protected readonly TDBAddress dBAddress;
        protected readonly PersonsTt entity;

        public TDBClient(PersonsTt row, AddressesTt addressRow) : 
            this(new Client(row.Id, row.FirstName, row.LastName, row.MiddleName, row.Phone, row.Email, new TDBAddress(addressRow), row.Comment), new AnyDBQuery<PersonsTt>(), new AnyDBQuery<AddressesTt>())
        {
        }
        public TDBClient(PersonsTt row) : this(row, row.Address)
        {
        }
        public TDBClient(Client other, DBQuery<PersonsTt> personQuery, DBQuery<AddressesTt> addressQuery) : base(other)
        {
            this.personQuery = personQuery;
            this.addressQuery = addressQuery;
            dBAddress = new TDBAddress(address, addressQuery);
            entity = new PersonsTt(id, firstName, middleName, lastName, phone, email, dBAddress.Key, comment);
        }
        public TDBClient(Client other): this(other, new AnyDBQuery<PersonsTt>(), new AnyDBQuery<AddressesTt>())
        {
        }

        public override void Transfer()
        {
            var dbAddress = new TDBAddress(address, addressQuery);
            dbAddress.Transfer();
            entity.AddressId = dbAddress.Key;
            personQuery.Transfer(entity);
        }

        public virtual int Key => entity.Id;

        public PersonsTt Entity()
        {
            entity.Address = new TDBAddress(address, addressQuery).Entity;
            return entity;
        }
    }
}
