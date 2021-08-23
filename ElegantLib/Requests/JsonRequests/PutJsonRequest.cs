using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ElegantLib.Requests.JsonRequests
{
    public class PutJsonRequest : JsonRequestWithContent
    {
        public PutJsonRequest(JsonRequest other, HttpContent content) : base(other, content)
        {
            request.Method = HttpMethod.Put;
        }

        public PutJsonRequest(JsonRequest other, string jsonEntity) : this(other, new StringContent(jsonEntity))
        {
        }


        //public override void FormRequest()
        //{
        //    base.FormRequest();
        //}
    }
}
