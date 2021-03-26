using ElegantLib.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.Staff.Views;
using VIIS.Domain.Staff;
using VIIS.Domain.Staff.Decorators;

namespace VIIS.App.Staff.ViewModels.WorkGraphViewModels
{
    public class ViewMastersList: EmployeesDecorator
    {
        private List<int> columnNames;
        private List<ViewMasterOfWorkDays> mastersWorkDays;


        public ViewMastersList(Employees other, DateTime month) : base(other)
        {
            ChangeMonth(month);
        }

        public void ChangeMonth(DateTime date)
        {
            mastersWorkDays = this.Select(master => new ViewMasterOfWorkDays(master, date)).ToList();
            columnNames = new Month(date).Days();
            ChangeProperty(nameof(MastersWorkDays));
            ChangeProperty(nameof(ColumnNames));
        }

        public List<ViewMasterOfWorkDays> MastersWorkDays => mastersWorkDays;

        public List<int> ColumnNames => columnNames;
    }
}
