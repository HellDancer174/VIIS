using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIIS.API.JwtBearer.Models
{
    public class VITokenValidParameters : TokenValidationParameters
    {
        public VITokenValidParameters(Issuer issuer, Audience audience, Key key):
            base(new TokenValidationParameters() { ValidIssuer = issuer.ToString(), ValidAudience = audience.ToString(),
                IssuerSigningKey = new SymmetricSecurityKey(key.Bytes)})
        {
        }
    }
}
