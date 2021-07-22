using ElegantLib.Authorize;
using ElegantLib.Authorize.Tokenize;
using ElegantLib.Validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.Account.DataModels;
using VIIS.App.Account.Models;
using VIMVVM;

namespace VIIS.App.Account.ViewModels
{
    public class ViewRegister
    {
        protected readonly JwtAccount account;

        public ViewRegister(string title, bool canChangeLogin, string saveButtonName, string secondPassName, JwtAccount account, string email, string username, string pass)
        {
            Title = title;
            CanChangeLogin = canChangeLogin;
            SaveButtonName = saveButtonName;
            SecondPasswordName = secondPassName;
            this.account = account;
            Email = email;
            UserName = username;
            Password = pass;
            SecondPassword = "";
            SaveCommand = new RelayCommand((obj) => Save(), (obj) => !(String.IsNullOrEmpty(Email) && String.IsNullOrEmpty(Password) && String.IsNullOrEmpty(UserName) && String.IsNullOrEmpty(SecondPassword)));
        }
        public ViewRegister(JwtAccount account): this("Новый пользователь", true, "Добавить", "Подтвердить пароль", account, "", "", "")
        {
        }

        public string Title { get; }
        public bool CanChangeLogin { get; }
        public string SecondPasswordName { get; }
        public string SaveButtonName { get; }

        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SecondPassword { get; set; }


        protected virtual Task Save()
        {
            new WindowCatcher<Exception>(async () => await account.Register(new VIISRegisterModel(Email, UserName, Password, SecondPassword))).Execute();
            return Task.CompletedTask;
        }

        public RelayCommand SaveCommand { get; }



    }
}
