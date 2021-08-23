using ElegantLib.Requests;
using ElegantLib.Requests.JsonRequests;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib.Authorize.Tokenize
{
    public class TokenAuthorize
    {
        private readonly string login;
        private readonly string password;

        public TokenAuthorize(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
        public virtual async Task<Token> Login(HttpClient client, URL url)
        {
            var keyvalue = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("username", login),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };
            var request = new PostJsonRequest(new JsonRequest(client, url.ToString()), new FormUrlEncodedContent(keyvalue));
            var response = await request.Response();
            if (!response.IsSuccessStatusCode) throw new HttpResponseException(response);
            var jwt = await response.Content.ReadAsStringAsync();
            JObject jwtObject = JObject.Parse(jwt);
            var accessToken = jwtObject.Value<string>("access_token");
            var expires = jwtObject.Value<DateTime>(".expires");
            return new Token(accessToken, expires);
        }

    }
}
