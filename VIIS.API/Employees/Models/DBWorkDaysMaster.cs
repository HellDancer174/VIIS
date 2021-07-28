using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Data.DBObjects;
using VIIS.Domain.Staff;
using VIIS.Domain.Staff.Decorators;

namespace VIIS.API.Employees.Models
{
    public class DBWorkDaysMaster : DecoratableMaster
    {
        private readonly VIISDBContext context;
        private readonly DateTime month;
        private List<DateTime> failedDatetime;
        private List<DateTime> ordersDates;

        public DBWorkDaysMaster(Master other, VIISDBContext context, DateTime month) : base(other)
        {
            this.context = context;
            this.month = month;
            failedDatetime = new List<DateTime>();
            ordersDates = context.OrdersTt.Where(order => order.MasterId == masterID && order.Start.Month == month.Month && order.Start.Year == month.Year)
                .Select(order => order.Start).ToList();
        }

        public override void Transfer()
        {
            var removableList = context.WorkDaysTt
                .Where(masterWorkDay =>
                masterWorkDay.MasterId == masterID && masterWorkDay.WorkDate.Month == month.Month && masterWorkDay.WorkDate.Year == month.Year && !ordersDates.Contains(masterWorkDay.WorkDate))
                .ToArray();
            context.WorkDaysTt.RemoveRange(removableList.Where(day => IsNotFail(day.WorkDate)).ToArray());
            context.SaveChanges();
            var monthDates = workDaysList.Where(day => IsNotFail(day)).ToList();

            context.WorkDaysTt.AddRange(monthDates.Select(day => new WorkDaysTt(masterID, day)).ToArray());
            context.SaveChanges();
        }

        public bool IsSuccess => failedDatetime.Count == 0;

        public string FailedMessage()
        {
            if (failedDatetime.Count == 0) return "";
            return string.Format("{0}: {1}", FullName, String.Join(", ", failedDatetime.Select(date => date.ToShortDateString()).ToArray()));
        }

        private bool IsNotFail(DateTime date)
        {
            if (ordersDates.Contains(date))
            {
                failedDatetime.Add(date);
                return false;
            }
            else return date.Month == month.Month && date.Year == month.Year;
        }
    }
}
