using ElegantLib.Authorize.Tokenize;
using ElegantLib.Requests.JsonRequests;
using ElegantLib.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Account;
using VIIS.Domain.Account.Requests;

namespace VIIS.Domain.Customers.Decorators
{
    public class InsertableClient : ClientDecorator
    {
        private readonly Action<RefreshViewModel> saveToken;
        private readonly RefreshViewModel token;
        protected readonly VIISJwtURL url = new VIISJwtURL();
        protected JsonRequestWithContent request;
        protected StringContent entity;
        protected readonly JsonRequest baseRequest;

        public InsertableClient(Client other, Action<RefreshViewModel> saveToken, RefreshViewModel token) : base(other)
        {
            this.saveToken = saveToken;
            this.token = token;
            entity = new StringContent(JsonConvert.SerializeObject(this));
            baseRequest = new JsonRequest(url.ClientsUrl);
            request = new PostJsonRequest(baseRequest, entity);

        }

        public override async Task TransferAsync()
        {
            await new MemoryAuthorizedJsonRequest(request, token, new MemoryJwtAccount(new HttpClient(), url, saveToken), saveToken).Response();
        }
    }
}
