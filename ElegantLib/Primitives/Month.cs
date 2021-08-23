using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib.Primitives
{
    public class Month
    {
        //private readonly Dictionary<string, int> monthNameNumber;
        private readonly DateTime dateTime;

        //public Month(string month, int year)
        //{
        //    monthNameNumber = new Dictionary<string, int>(12);
        //    monthNameNumber.Add("январь", 1);
        //    monthNameNumber.Add("февраль", 2);
        //    monthNameNumber.Add("март", 3);
        //    monthNameNumber.Add("апрель", 4);
        //    monthNameNumber.Add("май", 5);
        //    monthNameNumber.Add("июнь", 6);
        //    monthNameNumber.Add("июль", 7);
        //    monthNameNumber.Add("август", 8);
        //    monthNameNumber.Add("сентябрь", 9);
        //    monthNameNumber.Add("октябрь", 10);
        //    monthNameNumber.Add("ноябрь", 11);
        //    monthNameNumber.Add("декабрь", 12);
        //    dateTime = new DateTime(year, monthNameNumber[month], 1);
        //}

        public Month(int month, int year)
        {
            dateTime = new DateTime(year, month, 1);
        }
        public Month(DateTime date)
        {
            dateTime = date;
        }

        public List<int> Days()
        {
            var list = new List<int>(28);
            var count = DateTime.DaysInMonth(dateTime.Year, dateTime.Month) + 1;
            for(int i = 1; i < count; i++)
            {
                list.Add(i);
            }
            return list;
        }
    }
}
