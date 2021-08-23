using ElegantLib;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib.Requests.JsonRequests
{
    public class JsonRequest : IHttpRequest
    {
        protected readonly HttpClient client;
        private readonly string url;
        protected HttpRequestMessage request;

        public JsonRequest(HttpClient client, string url): this(client, url, new HttpRequestMessage(HttpMethod.Get, url))
        {
        }
        public JsonRequest(HttpClient client, string url, HttpRequestMessage requestMessage)
        {
            this.client = client;
            this.url = url;
            request = requestMessage;
        }
        public JsonRequest(JsonRequest other):this(other.client, other.url, other.request)
        {
        }
        public JsonRequest(string url)
        {
            this.client = new HttpClient();
            this.url = url;
            request = new HttpRequestMessage(HttpMethod.Get, url);
        }

        public virtual async Task<HttpResponseMessage> Response()
        {
            return await client.SendAsync(request);
        }

        //public virtual void FormRequest()
        //{
        //    request.Method = HttpMethod.Get;
        //}
    }
}
