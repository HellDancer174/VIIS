using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace VIIS.API.JwtBearer.Models
{
    public class RefreshToken
    {
        private readonly byte[] randomNumber;

        public RefreshToken(byte[] randomNumber)
        {
            this.randomNumber = randomNumber;
        }
        public RefreshToken():this(new byte[32])
        {
        }

        public string Value()
        {
            if (randomNumber.Length != 32) return Token(new byte[32]);
            else return Token(randomNumber);
        }

        private string Token(byte[] rndNumber)
        {
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(rndNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
