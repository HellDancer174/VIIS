using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Customers.Models;
using VIIS.API.Data.DBObjects;
using VIIS.API.Employees.Passports;
using VIIS.API.GlobalModel;
using VIIS.Domain.Orders;
using VIIS.Domain.Staff;

namespace VIIS.API.Employees.Models
{
    public class RemovableDBMaster : DBMaster
    {
        private readonly IEnumerable<Order> orders;

        public RemovableDBMaster(Master other, DBQuery<EmployeesTt> query, DBQuery<PassportsTt> passportQuery, DBQuery<PersonsTt> personQuery, DBQuery<AddressesTt> addressQuery, IEnumerable<Order> orders) : 
            base(other, query, passportQuery, personQuery, addressQuery)
        {
            this.orders = orders;
        }

        public override void Transfer()
        {
            var unFinishedOrders = orders.Where(order => order.IsOwner(this) && !order.IsFinished).ToList();
            if (unFinishedOrders.Count != 0)
                throw new InvalidOperationException(String.Format("{0} имеет незавершенные заказы: {1}", FullName, String.Join("; ", unFinishedOrders.Select(o => o.ToString()).ToArray())));
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
