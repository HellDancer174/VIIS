using ElegantLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;

namespace VIIS.Domain.Staff.ValueClasses
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Address: Notifier, IDocument
    {
        [JsonProperty] protected readonly int id;
        [JsonProperty] protected int index;
        [JsonProperty] protected string city;
        [JsonProperty] protected string street;
        [JsonProperty] protected string house;
        [JsonProperty] protected string flat;

        public Address(int id, int index, string city, string street, string house, string flat)
        {
            this.id = id;
            this.index = index;
            this.city = city;
            this.street = street;
            this.house = house;
            this.flat = flat;
        }
        public Address(int index, string city, string street, string house, string flat):
            this(0, index, city, street, house, flat)
        {
        }
        public Address(Address other): this(other.id, other.index, other.city, other.street, other.house, other.flat)
        {
        }
        public Address(): this(000000, nameof(city), nameof(street), nameof(house), nameof(flat))
        {
        }

        public override string ToString()
        {
            return String.Format("Почтовый индекс: {0}, город: {1}, улица: {2}, дом: {3}, квартира: {4}", index, city, street, house, flat);
        }

        public virtual void Transfer()
        {
            return;
        }
    }
}
