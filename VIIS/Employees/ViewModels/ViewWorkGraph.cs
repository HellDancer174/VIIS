using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.Employees.ViewModels.WorkGraphViewModels;
using VIIS.App.Employees.Views;
using VIMVVM;

namespace VIIS.App.Employees.ViewModels
{
    public class ViewWorkGraph: ViewModel<string>
    {
        private readonly List<string> months;
        private readonly ViewMastersList mastersList;
        private readonly WorkGraph page;

        public ViewWorkGraph(ViewMastersList mastersList, WorkGraph page)
        {
            this.months = new List<string>() { "январь", "февраль", "март", "апрель", "май", "июнь", "июль", "август", "сентябрь", "октябрь", "ноябрь", "декабрь" };
            this.mastersList = mastersList;
            this.page = page;
            Month = months.First();
        }
        public ViewWorkGraph(WorkGraph page):this(new ViewMastersList(page), page)
        {
        }

        public string Month { get; set; }

        public List<string> Months => months;

        public ViewMastersList MastersList => mastersList;
    }
}
