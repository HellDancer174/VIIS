using System;
using System.Collections.Generic;

namespace VIIS.API.Data.DBObjects
{
    public partial class PassportsTt
    {
        public PassportsTt()
        {
            EmployeesTt = new HashSet<EmployeesTt>();
        }

        public int Id { get; set; }
        public string Series { get; set; }
        public string PassportNumber { get; set; }
        public DateTime IssusiesDate { get; set; }
        public string Organization { get; set; }

        public ICollection<EmployeesTt> EmployeesTt { get; set; }
    }
}
