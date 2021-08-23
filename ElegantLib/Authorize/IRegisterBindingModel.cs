using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib.Authorize
{
    public interface IRegisterBindingModel
    {
        string Email { get; set; }
        string Password { get; set; }
        string ConfirmPassword { get; set; }
    }
}
