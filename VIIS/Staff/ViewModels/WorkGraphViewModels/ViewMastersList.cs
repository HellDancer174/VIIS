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
        private List<string> months;
        private DateTime month;

        public ViewMastersList(Employees other, DateTime month) : base(other)
        {
            this.months = new List<string>() { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            ChangeMonth(month);
        }

        public void ChangeMonth(DateTime date)
        {
            month = date;
            mastersWorkDays = this.Select(master => new ViewMasterOfWorkDays(master, date)).ToList();
            columnNames = new Month(date).Days();
            CurrentMonth = months[date.Month - 1] + " " + date.Year;
            ChangeProperty(nameof(MastersWorkDays));
            ChangeProperty(nameof(ColumnNames));
            ChangeProperty(nameof(CurrentMonth));
        }

        public List<ViewMasterOfWorkDays> MastersWorkDays => mastersWorkDays;

        public string CurrentMonth { get; private set; }
        public List<int> ColumnNames => columnNames;


        public async Task SaveMonth()
        {
            //Отправить на сервер список мастеров (masterWorkDays) и месяц (month)
            await Task.CompletedTask;
        }
    }
}
