using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.App.Employees.ViewModels.WorkGraphViewModels
{
    public class ViewWorkDaysList
    {
        private readonly string master;
        private readonly List<ViewBooleanWorkDay> workDays;

        public ViewWorkDaysList(List<ViewBooleanWorkDay> workDays, string master)
        {
            this.workDays = workDays;
            this.master = master;
        }
        public ViewWorkDaysList()
        {
            master = "FullNameNameNameName";
            workDays = new List<ViewBooleanWorkDay>();
            for (int i = 1; i < 32; i++)
                workDays.Add(new ViewBooleanWorkDay());
        }
        public ViewWorkDaysList(string master): this()
        {
            this.master = master;

        }


        public List<ViewBooleanWorkDay> WorkDays => workDays;

        public string Master => master;
    }
}
