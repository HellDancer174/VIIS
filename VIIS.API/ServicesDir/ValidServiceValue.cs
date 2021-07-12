using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.GlobalModel;

namespace VIIS.API.ServicesDir
{
    public class ValidServiceValue : DBServiceValue
    {
        private readonly DBServiceValue primary;

        public ValidServiceValue(DBServiceValue other) : base(other)
        {
            this.primary = other;
        }

        public override void Transfer()
        {
            new ValidID(id).Validate();
            primary.Transfer();
        }
    }
}
