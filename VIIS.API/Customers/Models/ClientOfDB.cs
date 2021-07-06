using ElegantLib.Validate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.GlobalModel;
using VIIS.Domain.Customers;
using VIIS.Domain.Customers.Decorators;

namespace VIIS.API.Customers.Models
{
    public class ClientOfDB : ClientDecorator, IValidatable<Client>
    {
        public ClientOfDB(Client other) : base(other)
        {
        }

        public Client Safe()
        {
            return UnSafe();
        }

        public Client UnSafe()
        {
            new ValidID(id).Validate();
            return this;
        }
    }
}
