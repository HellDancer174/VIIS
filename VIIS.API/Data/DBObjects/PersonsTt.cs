using System;
using System.Collections.Generic;

namespace VIIS.API.Data.DBObjects
{
    public partial class PersonsTt
    {
        public PersonsTt()
        {
            EmployeesTt = new HashSet<EmployeesTt>();
            OrdersTt = new HashSet<OrdersTt>();
        }

        public PersonsTt(string firstName, string middleName, string lastName, string phone, string email, int addressId, string comment):this()
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            AddressId = addressId;
            Comment = comment;
        }

        public PersonsTt(int id, string firstName, string middleName, string lastName, string phone, string email, int addressId, string comment):
            this(firstName, middleName, lastName, phone, email, addressId, comment)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }
        public string Comment { get; set; }

        public AddressesTt Address { get; set; }
        public ICollection<EmployeesTt> EmployeesTt { get; set; }
        public ICollection<OrdersTt> OrdersTt { get; set; }
    }
}
