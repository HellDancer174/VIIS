using ElegantLib;
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
using VIIS.Domain.Account;
using VIIS.Domain.Account.Requests;
using VIIS.Domain.Global;
using VIIS.Domain.Global.Documents;
using VIMVVM.Detail;

namespace VIIS.App.GlobalViewModel
{
    public abstract class ViewUpdatableRepository<V, T>: ViewRepository<V, T>
     where V : T, IDetailedViewModel<T> where T : IDocumentAsync
    {
        private readonly Action<RefreshViewModel> saveToken;
        private readonly Func<T, V> viewSelector;
        private readonly HttpClient client = new HttpClient();
        private readonly string url;
        private readonly string postUrl;
        private readonly string putUrl;
        private readonly string deleteUrl;

        //public ViewUpdatableRepository(Repository<T> other, ObservableCollection<V> collection) : base(other, collection)
        //{
        //}
        public ViewUpdatableRepository(Repository<T> other, Action<RefreshViewModel> saveToken, Func<T, V> viewSelector, string url):
            this(other, saveToken, viewSelector, url, url, url, url)
        {
            //this.saveToken = saveToken;
            //this.viewSelector = viewSelector;
            //this.url = url;
        }
        public ViewUpdatableRepository(Repository<T> other, Action<RefreshViewModel> saveToken, Func<T, V> viewSelector, string url, string postUrl, string putUrl, string deleteUrl):
            base(other, new ObservableCollection<V>(other.Select(element => viewSelector.Invoke(element)).ToArray()))
        {
            this.saveToken = saveToken;
            this.viewSelector = viewSelector;
            this.url = url;
            this.postUrl = postUrl;
            this.putUrl = putUrl;
            this.deleteUrl = deleteUrl;
        }

        public override async Task AddAsync(T item)
        {
            Add(item);
            await new InsertableDocument(item, (token) => App.Token = token, App.Token, postUrl).TransferAsync();
        }

        public override async Task AddViewAsync(V item)
        {
            await AddAsync(item.Model());
            await UpdateCollectionAsync();
        }

        public override async Task RemoveAsync(T item)
        {
            Remove(item);
            await new RemovableDocument(item, (token) => App.Token = token, App.Token, deleteUrl).TransferAsync();
        }

        public override async Task RemoveViewAsync(V item)
        {
            await RemoveAsync(item.Model());
            await UpdateCollectionAsync();
        }

        public override async Task Update(T oldItem, T item)
        {
            var index = IndexOf(oldItem);
            if (index == -1) index = IndexOf(item);
            this[index] = item;
            await new UpdatableDocument(item, (token) => App.Token = token, App.Token, putUrl).TransferAsync();
        }

        public virtual async Task UpdateCollectionAsync()
        {
            this.Clear();
            //var elements = await requestsFunc.Invoke(new HttpClient(), url);
            var elements = await new DeserializableResponseMessage<IEnumerable<T>>(
                await new MemoryAuthorizedJsonRequest(new JsonRequest(client, url), App.Token, new MemoryJwtAccount(client, new VIISJwtURL(), saveToken), saveToken).Response()).DeserializedContent();
            foreach (var element in elements)
            {
                this.Add(element);
            }
            Collection = new ObservableCollection<V>(this.Select(element => viewSelector.Invoke(element)).ToList());
            ChangeProperty(nameof(Collection));
        }

        public override async Task UpdateViewAsync(V oldItem, V item)
        {
            await Update(oldItem.Model(), item.Model());
            await UpdateCollectionAsync();
        }
    }
}
