using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VIIS.App.Employees.Views;
using VIMVVM;

namespace VIIS.App.Employees.ViewModels
{
    public class ViewEmployeesTabs: ViewModel<string>
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
