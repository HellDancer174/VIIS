using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib.Requests
{
    public class URL : IURL
    {
        protected readonly string url;

        public URL(string url)
        {
            this.url = url;
        }

        public override string ToString()
        {
            return url;
        }
        public virtual string RegisterURL => string.Format("{0}/Account/Register", url);
        public virtual string LoginURL => string.Format("{0}/Account/Token", url);
        public virtual string ChangePasswordURL => string.Format("{0}/Account/ChangePassword", url);
        public virtual string LogOutURL => string.Format("{0}/Account/Logout", url);



    }
}
