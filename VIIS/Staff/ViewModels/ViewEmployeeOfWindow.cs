using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIIS.App.Staff.Views;
using VIIS.Domain.Staff;
using VIMVVM;

namespace VIIS.App.Staff.ViewModels
{
    public class ViewEmployeeOfWindow : ViewEmployee
    {
        private readonly Window view;

        public ViewEmployeeOfWindow(ViewEmployee viewEmployee) : base(viewEmployee)
        {
            view = new EmployeeDetailView(this);
            view.Show();
        }

        //public override RelayCommand Save => new RelayCommand((obj) => { base.Save.Execute(obj); view.Close(); });


        public override RelayCommand End => new RelayCommand((obj) => { base.End.Execute(obj); view.Close(); });

        protected override async Task<bool> SaveMethod()
        {
            if (await base.SaveMethod())
            {
                view.Close();
                return true;
            }
            else return false;
        }
    }
}
