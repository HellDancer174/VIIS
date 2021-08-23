using ElegantLib.Authorize.Tokenize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib.Authorize
{
    public interface IAccount
    {
        Task ChangePassword(ChangePasswordModel model, RefreshViewModel token);
    }
}
