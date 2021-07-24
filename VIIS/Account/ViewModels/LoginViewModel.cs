using ElegantLib.Authorize.Tokenize;
using ElegantLib.Validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIMVVM;

namespace VIIS.App.Account.ViewModels
{
    public class LoginViewModel
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


        private Task LogIn()
        {
            new Catcher<Exception>(async () => saveToken.Invoke(await account.Login(Login, Password)), (ex) => MessageBox.Show(ex.Message)).Execute();
            return Task.CompletedTask;
        }

        public RelayCommand LoginCommand
        {
            get
            {
                return new RelayCommand((obj) => LogIn(), (obj) => !(String.IsNullOrEmpty(Login) && String.IsNullOrEmpty(Password)));
            }
        }
    }
}
