using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Staff.ValueClasses
{
    public class WorkDaysList: List<DateTime>
    {

        public WorkDaysList(List<DateTime> dates): base(dates)
        {
        }
        public WorkDaysList(): this(new List<DateTime>() /*{ DateTime.Now.Date }*/)
        {
        }

        public bool IsWorkDay(DateTime date)
        {
            return this.Contains(date.Date);
        }
    }
}
