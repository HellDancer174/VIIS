using System;
using System.Collections.Generic;

namespace VIIS.API.Data.DBObjects
{
    public partial class AddressesTt
    {
        public AddressesTt()
        {
            PersonsTt = new HashSet<PersonsTt>();
        }

        public AddressesTt(int? postcode, string city, string street, string house, string flat):this()
        {
            Postcode = postcode;
            City = city;
            Street = street;
            House = house;
            Flat = flat;
        }

        public AddressesTt(int id, int? postcode, string city, string street, string house, string flat): this(postcode, city, street, house, flat)
        {
            Id = id;
        }

        public int Id { get; set; }
        public int? Postcode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Flat { get; set; }

        public ICollection<PersonsTt> PersonsTt { get; set; }
    }
}
