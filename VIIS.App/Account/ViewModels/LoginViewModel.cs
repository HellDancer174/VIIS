using ElegantLib.Authorize.Tokenize;
using ElegantLib.Requests.JsonRequests;
using ElegantLib.Responses;
using ElegantLib.Validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIIS.App.Account.Models;
using VIIS.App.Finance.ViewModels;
using VIIS.App.Main.ViewModels;
using VIIS.App.Main.Views;
using VIIS.Domain.Account;
using VIIS.Domain.Account.Requests;
using VIIS.Domain.Customers;
using VIIS.Domain.Finance;
using VIIS.Domain.Global;
using VIIS.Domain.Orders;
using VIIS.Domain.Services;
using VIIS.Domain.Staff;
using VIMVVM;

namespace VIIS.App.Account.ViewModels
{
    public class LoginViewModel : IViewLogin
    {
        private readonly JwtAccount account;
        private readonly Action<RefreshViewModel> saveToken;
        private readonly Window view;

        public LoginViewModel(JwtAccount account, Action<RefreshViewModel> saveToken, Window view)
        {
            this.account = account;
            this.saveToken = saveToken;
            this.view = view;
            Login = "";
            Password = "";
        }
        public LoginViewModel(JwtAccount account, Window view):this(account, (token) => App.Token = token, view)
        {
        }

        public string Login { get; set; }
        public string Password { get; set; }


        public async Task LogIn(string pass)
        {
            try
            {
                saveToken.Invoke(await account.Login(Login, pass));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            await ShowViewMain();
            view.Close();

        }

        private async Task ShowViewMain()
        {
            var url = new VIISJwtURL();
            var clients = await new DeserializableResponseMessage<IEnumerable<Client>>(
                await new MemoryAuthorizedJsonRequest(new JsonRequest(new HttpClient(), url.ClientsUrl), App.Token, account, (accesstoken) => App.Token = accesstoken).Response()).DeserializedContent();
            new ViewMain(new Orders(), new Employees(), new Clients(clients.ToList()), new ServiceValueList(), new ViewTransactions(), new Repository<MasterCash>(new List<MasterCash>()), new MainView()).ShowView();
        }

        public RelayCommand LoginCommand
        {
            get
            {
                return new RelayCommand(async(obj) => await LogIn(Password), (obj) => !(String.IsNullOrEmpty(Login) || String.IsNullOrEmpty(Password)));
            }
        }
    }
}
