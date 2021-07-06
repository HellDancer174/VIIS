using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.API.JwtBearer.Models
{
    public class Key
    {
        private readonly string key;

        public Key(string key)
        {
            this.key = key;
        }
        public Key(): this("4597631852945678")
        {
        }

        public byte[] Bytes => Encoding.UTF8.GetBytes(key);
    }
}
