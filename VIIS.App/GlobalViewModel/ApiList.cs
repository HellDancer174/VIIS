using ElegantLib.Authorize.Tokenize;
using ElegantLib.Requests.JsonRequests;
using ElegantLib.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Account;
using VIIS.Domain.Account.Requests;

namespace VIIS.App.GlobalViewModel
{
    public class ApiList<T>: List<T>
    {
        private readonly MemoryJwtAccount account;
        private readonly VIISJwtURL jwtURL;
        private readonly string apiUrl;
        private readonly Action<RefreshViewModel> saveToken;

        public ApiList(MemoryJwtAccount account, VIISJwtURL jwtURL, string apiUrl, Action<RefreshViewModel> saveToken)
        {
            this.account = account;
            this.jwtURL = jwtURL;
            this.apiUrl = apiUrl;
            this.saveToken = saveToken;
            //TList().Wait();
            Task.Run(async () =>
            {
                this.AddRange(await TList());
            }).Wait();
            //this.AddRange(collection);
        }
        public ApiList(VIISJwtURL jwtURL, string apiUrl, Action<RefreshViewModel> saveToken):this(new MemoryJwtAccount(new HttpClient(), jwtURL, saveToken), jwtURL, apiUrl, saveToken)
        {
        }
        public ApiList(VIISJwtURL jwtURL, string apiUrl):this(jwtURL, apiUrl, (accesstoken) => App.Token = accesstoken)
        {
        }
        private async Task<IEnumerable<T>> TList()
        {
            return await new DeserializableResponseMessage<IEnumerable<T>>(
                await new MemoryAuthorizedJsonRequest(new JsonRequest(new HttpClient(), apiUrl), App.Token, account, saveToken).Response()).DeserializedContent();
        }
    }
}
