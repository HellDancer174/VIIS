using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.Domain.Global;

namespace VIIS.API.GlobalModel
{
    public class ValidID: ValidProperty<int>
    {

        public ValidID(int id) : base("id", id, id > 0)
        {
        }

        public override string ToString() => string.Format("\nНекорректный идентификатор {0}: {1}\n", name, value.ToString());
    }
}
