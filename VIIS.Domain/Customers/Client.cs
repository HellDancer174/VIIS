using ElegantLib;
using ElegantLib.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Staff.ValueClasses;
using VIMVVM;

namespace VIIS.Domain.Customers
{
    public class Client: Notifier, IDocument, IEquatable<Client>, IDocumentAsync
    {
        protected string firstName;
        protected string lastName;
        protected string middleName;
        protected string phone;
        protected string email;
        protected Address address;
        protected string comment;

        public Client(string firstName, string lastName, string middleName, string phone): this(firstName, lastName, middleName, phone, "", new Address(), "")
        {
        }
        public Client(): this("", "", "", "")
        {
        }
        public Client(Client other): this(other.firstName, other.lastName, other.middleName, other.phone, other.email, other.address, other.comment)
        {
        }

        public Client(string firstName, string lastName, string middleName, string phone, string email, Address address, string comment)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.middleName = middleName;
            this.phone = phone;
            this.email = email;
            this.address = address;
            this.comment = comment;
        }

        public virtual bool IsIncomplete => firstName == "" || lastName == "" || phone == "";

        public virtual string FullName => String.Format("{0} {1} {2}", lastName, firstName, middleName);

        public override string ToString()
        {
            return String.Format("{0} {1} {2}; {3}", lastName, firstName, middleName, phone);
        }

        //public virtual void Transfer()
        //{
        //    new AnyDocument().Transfer();
        //}

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

        public Task Transfer()
        {
            return Task.CompletedTask;
        }

        void IDocument.Transfer()
        {
            throw new NotImplementedException();
        }
    }
}
