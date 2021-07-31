using ElegantLib.Authorize;
using ElegantLib.Authorize.Tokenize;
using ElegantLib.Validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.Account.Models;
using VIIS.Domain.Global;
using VIIS.Domain.Data;
using VIMVVM;
using System.Windows;

namespace VIIS.App.Account.ViewModels
{
    public class ViewRegister : User, IViewUserDetail
    {
        protected readonly JwtAccount account;

        public ViewRegister(string title, bool canChangeLogin, string saveButtonName, string secondPassName, JwtAccount account, User user, string pass): base(user)
        {
            Title = title;
            CanChangeLogin = canChangeLogin;
            SaveButtonName = saveButtonName;
            SecondPasswordName = secondPassName;
            this.account = account;
            Password = pass;
            SecondPassword = "";
            SaveCommand = new RelayCommand(async(obj) => await Save(Password, SecondPassword), (obj) => !(String.IsNullOrEmpty(Email) && String.IsNullOrEmpty(Password) && String.IsNullOrEmpty(UserName) && String.IsNullOrEmpty(SecondPassword)));
        }
        public ViewRegister(JwtAccount account): this("Новый пользователь", true, "Добавить", "Подтвердить пароль", account, new User("", ""), "")
        {
        }

        public string Title { get; }
        public bool CanChangeLogin { get; }
        public string SecondPasswordName { get; }
        public string SaveButtonName { get; }

        public string Email { get => email; set => email = value; }
        public string UserName { get => name; set => name = value; }
        public string Password { get; set; }
        public string SecondPassword { get; set; }


        public virtual async Task Save(string firstPass, string secondPass)
        {
            try
            {
                await account.Register(new VIISRegisterModel(Email, UserName, firstPass, secondPass));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public RelayCommand SaveCommand { get; }



    }
}
