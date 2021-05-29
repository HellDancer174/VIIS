using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Global
{
    public class ValidProperty<T>
    {
        protected readonly string name;
        protected readonly T value;
        protected readonly bool condition;

        public ValidProperty(string name, T value, bool condition)
        {
            this.name = name;
            this.value = value;
            this.condition = condition;
        }

        public virtual void Validate(string messageOfFail)
        {
            if (condition) return;
            else throw new ArgumentException(messageOfFail);
        }

        public virtual void Validate() => Validate(ToString());


        public override string ToString()
        {
            return string.Format("\nНекорректное поле {0}: {1}\n", name, value == null ? "Нет данных" : value.ToString());
        }

    }
}
