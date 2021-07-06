using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIIS.API.JwtBearer.Models
{
    public static class JwtAuthScheme
    {
        public const string scheme = "Identity.Application," + JwtBearerDefaults.AuthenticationScheme;

    }
}
