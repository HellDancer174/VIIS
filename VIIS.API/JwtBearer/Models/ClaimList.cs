using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace VIIS.API.JwtBearer.Models
{
    public class ClaimList: List<Claim>
    {
        public ClaimList(IEnumerable<Claim> claims): base(claims)
        {
        }
        public ClaimList(string username):this(Claims(username))
        {
        }
        public ClaimList() : this("Vik")
        {
        }
        private static IEnumerable<Claim> Claims(string username)
        {
            var list = new List<Claim>();
            list.Add(new Claim(JwtRegisteredClaimNames.Sub, username));
            list.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            list.Add(new Claim(JwtRegisteredClaimNames.UniqueName, username));
            return list;
        }
    }
}
