using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.Staff.ViewModels.WorkGraphViewModels;
using VIIS.App.Staff.Views;
using VIIS.Domain.Staff;
using VIMVVM;

namespace VIIS.App.Staff.ViewModels
{
    public class ViewWorkGraph: Notifier
    {
        private DateTime current;

        public ViewWorkGraph(ViewMastersList mastersList, DateTime current)
        {
            //this.months = new List<string>() { "январь", "февраль", "март", "апрель", "май", "июнь", "июль", "август", "сентябрь", "октябрь", "ноябрь", "декабрь" };
            this.MastersList = mastersList;
            this.current = current;
        }
        public ViewWorkGraph(Employees masters, DateTime current): this(new ViewMastersList(masters, current), current)
        {
        }

        public ViewMastersList MastersList { get; private set; }

        public DateTime Current
        {
            get => current;
            set
            {
                current = value;
                MastersList.ChangeMonth(current);
            }
        }
    }
}
