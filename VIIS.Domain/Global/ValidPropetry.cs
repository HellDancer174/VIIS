using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Global
{
    public class ValidPropetry
    {
        private readonly string name;
        private readonly string value;
        private readonly bool condition;

        public ValidPropetry(string name, string value, bool condition)
        {
            this.name = name;
            this.value = value;
            this.condition = condition;
        }

        public virtual void Validate()
        {
            if (condition) return;
            else throw new ArgumentException(ToString());
        }


        public override string ToString()
        {
            return string.Format("\nНекорректное поле {0}: {1}\n", name, String.IsNullOrEmpty(value) ? "Нет данных":value);
        }
    }
}
