using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;
using VIMVVM.Detail;

namespace VIIS.App.GlobalViewModel
{
    public class ViewDetail<Repo,V,T>: Notifier
        where Repo: ViewRepository<V,T> where V:T, IDetailedViewModel<T> where T:IDocumentAsync
    {
        protected string saveName;
        protected string endName;
        protected readonly Repo repository;
        protected readonly V oldViewModel;

        public ViewDetail(Repo repository, V viewModel, V oldViewModel, string saveName, string endName)
        {
            this.saveName = saveName;
            this.endName = endName;
            this.repository = repository;
            ViewModel = viewModel;
            this.oldViewModel = oldViewModel;
        }
        //public ViewDetail(Repo repository, V viewModel, V oldViewModel, string saveName, string endName): this(repository, viewModel, oldViewModel, saveName, endName)
        //{
        //}
        //public ViewDetail(Repo repository, V viewModel, V oldViewModel) : this(repository, viewModel, oldViewModel, "Сохранить", "Удалить")
        //{
        //}
        public ViewDetail(Repo repository, V viewModel, V oldViewModel) : this(repository, viewModel, oldViewModel, "Сохранить", "Удалить")
        {
        }
        public ViewDetail(ViewDetail<Repo, V, T> other): this(other.repository, other.ViewModel, other.oldViewModel, other.saveName, other.endName)
        {
        }

        public virtual string SaveName => saveName;
        public virtual string EndName => endName;

        public virtual RelayCommand Save => new RelayCommand(async (obj) => { await repository.UpdateViewAsync(oldViewModel, ViewModel);
            ViewModel.NotifySelector(); });
        public virtual RelayCommand End => new RelayCommand(async (obj) => await repository.RemoveAsync(oldViewModel));

        public V ViewModel { get; }
    }
}
