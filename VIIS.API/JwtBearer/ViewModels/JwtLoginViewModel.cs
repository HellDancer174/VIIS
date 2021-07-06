using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIIS.API.JwtBearer.ViewModels
{
    public class JwtLoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
