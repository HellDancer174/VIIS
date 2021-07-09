using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Data.DBObjects;
using Microsoft.EntityFrameworkCore;
using VIIS.Domain.Customers;
using VIIS.Domain.Customers.Decorators;

namespace VIIS.API.Customers.Models
{
    public class DBClients : ClientsDecorator
    {
        public DBClients(VIISDBContext context) : base(new Clients(context.PersonsTt.Include(person => person.Address).ToList().Select(person => new TDBClient(person) as Client).ToList()))
        {
        }
    }
}
