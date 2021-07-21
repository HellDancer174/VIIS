using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.Domain.Global;

namespace VIIS.API.GlobalModel
{
    public class ValidID: ValidProperty<int>
    {

        public ValidID(int id) : this("id", id, id > 0)
        {
        }
        public ValidID(int id, bool condition):this("id", id, condition)
        {
        }
        public ValidID(string name, int value, bool condition) : base(name, value, condition)
        {
        }
        public ValidID(string name, int value, Func<int, bool> conditionsFunc):this(name, value, conditionsFunc.Invoke(value))
        {
        }

        public override string ToString() => string.Format("\nНекорректный идентификатор {0}: {1}\n", name, value.ToString());
    }
}
