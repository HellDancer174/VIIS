using ElegantLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Global
{
    [JsonObject(MemberSerialization.OptIn)]
    public class User : IEquatable<User>, IDocumentAsync
    {
        [JsonProperty] protected string name;
        [JsonProperty] protected string email;

        public User(string name, string email)
        {
            this.name = name;
            this.email = email;
        }
        public User(User other): this(other.name, other.email)
        {
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as User);
            //var user = obj as User;
            //if (!(obj is User)) return false;
            //else return name == user.name && email == user.email;
        }

        public bool Equals(User other)
        {
            return other != null &&
                   name == other.name &&
                   email == other.email;
        }

        public override int GetHashCode()
        {
            var hashCode = -1607328867;
            hashCode = hashCode * -1521134295 + name.GetHashCode();
            hashCode = hashCode * -1521134295 + email.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return name;
        }

        public virtual Task TransferAsync()
        {
            throw new NotImplementedException();
        }
    }
}
