using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib.Responses
{
    public class DeserializableResponseMessage<T>: HttpResponseMessage
    {
        private readonly HttpResponseMessage message;

        public DeserializableResponseMessage(HttpResponseMessage message): base(message.StatusCode)
        {
            Version = message.Version;
            Content = message.Content;
            ReasonPhrase = message.ReasonPhrase;
            RequestMessage = message.RequestMessage;
            this.message = message;
        }

        public new HttpResponseHeaders Headers => message.Headers;

        public async Task<string> StringContent()
        {
            return await message.Content.ReadAsStringAsync();
        }

        public async Task<T> DeserializedContent()
        {
            return JsonConvert.DeserializeObject<T>(await StringContent());
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            message.Dispose();
        }
    }
}
