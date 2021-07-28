using ElegantLib.Authorize.Tokenize;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VIIS.App.GlobalViewModel;
using VIIS.App.OrdersJournal.ViewModels;
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
        private readonly IJournal journal;

        public ViewEmployees(Employees masters, Action<RefreshViewModel> saveToken, IJournal journal) : base(masters, saveToken, (master) => new ViewEmployee(master), new VIISJwtURL().MasterssUrl)
        {
            if (Collection.Count != 0) Selected = Collection.First();
            this.journal = journal;
        }

        public override ICommand AddCommand => new RelayCommand((obj) => new ViewWindowStaffDetail(this));
        public override ICommand ChangeCommand => Command((obj) => new ViewWindowStaffDetail(new ViewEmployee(Selected), this));
        public override ICommand RemoveCommand => Command(async(obj) => 
        {
            await RemoveViewAsync(Selected);
        });

        public override async Task UpdateCollectionAsync()
        {
            await base.UpdateCollectionAsync();
            journal.ChangeStaff(new Employees(this.ToList()));
        }

        //private ViewEmployee selected;

        //public new ViewEmployee Selected
        //{
        //    get { return selected; }
        //    set { selected = value; ChangeProperty(); }
        //}

    }
}
