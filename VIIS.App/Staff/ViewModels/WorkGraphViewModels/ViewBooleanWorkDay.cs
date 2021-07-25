using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.App.Staff.ViewModels.WorkGraphViewModels
{
    public class ViewBooleanWorkDay
    {
        private bool isWork;
        private readonly DateTime date;
        private readonly List<DateTime> workDaysList;

        public ViewBooleanWorkDay(bool isWork, DateTime date, List<DateTime> workDaysList)
        {
            this.isWork = isWork;
            this.date = date;
            this.workDaysList = workDaysList;
        }
        public ViewBooleanWorkDay(DateTime workDate, List<DateTime> workDaysList):this(false, workDate, workDaysList)
        {
        }

        public bool IsWork
        {
            get => isWork;
            set
            {
                if (isWork == value) return;
                isWork = value;
                if (isWork) workDaysList.Add(date);
                else workDaysList.Remove(date);
            }
        }
    }
}
