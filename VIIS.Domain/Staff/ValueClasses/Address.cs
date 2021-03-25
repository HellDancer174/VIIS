using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Staff.ValueClasses
{
    public class Address
    {
        protected int index;
        protected string city;
        protected string street;
        protected string house;
        protected string flat;

        public Address(int index, string city, string street, string house, string flat)
        {
            this.index = index;
            this.city = city;
            this.street = street;
            this.house = house;
            this.flat = flat;
        }
        public Address(Address other): this(other.index, other.city, other.street, other.house, other.flat)
        {
        }
        public Address(): this(000000, nameof(city), nameof(street), nameof(house), nameof(flat))
        {
        }

        public override string ToString()
        {
            return String.Format("Почтовый индекс: {0}, город: {1}, улица: {2}, дом: {3}, квартира: {4}", index, city, street, house, flat);
        }
    }
}
