using ElegantLib.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib.Authorize.Tokenize
{
    public class JwtURL : URL
    {
        public JwtURL(string url) : base(url)
        {
        }

        public virtual string RefreshTokenURL => String.Format("{0}/Account/Refresh", url);
        public override string LoginURL => string.Format("{0}/Account/Login", url);
    }
}
