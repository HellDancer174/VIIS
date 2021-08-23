using ElegantLib.Requests;
using ElegantLib.Requests.JsonRequests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib.Authorize.Tokenize
{
    public class Register
    {
        private readonly IRegisterBindingModel registerBindingModel;

        public Register(IRegisterBindingModel registerBindingModel)
        {
            this.registerBindingModel = registerBindingModel;
        }
        public async Task Execute(HttpClient client, URL url)
        {
            var request = new PostJsonRequest(new JsonRequest(client, url.ToString()), JsonConvert.SerializeObject(registerBindingModel));
            var response = await request.Response();
            if (!response.IsSuccessStatusCode) throw new HttpResponseException(response);
        }
    }
}
