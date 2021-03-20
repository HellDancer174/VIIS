using ElegantLib;
using ElegantLib.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Clients
{
    public class Client: IDocument, IEquatable<Client>
    {
        protected readonly string firstName;
        protected readonly string lastName;
        protected readonly string middleName;
        protected readonly int phone;

        public Client(string firstName, string lastName, string middleName, int phone)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.middleName = middleName;
            this.phone = phone;
        }
        public Client(Client other)
        {
            firstName = other.firstName;
            middleName = other.middleName;
            lastName = other.lastName;
            phone = other.phone;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}; {3}", lastName, firstName, middleName, phone);
        }

        public virtual void Transfer()
        {
            new AnyDocument().Transfer();
        }

        public bool Equals(Client other)
        {
            return other.firstName == firstName && other.middleName == middleName && other.lastName == lastName;
        }
    }
}
