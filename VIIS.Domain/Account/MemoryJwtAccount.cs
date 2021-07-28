using ElegantLib.Authorize.Tokenize;
using ElegantLib.Requests;
using ElegantLib.Requests.JsonRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Account.Requests;

namespace VIIS.Domain.Account
{
    public class MemoryJwtAccount : JwtAccount
    {
        private readonly Action<RefreshViewModel> saveToken;

        public MemoryJwtAccount(HttpClient client, URL accountUrl, Action<RefreshViewModel> saveToken) : base(client, accountUrl)
        {
            this.saveToken = saveToken;
        }


        protected override AuthorizedJsonRequest AuthorizedRequest(JsonRequest request, RefreshViewModel token)
        {
            return new MemoryAuthorizedJsonRequest(request, token, this, saveToken);
        }
    }
}
