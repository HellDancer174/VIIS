using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIIS.API.JwtBearer.Models
{
    public class Audience
    {
        private readonly string url;

        public Audience(string url)
        {
            this.url = url;
        }
        public Audience(): this("VIISAPIU")
        {
        }

        public override string ToString() => url;

    }
}
