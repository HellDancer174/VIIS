using ElegantLib.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.Employees.Views;

namespace VIIS.App.Employees.ViewModels.WorkGraphViewModels
{
    public class ViewMastersList
    {
        private readonly List<int> columnNames;
        private readonly List<ViewWorkDaysList> mastersWorkDays;
        private readonly WorkGraph page;

        public ViewMastersList(List<int> columnNames, List<ViewWorkDaysList> mastersWorkDays, WorkGraph page)
        {
            this.columnNames = columnNames;
            this.mastersWorkDays = mastersWorkDays;
            this.page = page;
        }
        public ViewMastersList(WorkGraph page) : this(new Month(3, 2021).Days(), new List<ViewWorkDaysList>() { new ViewWorkDaysList("Full"), new ViewWorkDaysList(), new ViewWorkDaysList() }, page)
        {
        }
        public ViewMastersList(string month, int year, List<ViewWorkDaysList> mastersWorkDays, WorkGraph page)
        {
            var mymonth = new Month(month, year);
            columnNames = mymonth.Days();
            this.mastersWorkDays = mastersWorkDays;
            this.page = page;
        }
        public ViewMastersList(string month, List<ViewWorkDaysList> mastersWorkDays, WorkGraph page) : this(month, DateTime.Now.Year, mastersWorkDays, page)
        {
        }
        public List<ViewWorkDaysList> MastersWorkDays => mastersWorkDays;

        public List<int> ColumnNames => columnNames;
    }
}
