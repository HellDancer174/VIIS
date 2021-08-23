using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib.Primitives
{
    public class Date
    {
        private readonly DateTime dateTime;

        public Date(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }
        public Date(int year, int month, int day): this(new DateTime(year, month, day))
        {
        }

        public override string ToString()
        {
            return String.Format("{0}.{1}.{2}", dateTime.Day, dateTime.Month, dateTime.Year);
        }
    }
}
