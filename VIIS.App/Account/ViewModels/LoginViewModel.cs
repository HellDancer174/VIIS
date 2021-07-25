using ElegantLib.Authorize.Tokenize;
using ElegantLib.Validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIIS.Domain.Global;
using VIMVVM;

namespace VIIS.App.Account.ViewModels
{
    public class LoginViewModel : IViewLogin
    {
        private readonly JwtAccount account;
        private readonly Action<RefreshViewModel> saveToken;

        public LoginViewModel(JwtAccount account, Action<RefreshViewModel> saveToken)
        {
            this.account = account;
            this.saveToken = saveToken;

            Login = "";
            Password = "";
        }
        public LoginViewModel(JwtAccount account):this(account, (token) => App.Token = token)
        {
        }

        public string Login { get; set; }
        public string Password { get; set; }


        public Task LogIn(string pass)
        {
            new Catcher<Exception>(async () => saveToken.Invoke(await account.Login(Login, pass)), (ex) => MessageBox.Show(ex.Message)).Execute();
            return Task.CompletedTask;
        }

        public RelayCommand LoginCommand
        {
            get
            {
                return new RelayCommand((obj) => LogIn(Password), (obj) => !(String.IsNullOrEmpty(Login) && String.IsNullOrEmpty(Password)));
            }
        }
    }
}
