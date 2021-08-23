using ElegantLib.Authorize.Tokenize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib.Requests.JsonRequests
{
    public class JwtAuthorizedJsonRequest : AuthorizedJsonRequest
    {
        private readonly RefreshViewModel loginViewModel;
        private readonly JwtAccount account;

        public JwtAuthorizedJsonRequest(JsonRequest other, RefreshViewModel loginViewModel, JwtAccount account) : base(other, "Bearer", loginViewModel.AccessToken)
        {
            this.loginViewModel = loginViewModel;
            this.account = account;
        }

        public override async Task<HttpResponseMessage> Response()
        {
            var response = await base.Response();
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var request = new JwtAuthorizedJsonRequest(this, await account.Login(loginViewModel), account);
                return await request.Response();
            }
            else return response;
        }
    }
}
