using ElegantLib.Authorize.Tokenize;
using ElegantLib.Requests;
using ElegantLib.Requests.JsonRequests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib.Authorize
{
    public abstract class Account<T> : IRegister, IAuthorize<T>, IAccount
    {
        protected readonly HttpClient client;
        protected readonly URL url;

        public Account(HttpClient client, URL accountUrl)
        {
            this.client = client;
            this.url = accountUrl;
        }
        public virtual async Task Register(IRegisterBindingModel model)
        {
            var request = new PostJsonRequest(new JsonRequest(client, url.RegisterURL), JsonConvert.SerializeObject(model));
            var response = await request.Response();
            if (!response.IsSuccessStatusCode) throw new HttpResponseException(response);
        }
        public abstract Task<T> Login(string login, string password);

        public virtual async Task ChangePassword(ChangePasswordModel model, RefreshViewModel token)
        {
            var request = new AuthorizedJsonRequest(new PostJsonRequest(new JsonRequest(client, url.ChangePasswordURL), JsonConvert.SerializeObject(model)), token.AccessToken);
            var response = await request.Response();
            if (!response.IsSuccessStatusCode) throw new HttpResponseException(response);
        }
        public abstract Task LogOut(RefreshViewModel token);

        //public abstract Task Execute(HttpClient client, URL url);
        //public abstract Task<T> Login(HttpClient client, URL url);
    }
}
