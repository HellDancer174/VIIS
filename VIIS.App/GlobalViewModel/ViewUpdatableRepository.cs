using ElegantLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Account;
using VIIS.Domain.Global;
using VIMVVM.Detail;

namespace VIIS.App.GlobalViewModel
{
    public abstract class ViewUpdatableRepository<V, T>: ViewRepository<V, T>
     where V : T, IDetailedViewModel<T> where T : IDocumentAsync
    {
        private readonly Func<HttpClient, VIISJwtURL, Task<IEnumerable<T>>> requestsFunc;
        private readonly Func<T, V> viewSelector;

        //public ViewUpdatableRepository(Repository<T> other, ObservableCollection<V> collection) : base(other, collection)
        //{
        //}
        public ViewUpdatableRepository(Repository<T> other, Func<HttpClient, VIISJwtURL, Task<IEnumerable<T>>> requestsFunc, Func<T, V> viewSelector):
            base(other, new ObservableCollection<V>(other.Select(element => viewSelector.Invoke(element)).ToArray()))
        {
            this.requestsFunc = requestsFunc;
            this.viewSelector = viewSelector;
        }

        public override async Task AddViewAsync(V item)
        {
            await AddAsync(item.Model());
            await UpdateCollectionAsync();
        }

        public override async Task RemoveViewAsync(V item)
        {
            await RemoveAsync(item.Model());
            await UpdateCollectionAsync();
        }

        public virtual async Task UpdateCollectionAsync()
        {
            var url = new VIISJwtURL();
            this.Clear();
            var elements = await requestsFunc.Invoke(new HttpClient(), url);
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
