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
        private readonly PayView pay;

        public ViewEmployeesTabs(EmployeesList employees, WorkGraph graph, PayView pay)
        {
            this.employees = employees;
            this.graph = graph;
            this.pay = pay;
        }
        public ViewEmployeesTabs(): this(new EmployeesList(), new WorkGraph(), new PayView())
        {
        }

        public Page Employees => employees;

        public Page Graph => graph;
        public Page Pay => pay;
    }
}
