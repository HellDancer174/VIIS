using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ElegantLib.Requests.JsonRequests
{
    public class DeleteJsonRequest : JsonRequestWithContent
    {
        public DeleteJsonRequest(JsonRequest other, string jsonEntity) : this(other, new StringContent(jsonEntity))
        {
        }
        public DeleteJsonRequest(JsonRequest other, HttpContent content) : base(other, content)
        {
            request.Method = HttpMethod.Delete;
        }

        //public override void FormRequest()
        //{
        //    base.FormRequest();
        //}
    }
}
