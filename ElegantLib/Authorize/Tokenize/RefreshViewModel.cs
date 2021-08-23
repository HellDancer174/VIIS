using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib.Authorize.Tokenize
{
    public class RefreshViewModel
    {
        public RefreshViewModel(string accessToken, string refreshToken) //В проекте вместо статической константы сделать класс с конструктором по умолчанию
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
        public RefreshViewModel(): this("", "")
        {
        }

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

    }
}
