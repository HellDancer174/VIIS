using ElegantLib.Authorize.Tokenize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Account
{
    public class VIISJwtURL : JwtURL
    {
        public VIISJwtURL() : base("https://localhost:44395/")
        {
        }

        public virtual string ClientsUrl => string.Format("{0}/api/Clients", url);
        public virtual string UsersURL => string.Format("{0}/Account/GetUsers", url);

    }
}
