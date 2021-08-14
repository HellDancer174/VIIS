using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ElegantLib.Authorize;
using ElegantLib.Authorize.Tokenize;
using VIIS.App.Account.Models;
using VIIS.App.GlobalViewModel;
using VIIS.Domain.Data;
using VIIS.Domain.Global;

namespace VIIS.App.Account.ViewModels
{
    public class ViewChangePassword : ViewRegister
    {
        private readonly RefreshViewModel token;

        public ViewChangePassword(JwtAccount account, User user, string pass, RefreshViewModel token, ViewUpdatableRepository<ViewUser, User> repository) : base("Изменить пароль", false, "Изменить", "Новый пароль", account, user, pass, repository)
        {
            this.token = token;
        }

        protected override async Task ExecuteSave(string firstPass, string secondPass)
        {
            await account.ChangePassword(new VIISChangePasswordModel(Email, UserName, firstPass, secondPass), token);
        }
    }
}
