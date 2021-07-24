using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElegantLib.Authorize;
using ElegantLib.Authorize.Tokenize;
using VIIS.App.Account.DataModels;
using VIIS.App.Account.Models;

namespace VIIS.App.Account.ViewModels
{
    public class ViewChangePassword : ViewRegister
    {
        private readonly RefreshViewModel token;

        public ViewChangePassword(JwtAccount account, string email, string userName, string pass, RefreshViewModel token) : base("Изменить пароль", false, "Изменить", "Новый пароль", account, email, userName, pass)
        {
            this.token = token;
        }

        protected override Task Save()
        {
            new WindowCatcher<Exception>(async () => await account.ChangePassword(new VIISChangePasswordModel(Email, UserName, Password, SecondPassword), token)).Execute();
            return Task.CompletedTask;
        }
    }
}
