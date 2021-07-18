using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Data.DBObjects;
using VIIS.API.GlobalModel;
using VIIS.Domain.Staff.ValueClasses;
using VIIS.Domain.Staff.ValueClasses.Decorators;

namespace VIIS.API.Customers.Addresses
{
    public class TDBAddress : DecoratableAddress
    {
        private readonly DBQuery<AddressesTt> query;
        private readonly AddressesTt entity;

        public TDBAddress(AddressesTt row): this(new Address(row.Id, row.Postcode.GetValueOrDefault(), row.City, row.Street, row.House, row.Flat), new AnyDBQuery<AddressesTt>())
        {

        }

        public TDBAddress(Address other, DBQuery<AddressesTt> query) : base(other)
        {
            this.query = query;
            this.entity = new AddressesTt(id, index, city, street, house, flat);
        }

        public override void Transfer()
        {
            query.Transfer(entity);
        }

        public int Key => entity.Id;

        public AddressesTt Entity => entity;
    }
}
