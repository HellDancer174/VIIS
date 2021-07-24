using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElegantLib.Authorize;
using ElegantLib.Authorize.Tokenize;
using VIIS.App.Account.DataModels;
using VIIS.App.Account.Models;
using VIIS.Domain.Global;

namespace VIIS.App.Account.ViewModels
{
    public class ViewChangePassword : ViewRegister
    {
        private readonly RefreshViewModel token;

        public ViewChangePassword(JwtAccount account, User user, string pass, RefreshViewModel token) : base("Изменить пароль", false, "Изменить", "Новый пароль", account, user, pass)
        {
            this.token = token;
        }

        public override Task Save(string firstPass, string secondPass)
        {
            new WindowCatcher<Exception>(async () => await account.ChangePassword(new VIISChangePasswordModel(Email, UserName, firstPass, secondPass), token)).Execute();
            return Task.CompletedTask;
        }
    }
}
