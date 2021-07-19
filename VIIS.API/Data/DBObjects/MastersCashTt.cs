using System;
using System.Collections.Generic;

namespace VIIS.API.Data.DBObjects
{
    public partial class MastersCashTt
    {
        public MastersCashTt(int masterId, DateTime startDate, DateTime finishDate, decimal value)
        {
            MasterId = masterId;
            StartDate = startDate;
            FinishDate = finishDate;
            Value = value;
        }
        public MastersCashTt()
        {

        }

        public int MasterId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public decimal Value { get; set; }

        public EmployeesTt Employee { get; set; }

    }
}
