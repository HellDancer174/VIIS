using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ElegantLib.Requests.JsonRequests
{
    public class JsonRequestWithContent : JsonRequest
    {
        protected readonly JsonRequest primary;
        //private readonly string jsonEntity;

        //public JsonRequestWithContent(JsonRequest other, string jsonEntity) : base(other)
        //{
        //    primary = other;
        //    //this.jsonEntity = jsonEntity;
        //    var content = new StringContent(jsonEntity);
        //    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        //    request.Content = content;
        //}
        public JsonRequestWithContent(JsonRequest other, HttpContent content) : base(other)
        {
            primary = other;
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            request.Content = content;
        }
        public JsonRequestWithContent(JsonRequestWithContent other):this(other, other.request.Content)
        {

        }


        //public override void FormRequest()
        //{
        //    primary.FormRequest();
        //    //var content = new StringContent(jsonEntity);
        //    //content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        //    //request.Content = content;
        //}
    }
}
