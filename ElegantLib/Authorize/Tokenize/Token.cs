using ElegantLib.Requests;
using ElegantLib.Requests.JsonRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib.Authorize.Tokenize
{
    public class Token
    {
        private readonly string type;
        private readonly string value;
        private readonly DateTime expires;
        public Token(string type, string value, DateTime expires)
        {
            this.type = type;
            this.value = value;
            this.expires = expires;
        }
        public Token(string value, DateTime expires) : this("Bearer", value, expires)
        {
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", type, value);
        }
    }
}
