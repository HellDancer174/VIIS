using ElegantLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VIIS.Domain.Global;
using VIMVVM;
using VIMVVM.Detail;

namespace VIIS.App.GlobalViewModel
{
    public abstract class ViewRepository<V, T> : Repository<T>
        where V : T, IDetailedViewModel<T> where T : IDocumentAsync
    {
        private V selected;

        public ViewRepository(Repository<T> other, ObservableCollection<V> collection) : base(other)
        {
            this.Collection = collection;
        }

        public ObservableCollection<V> Collection { get; set; }

        public V Selected { get => selected;
            set { selected = value; } }

        public abstract ICommand AddCommand { get; }
        public abstract ICommand ChangeCommand { get; }
        public abstract ICommand RemoveCommand { get; }


        public async Task AddViewAsync(V item)
        {
            Collection.Add(item);
            ChangeProperty(nameof(Collection));
            await AddAsync(item);
        }


        public async Task RemoveViewAsync(V item)
        {
            Collection.Remove(item);
            ChangeProperty(nameof(Selected));
            ChangeProperty(nameof(Collection));
            await base.RemoveAsync(item);
        }

        public virtual async Task UpdateViewAsync(V oldItem, V item)
        {
            var index = Collection.IndexOf(oldItem);
            if (index == -1) index = Collection.IndexOf(item);
            Collection[index] = item;
            await Update(oldItem, item.Model());
            ChangeProperty(nameof(Collection));
            //ChangeProperty(nameof(Selected));
        }

    }
}
