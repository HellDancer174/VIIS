using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIIS.API.JwtBearer.Models
{
    public static class Helpers
    {
        public static Dictionary<string, string> UserNameRefreshToken { get; } = new Dictionary<string, string>();
    }
}
