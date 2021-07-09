using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Customers.Addresses;
using VIIS.API.Data.DBObjects;

namespace VIIS.API.Customers.Models
{
    public class RemovableDBClient : DecoratableDBClient
    {
        public RemovableDBClient(DBClient dBClient) : base(dBClient)
        {
            dbAddress = new RemovableDBAddress(dbAddress);
        }

        protected override void PersonTransfer(VIISDBContext context, PersonsTt dataClient) => context.Remove(dataClient);

        public override void Transfer()
        {
            using (var context = new VIISDBContext())
            {
                var dataClient = new PersonsTt(id, firstName, middleName, lastName, phone, email, dbAddress.Key, comment);
                PersonTransfer(context, dataClient);
                context.SaveChanges();
                dbAddress.Transfer();
                context.SaveChanges();
                Key = 0;
            }
        }

    }
}
