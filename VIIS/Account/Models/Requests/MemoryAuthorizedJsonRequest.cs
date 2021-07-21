using ElegantLib.Authorize.Tokenize;
using ElegantLib.Requests;
using ElegantLib.Requests.JsonRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.App.Account.Models.Requests
{
    class MemoryAuthorizedJsonRequest : AuthorizedJsonRequest
    {
        private readonly JsonRequest mainRequest;
        private readonly RefreshViewModel tokenViewModel;
        private readonly JwtAccount account;
        private readonly Action<RefreshViewModel> saveToken;

        public MemoryAuthorizedJsonRequest(JsonRequest other, RefreshViewModel tokenViewModel, JwtAccount account) : this(other, tokenViewModel, account, (token) => App.Token = token)
        {
            this.mainRequest = other;
            this.tokenViewModel = tokenViewModel;
            this.account = account;
        }
        public MemoryAuthorizedJsonRequest(JsonRequest other, RefreshViewModel tokenViewModel, JwtAccount account, Action<RefreshViewModel> saveToken) : base(other, "Bearer", tokenViewModel.AccessToken)
        {
            this.mainRequest = other;
            this.tokenViewModel = tokenViewModel;
            this.account = account;
            this.saveToken = saveToken;
        }
        public override async Task<HttpResponseMessage> Response()
        {
            var response = await base.Response();
            if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                var tokenVM = await account.Login(tokenViewModel);
                saveToken.Invoke(tokenVM);
                var newResponse = await new AuthorizedJsonRequest(mainRequest, tokenVM.AccessToken).Response();
                if (newResponse.IsSuccessStatusCode) return newResponse;
                else throw new HttpResponseException(newResponse);
            }
            return response;
        }
    }
}
