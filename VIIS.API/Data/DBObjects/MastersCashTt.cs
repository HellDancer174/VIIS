using System;
using System.Collections.Generic;

namespace VIIS.API.Data.DBObjects
{
    public partial class MastersCashTt
    {
        public int MasterId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public decimal Value { get; set; }
    }
}
