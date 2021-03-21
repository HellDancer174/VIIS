using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Clients;

namespace VIIS.Domain.Employees
{
    public class Master : Client, IEquatable<Master>
    {
        public Master(Master other) : base(other)
        {
        }

        public Master(string firstName, string lastName, string middleName, string phone) : base(firstName, lastName, middleName, phone)
        {
        }

        public bool Equals(Master other)
        {
            return base.Equals(other);
        }

    }
}
