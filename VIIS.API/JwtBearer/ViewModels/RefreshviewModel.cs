using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIIS.API.JwtBearer.ViewModels
{
    public class RefreshViewModel
    {

        public RefreshViewModel(string token, string refreshToken)
        {
            Token = token;
            RefreshToken = refreshToken;
        }

        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}
