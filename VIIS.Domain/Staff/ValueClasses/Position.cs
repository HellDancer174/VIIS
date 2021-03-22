using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Staff.ValueClasses
{
    public class Position: IEquatable<Position>
    {
        private readonly string position;

        public Position(string position)
        {
            this.position = position;
        }
        public Position(): this("Мастер - парикмахер")
        {
        }

        public override string ToString()
        {
            return position;
        }

        public virtual bool Equals(Position other)
        {
            return position == other.position;
        }
    }
}
