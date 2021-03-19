using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.App.Employees.ViewModels.WorkGraphViewModels
{
    public class ViewBooleanWorkDay
    {
        private bool isWork;

        public ViewBooleanWorkDay(bool isWork)
        {
            this.isWork = isWork;
        }
        public ViewBooleanWorkDay():this(false)
        {
        }

        public bool IsWork
        {
            get => isWork;
            set
            {
                isWork = value;
            }
        }
    }
}
