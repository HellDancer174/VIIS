using ElegantLib.Authorize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.VIIS.Domain.Data
{
    public class VIISRegisterModel : RegisterModel
    {
        public VIISRegisterModel(string email, string userName, string password, string confirmPassword) : base(email, password, confirmPassword)
        {
            UserName = userName;
        }

        public string UserName { get; }
    }
}
