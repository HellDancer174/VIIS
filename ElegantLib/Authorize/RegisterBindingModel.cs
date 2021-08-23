using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib.Authorize
{
    public class RegisterBindingModel: IRegisterBindingModel
    {
        public string Email { get; set; }
        public double Rate { get; set; }
        public string Position { get; set; }
        public string QualificationClass { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
