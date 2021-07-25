using ElegantLib.Authorize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Data
{
    public class VIISChangePasswordModel : ChangePasswordModel
    {
        public VIISChangePasswordModel(string email, string userName, string oldPassword, string newPassword) : base(email, oldPassword, newPassword)
        {
            UserName = userName;
        }

        public string UserName { get; }
    }
}
