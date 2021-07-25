using ElegantLib.Authorize.Tokenize;
using ElegantLib.Requests;
using ElegantLib.Requests.JsonRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.Account.Models.Requests;

namespace VIIS.App.Account.Models
{
    public class MemoryJwtAccount : JwtAccount
    {
        public MemoryJwtAccount(HttpClient client, URL accountUrl) : base(client, accountUrl)
        {
        }

        protected override AuthorizedJsonRequest AuthorizedRequest(JsonRequest request, RefreshViewModel token)
        {
            return new MemoryAuthorizedJsonRequest(request, token, this);
        }
    }
}
