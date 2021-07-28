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
            IEnumerable<Client> clients = await TList<Client>(url, url.ClientsUrl);
            IEnumerable<ServiceValue> services = await TList<ServiceValue>(url, url.ServiceValuesUrl);
            IEnumerable<Master> masters = await TList<Master>(url, url.MasterssUrl);
            IEnumerable<Transaction> transactions = await TList<Transaction>(url, url.TransactionsUrl);
            IEnumerable<User> users = await TList<User>(url, url.UsersURL);
            IEnumerable<MasterCash> cashes = await TList<MasterCash>(url, url.MasterCashUrl);
            new ViewMain(new Orders(new Master()), new Employees(masters.ToList()), new Clients(clients.ToList()), new ServiceValueList(services.ToList()), new ViewTransactions(new Repository<Transaction>(transactions), saveToken),
                new Repository<MasterCash>(cashes), new ViewUsers(new Repository<User>(users), account, App.Token), new MainView(), saveToken).ShowView();
        }

        private async Task<IEnumerable<T>> TList<T>(VIISJwtURL url, string apiUrl)
        {
            return await new DeserializableResponseMessage<IEnumerable<T>>(
                await new MemoryAuthorizedJsonRequest(new JsonRequest(new HttpClient(), apiUrl), App.Token, account, (accesstoken) => App.Token = accesstoken).Response()).DeserializedContent();
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
