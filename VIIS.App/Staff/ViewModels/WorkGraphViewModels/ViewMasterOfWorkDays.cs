using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Staff;
using VIIS.Domain.Staff.Decorators;
using VIMVVM;

namespace VIIS.App.Staff.ViewModels.WorkGraphViewModels
{
    public class ViewMasterOfWorkDays: DecoratableMaster, IViewModel<Master>
    {
        private readonly List<ViewBooleanWorkDay> workDays;
        private readonly DateTime month;

        public ViewMasterOfWorkDays(List<ViewBooleanWorkDay> workDays, Master master, DateTime month):base(master)
        {
            this.workDays = workDays;
            this.month = month;
        }
        public ViewMasterOfWorkDays(): this(new Master(), DateTime.Now)
        {
        }

        public ViewMasterOfWorkDays(Master other, DateTime month) : this(new List<ViewBooleanWorkDay>(), other, month)
        {
            this.month = month;
            var days = DateTime.DaysInMonth(month.Year, month.Month);
            for (int i = 1; i < days + 1; i++)
            {
                DateTime workDate = new DateTime(month.Year, month.Month, i);
                workDays.Add(new ViewBooleanWorkDay(IsWork(workDate), workDate, workDaysList));
            }
        }

        public List<ViewBooleanWorkDay> WorkDays => workDays;

        public Master Model()
        {
            return this;
        }
    }
}
