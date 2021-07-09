using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Data.DBObjects;
using VIIS.Domain.Staff.ValueClasses;
using VIIS.Domain.Staff.ValueClasses.Decorators;

namespace VIIS.API.Customers.Addresses
{
    public class DBAddress : DecoratableAddress
    {
        public DBAddress(AddressesTt row) : this(new DBAddress(new Address(row.Id, row.Postcode.GetValueOrDefault(), row.City, row.Street, row.House, row.Flat)))
        {
        }
        public DBAddress(Address other) : base(other)
        {
            Key = id;
        }

        protected virtual void ExecuteTransfer(VIISDBContext context, AddressesTt dataAddress) => context.AddressesTt.Add(dataAddress);

        public override void Transfer()
        {
            using (var context = new VIISDBContext())
            {
                //if (id < 1) throw new InvalidOperationException(String.Format("Идентификатор равен {0}", id));
                var dataAddress = new AddressesTt(id, index, city, street, house, flat);
                ExecuteTransfer(context, dataAddress);
                context.SaveChanges();
                Key = dataAddress.Id;
            }
        }


        public int Key { get; private set; }
    }
}
