using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ElegantLib.Requests.JsonRequests
{
    public class PostJsonRequest : JsonRequestWithContent
    {
        public PostJsonRequest(JsonRequest other, string jsonEntity) : this(other, new StringContent(jsonEntity))
        {
        }

        public PostJsonRequest(JsonRequest other, HttpContent content) : base(other, content)
        {
            request.Method = HttpMethod.Post;
        }


        //public override void FormRequest()
        //{
        //    base.FormRequest();
        //    request.Method = HttpMethod.Post;
        //}
    }
}
