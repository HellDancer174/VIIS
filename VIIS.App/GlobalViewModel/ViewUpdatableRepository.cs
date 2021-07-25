using ElegantLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Global;
using VIMVVM.Detail;

namespace VIIS.App.GlobalViewModel
{
    public abstract class ViewUpdatableRepository<V, T>: ViewRepository<V, T>
     where V : T, IDetailedViewModel<T> where T : IDocumentAsync
    {
        public ViewUpdatableRepository(Repository<T> other, ObservableCollection<V> collection) : base(other, collection)
        {
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

        public abstract Task UpdateCollectionAsync();

        public override async Task UpdateViewAsync(V oldItem, V item)
        {
            await Update(oldItem.Model(), item.Model());
            await UpdateCollectionAsync();
        }
    }
}
