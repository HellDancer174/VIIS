using ElegantLib.Authorize.Tokenize;
using ElegantLib.Requests.JsonRequests;
using ElegantLib.Responses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ViewUsers(Repository<User> other, JwtAccount account, RefreshViewModel token) : 
            base(other,
                async(client, url) => await new DeserializableResponseMessage<IEnumerable<User>>(
                await new MemoryAuthorizedJsonRequest(new JsonRequest(client, url.UsersURL), App.Token, new MemoryJwtAccount(client, url, (accesstoken) => App.Token = accesstoken), (accesstoken) => App.Token = accesstoken).Response()).DeserializedContent(), 
                (user) => new ViewUser(user))
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
