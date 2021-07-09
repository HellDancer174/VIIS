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

        public PassportsTt(int id, string series, string passportNumber, DateTime issusiesDate, string organization)
        {
            Id = id;
            Series = series;
            PassportNumber = passportNumber;
            IssusiesDate = issusiesDate;
            Organization = organization;
        }

        public int Id { get; set; }
        public string Series { get; set; }
        public string PassportNumber { get; set; }
        public DateTime IssusiesDate { get; set; }
        public string Organization { get; set; }

        public ICollection<EmployeesTt> EmployeesTt { get; set; }
    }
}
