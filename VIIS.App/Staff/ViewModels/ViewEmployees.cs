using ElegantLib.Authorize.Tokenize;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VIIS.App.GlobalViewModel;
using VIIS.App.Staff.Views;
using VIIS.Domain.Account;
using VIIS.Domain.Global;
using VIIS.Domain.Staff;
using VIIS.Domain.Staff.Decorators;
using VIMVVM;

namespace VIIS.App.Staff.ViewModels
{
    public class ViewEmployees : ViewUpdatableRepository<ViewEmployee, Master>
    {
        public ViewEmployees(Employees masters, Action<RefreshViewModel> saveToken) : base(masters, saveToken, (master) => new ViewEmployee(master), new VIISJwtURL().MasterssUrl)
        {
            if (Collection.Count != 0) Selected = Collection.First();
        }

        public override ICommand AddCommand => new RelayCommand((obj) => new ViewWindowStaffDetail(this));
        public override ICommand ChangeCommand => new RelayCommand((obj) => new ViewWindowStaffDetail(new ViewEmployee(Selected), this));
        public override ICommand RemoveCommand => new RelayCommand(async(obj) => 
        {
            await RemoveViewAsync(Selected);
        });

        //private ViewEmployee selected;

        //public new ViewEmployee Selected
        //{
        //    get { return selected; }
        //    set { selected = value; ChangeProperty(); }
        //}

    }
}
