using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Staff.ValueClasses
{
    public class WorkDaysList
    {
        private readonly List<DateTime> dates;

        public WorkDaysList(List<DateTime> dates)
        {
            this.dates = dates;
        }
        public WorkDaysList(): this(new List<DateTime> { DateTime.Now.Date })
        {
        }

        public bool IsWorkDay(DateTime date)
        {
            return dates.Contains(date.Date);
        }
    }
}
