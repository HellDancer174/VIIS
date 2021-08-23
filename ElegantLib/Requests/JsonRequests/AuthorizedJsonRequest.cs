using System;
using System.Collections.Generic;
using System.Text;

namespace ElegantLib.Requests.JsonRequests
{
    public class AuthorizedJsonRequest : JsonRequest
    {
        private string scheme;

        public AuthorizedJsonRequest(JsonRequest other, string accessToken) : this(other, "Bearer", accessToken)
        {
        }
        public AuthorizedJsonRequest(JsonRequest other, string scheme, string accessToken) : base(other)
        {
            this.scheme = scheme;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(scheme, accessToken);
        }

        //public override void FormRequest()
        //{
        //    base.FormRequest();
        //}
    }
}
