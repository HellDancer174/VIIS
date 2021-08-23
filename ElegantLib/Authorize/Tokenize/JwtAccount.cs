using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ElegantLib.Requests;
using ElegantLib.Requests.JsonRequests;
using Newtonsoft.Json;

namespace ElegantLib.Authorize.Tokenize
{
    public class JwtAccount : Account<RefreshViewModel>
    {
        private readonly JwtURL accountUrl;

        public JwtAccount(HttpClient client, URL accountUrl) : base(client, accountUrl) //В проекте вместо статической константы сделать класс с конструктором по умолчанию
        {
            this.accountUrl = new JwtURL(accountUrl.ToString());
            
        }

        public override async Task<RefreshViewModel> Login(string login, string password)
        {
            var request = new PostJsonRequest(new JsonRequest(client, accountUrl.LoginURL), JsonConvert.SerializeObject(new { UserName = login, Password = password }));
            return await Token(request);
        }

        protected virtual async Task<RefreshViewModel> Token(PostJsonRequest request)
        {
            HttpContent content = await Content(request);
            return JsonConvert.DeserializeObject<RefreshViewModel>(await content.ReadAsStringAsync());
        }

        protected virtual async Task<HttpContent> Content(JsonRequest request)
        {
            var response = await request.Response();
            if (!response.IsSuccessStatusCode) throw new HttpResponseException(response);
            return response.Content;
        }

        protected virtual AuthorizedJsonRequest AuthorizedRequest(JsonRequest request, RefreshViewModel token)
        {
            return new AuthorizedJsonRequest(request, token.AccessToken);
        }

        public virtual async Task<RefreshViewModel> Login(RefreshViewModel jwtLoginViewModel)
        {
            var request = new PostJsonRequest(new JsonRequest(client, accountUrl.RefreshTokenURL), JsonConvert.SerializeObject(jwtLoginViewModel));
            return await Token(request);
        }

        public async Task Register(IRegisterBindingModel model, RefreshViewModel token)
        {
            var request = AuthorizedRequest(new PostJsonRequest(new JsonRequest(client, url.RegisterURL), JsonConvert.SerializeObject(model)), token);
            await Content(request);
        }

        public override async Task ChangePassword(ChangePasswordModel model, RefreshViewModel token)
        {
            var json = JsonConvert.SerializeObject(model);
            var request = AuthorizedRequest(new PostJsonRequest(new JsonRequest(client, url.ChangePasswordURL), json), token);
            await Content(request);
        }

        public override async Task LogOut(RefreshViewModel token)
        {
            var request = AuthorizedRequest(new PostJsonRequest(new JsonRequest(client, url.LogOutURL), JsonConvert.SerializeObject(new { })), token);
            await Content(request);
        }


        //public virtual async Task<string> Register(IRegisterBindingModel model)
        //{
        //    var request = new PostJsonRequest(new JsonRequest(client, accountUrl.RegisterURL), JsonConvert.SerializeObject(model));
        //    try
        //    {
        //        await Content(request);
        //        return "Вы успешно зарегистрированы";
        //    }
        //    catch (HttpResponseException ex)
        //    {
        //        return ex.Reason();
        //    }
        //}


    }
}
