using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Staff.ValueClasses.Decorators
{
    public class DecoratablePassport : Passport
    {
        private readonly Passport other;

        public DecoratablePassport(Passport other) : base(other)
        {
            this.other = new Passport(other);
        }
    }
}
