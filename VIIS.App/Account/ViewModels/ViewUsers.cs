using ElegantLib.Authorize.Tokenize;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VIIS.App.Account.Views;
using VIIS.App.GlobalViewModel;
using VIIS.Domain.Global;
using VIMVVM;

namespace VIIS.App.Account.ViewModels
{
    public class ViewUsers : ViewUpdatableRepository<ViewUser, User>
    {
        private readonly JwtAccount account;
        private readonly RefreshViewModel token;

        public ViewUsers(Repository<User> other, JwtAccount account, RefreshViewModel token) : base(other, new ObservableCollection<ViewUser>(other.Select(user => new ViewUser(user)).ToList()))
        {
            this.account = account;
            this.token = token;
        }

        public override ICommand AddCommand => new RelayCommand((obj)=> new AddOrUpdateUserWindow(new ViewRegister(account)));

        public override ICommand ChangeCommand => new RelayCommand((obj) => new AddOrUpdateUserWindow(new ViewChangePassword(account, Selected, "", token)));

        public override ICommand RemoveCommand => new RelayCommand(async(obj) => await RemoveViewAsync(Selected));

        public override async Task UpdateCollectionAsync()
        {
            await Task.CompletedTask;
            Collection = new ObservableCollection<ViewUser>(this.Select(user => new ViewUser(user)).ToList());
        }
    }
}
