using ElegantLib;
using ElegantLib.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Global
{
    public class Repository<T>: VirtualObservableCollection<T>
        where T: IDocumentAsync
    {
        public Repository(IEnumerable<T> items): base(items)
        {

        }
        public Repository(Repository<T> other): this(other.ToArray())
        {
        }
        public virtual async Task AddAsync(T item)
        {
            Add(item);
            await item.Transfer();
        }

        public virtual async Task Update(T oldItem, T item)
        {
            this[IndexOf(oldItem)] = item;
            await item.Transfer();
        }

        public virtual async Task RemoveAsync(T item)
        {
            Remove(item);
            await item.Transfer();
        }

    }
}
