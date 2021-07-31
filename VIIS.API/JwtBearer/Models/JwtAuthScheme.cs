using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIIS.API.JwtBearer.Models
{
    public static class AuthSchemes
    {
        public const string JwtScheme = "Identity.Application," + JwtBearerDefaults.AuthenticationScheme;

    }
}
