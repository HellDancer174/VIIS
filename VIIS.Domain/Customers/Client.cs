using ElegantLib;
using ElegantLib.Documents;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Staff.ValueClasses;
using VIMVVM;

namespace VIIS.Domain.Customers
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Client: Notifier, IDocument, IEquatable<Client>, IDocumentAsync
    {

        [JsonProperty] protected string firstName;
        [JsonProperty] protected string lastName;
        [JsonProperty] protected string middleName;
        [JsonProperty] protected string phone;
        [JsonProperty] protected string email;
        [JsonProperty] protected Address address;
        [JsonProperty] protected string comment;
        [JsonProperty] protected readonly int id;

        public Client(int id, string firstName, string lastName, string middleName, string phone) : this(id, firstName, lastName, middleName, phone, "", new Address(), "")
        {
            this.id = id;
        }
        public Client(string firstName, string lastName, string middleName, string phone): this(0, firstName, lastName, middleName, phone)
        {
        }
        public Client(): this("", "", "", "")
        {
        }
        public Client(Client other): this(other.id, other.firstName, other.lastName, other.middleName, other.phone, other.email, other.address, other.comment)
        {
        }

        public Client(int id, string firstName, string lastName, string middleName, string phone, string email, Address address, string comment)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.middleName = middleName;
            this.phone = phone;
            this.email = email;
            this.address = address;
            this.comment = comment;
        }
        public Client(string firstName, string lastName, string middleName, string phone, string email, Address address, string comment):
            this(0, firstName, lastName, middleName, phone, email, address, comment)
        {
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

        public virtual Task TransferAsync()
        {
            return Task.CompletedTask;
        }

        public virtual void Transfer()
        {
            return;
        }
    }
}
