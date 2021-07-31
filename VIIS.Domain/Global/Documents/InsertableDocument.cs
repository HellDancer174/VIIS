using ElegantLib;
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
using VIIS.Domain.Account;
using VIIS.Domain.Account.Requests;

namespace VIIS.Domain.Global.Documents
{
    public class InsertableDocument: IDocumentAsync
    {
        private readonly IDocumentAsync document;
        private readonly Action<RefreshViewModel> saveToken;
        private readonly RefreshViewModel token;

        protected JsonRequestWithContent request;
        protected StringContent entity;
        protected readonly JsonRequest baseRequest;

        public InsertableDocument(IDocumentAsync document, Action<RefreshViewModel> saveToken, RefreshViewModel token, string url)
        {
            this.document = document;
            this.saveToken = saveToken;
            this.token = token;
            entity = new StringContent(JsonConvert.SerializeObject(document));
            baseRequest = new JsonRequest(url);
            request = new PostJsonRequest(baseRequest, entity);

        }

        public virtual async Task TransferAsync()
        {
            var response = await new MemoryAuthorizedJsonRequest(request, token, new MemoryJwtAccount(new HttpClient(), new VIISJwtURL(), saveToken), saveToken).Response();
            if (!response.IsSuccessStatusCode) throw new HttpResponseException(response);
        }
    }
}
