using ElegantLib;
using ElegantLib.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;

namespace VIIS.Domain.Clients
{
    public class Client: Notifier, IDocument, IEquatable<Client>
    {
        protected string firstName;
        protected string lastName;
        protected string middleName;
        protected string phone;

        public Client(string firstName, string lastName, string middleName, string phone)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.middleName = middleName;
            this.phone = phone;
        }
        public Client(): this("", "", "", "")
        {
        }
        public Client(Client other)
        {
            firstName = other.firstName;
            middleName = other.middleName;
            lastName = other.lastName;
            phone = other.phone;
        }

        public virtual bool IsIncomplete => firstName == "" || lastName == "" || phone == "";

        public virtual string FullName => String.Format("{0} {1} {2}", lastName, firstName, middleName);

        public override string ToString()
        {
            return String.Format("{0} {1} {2}; {3}", lastName, firstName, middleName, phone);
        }

        public virtual void Transfer()
        {
            new AnyDocument().Transfer();
        }

        public override bool Equals(object obj)
        {
            var client = obj as Client;
            if (client == null) return false;
            else return Equals(client);
        }
        public bool Equals(Client other)
        {
            return other.firstName == firstName && other.middleName == middleName && other.lastName == lastName;
        }

        public override int GetHashCode()
        {
            var hashCode = -1592923394;
            hashCode = hashCode * -1521134295 + firstName.GetHashCode();
            hashCode = hashCode * -1521134295 + lastName.GetHashCode();
            hashCode = hashCode * -1521134295 + middleName.GetHashCode();
            hashCode = hashCode * -1521134295 + phone.GetHashCode();
            return hashCode;
        }
    }
}
