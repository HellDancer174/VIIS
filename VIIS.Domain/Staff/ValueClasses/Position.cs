using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Staff.ValueClasses
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Position: IEquatable<Position>
    {
        [JsonProperty] private readonly string position;

        public Position(string position)
        {
            this.position = position;
        }
        public Position(): this("Мастер - парикмахер")
        {
        }

        public bool IsEmpty => string.IsNullOrEmpty(position) || string.IsNullOrWhiteSpace(position);

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
