using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VIIS.App.Staff.Views;
using VIMVVM;

namespace VIIS.App.Staff.ViewModels
{
    public class ViewEmployeesTabs: Notifier
    {
        private readonly EmployeesList employees;
        private readonly WorkGraph graph;

        public ViewEmployeesTabs(EmployeesList employees, WorkGraph graph)
        {
            this.employees = employees;
            this.graph = graph;
        }
        public ViewEmployeesTabs(): this(new EmployeesList(), new WorkGraph())
        {
        }

        public Page Employees => employees;

        public Page Graph => graph;
    }
}
