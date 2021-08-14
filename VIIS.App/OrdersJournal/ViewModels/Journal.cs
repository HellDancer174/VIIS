using ElegantLib.Authorize.Tokenize;
using ElegantLib.Requests.JsonRequests;
using ElegantLib.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VIIS.App.Finance.ViewModels;
using VIIS.App.GlobalViewModel;
using VIIS.App.OrdersJournal.Models.OrdersDecorators;
using VIIS.Domain.Account;
using VIIS.Domain.Account.Requests;
using VIIS.Domain.Customers;
using VIIS.Domain.Finance;
using VIIS.Domain.Global.Documents;
using VIIS.Domain.Orders;
using VIIS.Domain.Orders.Decorators;
using VIIS.Domain.Services;
using VIIS.Domain.Staff;
using VIMVVM;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class Journal : UpdatableOrders, INotifyPropertyChanged, IJournal
    {
        private ViewJournalEmployees staff;
        private DateTime currentDate;
        private readonly Employees employees;
        private readonly ServiceValueList serviceValueList;
        private readonly Clients clients;
        private readonly HttpClient httpClient = new HttpClient();
        private readonly VIISJwtURL jwtURL = new VIISJwtURL();
        private readonly ViewRepository<ViewTransaction, Transaction> transactions;
        private readonly Action<RefreshViewModel> saveToken;

        public Journal(Orders orders, Employees employees, ServiceValueList serviceValueList, Clients clients, ViewRepository<ViewTransaction, Transaction> transactions, Action<RefreshViewModel> saveToken) 
            : base(orders)
        {
            this.employees = employees;
            this.serviceValueList = serviceValueList;
            this.clients = clients;
            this.transactions = transactions;
            this.saveToken = saveToken;
            currentDate = DateTime.Now.Date;
            ChangeStaff(employees);
        }
        public Journal():this(new Orders(new Master()), new Employees(), new ServiceValueList(), new Clients(), new ViewTransactions(), (token) => App.Token = token)
        {
        }

        public ViewJournalEmployees Staff => staff;

        public DateTime CurrentDate
        {
            get => currentDate;
            set
            {
                if (value == currentDate) return;
                currentDate = value;
                //var staff = new ViewJournalEmployees(employees, currentDate, serviceValueList, clients, this, this.Where(order => order.CheckDate(currentDate)).ToList());
                //ChangeStaff(staff);
                ChangeStaff();
            }
        }

        public void ChangeStaff(ViewJournalEmployees staff)
        {
            this.staff = staff;
            ChangeProperty(nameof(Staff));
        }
        public void ChangeStaff(Employees masters) => ChangeStaff(masters, serviceValueList, clients);

        public void ChangeStaff(Employees masters, ServiceValueList serviceValues, Clients clients)
        {
            ChangeStaff(new ViewJournalEmployees(masters, currentDate, serviceValues, clients, this, this.Where(order => order.CheckDate(currentDate)).ToList(), transactions));
        }
        public void ChangeStaff()
        {
            var masters = new ApiList<Master>(jwtURL, jwtURL.MasterssUrl);
            var services = new ApiList<ServiceValue>(jwtURL, jwtURL.ServiceValuesUrl);
            var clients = new ApiList<Client>(jwtURL, jwtURL.ClientsUrl);
            ChangeStaff(new Employees(masters), new ServiceValueList(services), new Clients(clients));
        }

        public override async Task AddAsync(Order order)
        {
            //try
            //{
                staff.DaysPage.AddOrder(order, serviceValueList, clients);
                await new InsertableDocument(order, saveToken, App.Token, jwtURL.OrdersUrl).TransferAsync();
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
                await UpdateAsync();
            //}
        }

        public override async Task Update(Order oldOrder, Order newOrder)
        {
            try
            {
                staff.DaysPage.RemoveOrder(oldOrder);
                staff.DaysPage.AddOrder(newOrder, serviceValueList, clients);
                await new UpdatableDocument(newOrder, saveToken, App.Token, jwtURL.OrdersUrl).TransferAsync();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await UpdateAsync();
            }
        }

        public override async Task RemoveAsync(Order order)
        {
            //try
            //{
                staff.DaysPage.RemoveOrder(order);
                await new RemovableDocument(order, saveToken, App.Token, jwtURL.OrdersUrl).TransferAsync();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
                await UpdateAsync();
            //}
        }

        public override async Task UpdateAsync()
        {
            this.Clear();
            //var elements = await requestsFunc.Invoke(new HttpClient(), url);
            var elements = await new DeserializableResponseMessage<IEnumerable<Order>>(
                await new MemoryAuthorizedJsonRequest(new JsonRequest(httpClient, new VIISJwtURL().OrdersUrl), App.Token, new MemoryJwtAccount(httpClient, new VIISJwtURL(), saveToken), saveToken).Response()).DeserializedContent();
            foreach (var element in elements)
            {
                this.Add(element);
            }

            ChangeStaff();
        }

        //private void ValidOrder(Order newOrder)
        //{
        //    foreach(var order in this)
        //}
    }
}
