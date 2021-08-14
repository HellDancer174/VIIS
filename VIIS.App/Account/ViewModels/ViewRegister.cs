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
using VIIS.App.GlobalViewModel;

namespace VIIS.App.Account.ViewModels
{
    public class ViewRegister : User, IViewUserDetail
    {
        protected readonly JwtAccount account;
        private readonly ViewUpdatableRepository<ViewUser, User> repository;

        public ViewRegister(string title, bool canChangeLogin, string saveButtonName, string secondPassName, JwtAccount account, User user, string pass, ViewUpdatableRepository<ViewUser, User> repository) : base(user)
        {
            Title = title;
            CanChangeLogin = canChangeLogin;
            SaveButtonName = saveButtonName;
            SecondPasswordName = secondPassName;
            this.account = account;
            Password = pass;
            this.repository = repository;
            SecondPassword = "";
            SaveCommand = new RelayCommand(async(obj) =>
            {
                try
                {
                    await Save(Password, SecondPassword);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }, (obj) => !(String.IsNullOrEmpty(Email) && String.IsNullOrEmpty(Password) && String.IsNullOrEmpty(UserName) && String.IsNullOrEmpty(SecondPassword)));
        }
        public ViewRegister(JwtAccount account, ViewUpdatableRepository<ViewUser, User> repository) : this("Новый пользователь", true, "Добавить", "Подтвердить пароль", account, new User("", ""), "", repository)
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
            await ExecuteSave(firstPass, secondPass);
            await repository.UpdateCollectionAsync();
        }

        protected virtual async Task ExecuteSave(string firstPass, string secondPass)
        {
            await account.Register(new VIISRegisterModel(Email, UserName, firstPass, secondPass));
        }

        public RelayCommand SaveCommand { get; }



    }
}
