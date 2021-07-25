using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIIS.App.GlobalViewModel;
using VIIS.App.Staff.Models;
using VIIS.App.Staff.Views;
using VIIS.Domain.Staff;
using VIMVVM;

namespace VIIS.App.Staff.ViewModels
{
    public class ViewWindowStaffDetail : ViewWindowDetail<ViewEmployees, ViewEmployee, Master>
    {
        private readonly ViewDetail<ViewEmployees, ViewEmployee, Master> other;

        public ViewWindowStaffDetail(ViewDetail<ViewEmployees, ViewEmployee, Master> other) : base(other, new EmployeeDetailView())
        {
            this.other = other;
        }
        public ViewWindowStaffDetail(ViewEmployee viewEmployee, ViewEmployees masters) : this(new ViewDetail<ViewEmployees, ViewEmployee, Master>(masters, viewEmployee, new ViewEmployee(viewEmployee)))
        {
        }
        public ViewWindowStaffDetail(ViewEmployees masters) : this(new ViewNewDetail<ViewEmployees, ViewEmployee, Master>(masters, new ViewEmployee(), new ViewEmployee()))
        {
        }

        public override RelayCommand Save => new RelayCommand((obj) => 
        {
            var masters = new MasterOfView(ViewModel).Safe();
            if (masters.Count() != 0) base.Save.Execute(obj);
            else return;
        });

    }
}
