using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib.Requests
{
    public class HttpResponseException : HttpRequestException
    {
        private readonly HttpResponseMessage response;
        private string message;

        public override string Message => String.Format("{0}; {1}", response.StatusCode, message);

        public HttpResponseException(HttpResponseMessage response): base()
        {
            this.response = response;
            Task.Run(async () => message = await response.Content.ReadAsStringAsync()).Wait();
        }
        public bool StatusCodesEquals(HttpStatusCode other) => other == response.StatusCode;

        public string Reason()
        {
            return String.Format("{0}; {1}", response.ReasonPhrase, response.StatusCode);
        }
    }
}
