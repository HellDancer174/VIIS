using ElegantLib.Authorize.Tokenize;
using ElegantLib.Requests.JsonRequests;
using ElegantLib.Responses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VIIS.App.Account.Models;
using VIIS.App.GlobalViewModel;
using VIIS.Domain.Account;
using VIIS.Domain.Account.Requests;
using VIIS.Domain.Customers;
using VIIS.Domain.Customers.Decorators;
using VIMVVM;

namespace VIIS.App.Customers.ViewModels
{
    public class ViewClients : ViewUpdatableRepository<ViewClient, Client>
    {
        //private int _selectedIndex;
        private readonly Action<RefreshViewModel> saveToken;
        //private readonly ObservableCollection<ViewClient> clientCollection;

        public ViewClients(Clients other, Action<RefreshViewModel> saveToken) : 
            base(other, async(client, url) => await new DeserializableResponseMessage<IEnumerable<Client>>(
                await new MemoryAuthorizedJsonRequest(new JsonRequest(client, url.ClientsUrl), App.Token, new MemoryJwtAccount(client, url, saveToken), saveToken).Response()).DeserializedContent(), 
                (client) => new ViewClient(client))
        {
            this.saveToken = saveToken;
            //clientCollection = new ObservableCollection<ViewClient>(this.Select(client => new ViewClient(client, this)).ToList());
        }

        //public ObservableCollection<ViewClient> ClientCollection => clientCollection;


        public override ICommand AddCommand => new RelayCommand((obj) => new ViewWindowClientDetail(this));
        public override ICommand ChangeCommand => new RelayCommand((obj) => new ViewWindowClientDetail(new ViewClient(Selected), this));
        public override ICommand RemoveCommand => new RelayCommand(async (obj) =>
        {
            await RemoveViewAsync(Selected);
        });

        public override async Task AddViewAsync(ViewClient item)
        {
            await AddAsync(new InsertableClient(item.Model(), saveToken, App.Token));
            await UpdateCollectionAsync();
        }

        public override async Task RemoveViewAsync(ViewClient item)
        {
            await RemoveAsync(new RemovableClient(item.Model(), saveToken, App.Token));
            await UpdateCollectionAsync();
        }

        public override async Task UpdateViewAsync(ViewClient oldItem, ViewClient item)
        {
            await Update(oldItem, new UpdatableClient(item.Model(), saveToken, App.Token));
            await UpdateCollectionAsync();

        }

        //public override async Task UpdateCollectionAsync()
        //{
        //    var url = new VIISJwtURL();
        //    var clients = await new DeserializableResponseMessage<IEnumerable<Client>>(
        //        await new MemoryAuthorizedJsonRequest(new JsonRequest(new HttpClient(), url.ClientsUrl), App.Token, new MemoryJwtAccount(new HttpClient(), url)).Response()).DeserializedContent();
        //    this.Clear();
        //    foreach(var client in clients)
        //    {
        //        this.Add(client);
        //    }
        //    Collection = new ObservableCollection<ViewClient>(this.Select(client => new ViewClient(client)).ToList());
        //    ChangeProperty(nameof(Collection));
        //}

        //public override Task UpdateViewAsync(ViewClient oldItem, ViewClient item)
        //{
        //    return base.UpdateViewAsync(oldItem, new ViewClient(item));
        //}

        //public int SelectedIndex
        //{ get => _selectedIndex;
        //    set => _selectedIndex = value;
        //}


        //public override Task AddAsync(Client item)
        //{
        //    ClientCollection.Add(new ViewClient(item, this));
        //    ChangeProperty(nameof(ClientCollection));
        //    return base.AddAsync(item);
        //}

        //public override Task RemoveAsync(Client item)
        //{
        //    ClientCollection.Remove(new ViewClient(item, this));
        //    ChangeProperty(nameof(Selected));
        //    ChangeProperty(nameof(ClientCollection));
        //    return base.RemoveAsync(item);
        //}

        //public Task UpdateView(ViewClient oldItem, ViewClient item)
        //{
        //    //var newClient = new ViewClient(item, this);
        //    //var index = ClientCollection.IndexOf(new ViewClient(oldItem, this));
        //    //ClientCollection[index] = newClient;
        //    ChangeProperty(nameof(ClientCollection));
        //    ChangeProperty(nameof(Selected));
        //    //ClientCollection[index].ChangeProperties();
        //    return Update(oldItem, item);
        //}

    }
}
