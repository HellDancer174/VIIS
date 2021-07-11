using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Customers.Addresses;
using VIIS.API.Data.DBObjects;
using VIIS.API.GlobalModel;
using VIIS.Domain.Customers;

namespace VIIS.API.Customers.Models
{
    public class RemovableTDBClient : TDBClient
    {
        public RemovableTDBClient(Client other, DBQuery<PersonsTt> personQuery, DBQuery<AddressesTt> addressQuery) : base(other, personQuery, addressQuery)
        {
        }

        public override void Transfer()
        {
            var dbAddress = new TDBAddress(address, addressQuery);
            entity.AddressId = dbAddress.Key;
            personQuery.Transfer(entity);
            dbAddress.Transfer();
        }
    }
}
