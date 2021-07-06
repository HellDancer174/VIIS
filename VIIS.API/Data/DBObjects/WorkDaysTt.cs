using System;
using System.Collections.Generic;

namespace VIIS.API.Data.DBObjects
{
    public partial class WorkDaysTt
    {
        public int MasterId { get; set; }
        public DateTime WorkDate { get; set; }

        public EmployeesTt Master { get; set; }
    }
}
