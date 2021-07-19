using System;
using System.Collections.Generic;

namespace VIIS.API.Data.DBObjects
{
    public partial class EmployeesTt
    {
        public EmployeesTt()
        {
            OrdersTt = new HashSet<OrdersTt>();
            WorkDaysTt = new HashSet<WorkDaysTt>();
        }

        public EmployeesTt(int id, int personId, string position, DateTime birthday, int contractId, DateTime startDate, int passportId)
        {
            Id = id;
            PersonId = personId;
            Position = position;
            Birthday = birthday;
            ContractId = contractId;
            StartDate = startDate;
            PassportId = passportId;
        }

        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Position { get; set; }
        public DateTime Birthday { get; set; }
        public int ContractId { get; set; }
        public DateTime StartDate { get; set; }
        public int PassportId { get; set; }

        public PassportsTt Passport { get; set; }
        public PersonsTt Person { get; set; }
        public ICollection<OrdersTt> OrdersTt { get; set; }
        public ICollection<WorkDaysTt> WorkDaysTt { get; set; }
        public ICollection<MastersCashTt> MastersCashTt { get; set; }
    }
}
