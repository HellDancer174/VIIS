using ElegantLib.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib.Authorize
{
    interface IRegister
    {
        Task Register(IRegisterBindingModel registerModel);
    }
}
