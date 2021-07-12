using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.Domain.Staff;

namespace VIIS.API.Employees
{
    public class WorkDaysViewModel
    {
        public WorkDaysViewModel(IEnumerable<Master> masters, DateTime month)
        {
            Masters = masters;
            Month = month;
        }

        public IEnumerable<Master> Masters { get; set; }
        public DateTime Month { get; set; }
    }
}
