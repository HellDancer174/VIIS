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
    public abstract class ExtensionViewRepository<V,T>: ViewRepository<V, T>
        where V : T, IDetailedViewModel<T> where T : IDocumentAsync
    {
        public ExtensionViewRepository(Repository<T> other, ObservableCollection<V> collection) : base(other, collection)
        {
        }

        public async Task AddRange(IEnumerable<V> viewModels) 
        {
            foreach (var viewModel in viewModels)
            {
                this.Collection.Add(viewModel);
                this.Add(viewModel);
            }
            await PostRange(viewModels); // отправить на сервер
        }

        protected abstract Task PostRange(IEnumerable<V> viewModels);


    }
}
