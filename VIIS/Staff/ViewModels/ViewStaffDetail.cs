using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIIS.App.GlobalViewModel;
using VIIS.App.Staff.Views;
using VIIS.Domain.Staff;
using VIMVVM;

namespace VIIS.App.Staff.ViewModels
{
    public class ViewStaffDetail : ViewDetail<ViewEmployees, ViewEmployee, Master>
    {

        public ViewStaffDetail(ViewEmployee viewEmployee, ViewEmployees masters) : base(masters, viewEmployee, new ViewEmployee(viewEmployee))
        {
        }
        public ViewStaffDetail(ViewEmployees masters) : base(new ViewNewDetail<ViewEmployees, ViewEmployee, Master>(masters, new ViewEmployee(), new ViewEmployee()))
        {
        }

        //public override RelayCommand Save => new RelayCommand((obj) => { base.Save.Execute(obj); view.Close(); });


        //public override RelayCommand End => new RelayCommand((obj) => { base.End.Execute(obj); view.Close(); });

        //protected override async Task<bool> SaveMethod()
        //{
        //    if (await base.SaveMethod())
        //    {
        //        view.Close();
        //        return true;
        //    }
        //    else return false;
        //}
    }
}
