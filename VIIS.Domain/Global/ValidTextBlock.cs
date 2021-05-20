using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Global
{
    public class ValidTextBlock: ValidProperty<string>
    {

        public ValidTextBlock(string name, string value, bool condition): base(name, value, condition)
        {
        }

        public override string ToString()
        {
            return string.Format("\nНекорректное поле {0}: {1}\n", name, String.IsNullOrEmpty(value) ? "Нет данных":value);
        }
    }
}
