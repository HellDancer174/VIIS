using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIIS.API.JwtBearer.Models
{
    public class Issuer
    {
        private readonly string url;

        public Issuer(string url)
        {
            this.url = url;
        }
        public Issuer(): this("VIISAPIS")
        {
        }

        public override string ToString() => url;
    }
}
