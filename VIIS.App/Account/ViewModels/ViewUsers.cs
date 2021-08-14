using ElegantLib.Authorize.Tokenize;
using ElegantLib.Requests.JsonRequests;
using ElegantLib.Responses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VIIS.App.Account.Models;
using VIIS.App.Account.Views;
using VIIS.App.GlobalViewModel;
using VIIS.Domain.Account;
using VIIS.Domain.Account.Requests;
using VIIS.Domain.Global;
using VIMVVM;

namespace VIIS.App.Account.ViewModels
{
    public class ViewUsers : ViewUpdatableRepository<ViewUser, User>
    {
        private readonly JwtAccount account;
        private readonly RefreshViewModel token;

        public ViewUsers(Repository<User> other, JwtAccount account, RefreshViewModel token, VIISJwtURL jwtURL) : 
            base(other, (accesstoken) => App.Token = accesstoken, (user) => new ViewUser(user), jwtURL.UsersURL, jwtURL.LoginURL, jwtURL.ChangePasswordURL, jwtURL.RemoveUserURL)
        {
            this.account = account;
            this.token = token;
        }
        public ViewUsers():this(new Repository<User>(new List<User>()), new JwtAccount(new System.Net.Http.HttpClient(), new VIISJwtURL()), App.Token, new VIISJwtURL())
        {

        }

        public override ICommand AddCommand => new RelayCommand((obj)=> new AddOrUpdateUserWindow(new ViewRegister(account, this)).Show());

        public override ICommand ChangeCommand => base.Command((obj) => new AddOrUpdateUserWindow(new ViewChangePassword(account, Selected, "", token, this)).Show());

        public override ICommand RemoveCommand => Command(async(obj) => 
        {
            try
            {
                await RemoveViewAsync(Selected);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        });

        protected override RelayCommand Command(Action<object> execute)
        {
            return new RelayCommand(execute, (obj) => Selected is ViewUser && !Selected.Equals(App.CurrentUser));
        }

        //public override async Task UpdateCollectionAsync()
        //{
        //    await Task.CompletedTask;
        //    Collection = new ObservableCollection<ViewUser>(this.Select(user => new ViewUser(user)).ToList());
        //}
    }
}
