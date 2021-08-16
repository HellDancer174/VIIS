using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIMVVM;
using VIMVVM.Detail;

namespace VIIS.App.GlobalViewModel
{
    public class ViewNewDetail<Repo, V, T> : ViewDetail<Repo, V, T>
             where Repo : ViewRepository<V, T> where V : T, IDetailedViewModel<T> where T : IDocumentAsync
    {
        public ViewNewDetail(Repo repository, V viewModel, V oldViewModel) : base(repository, viewModel, oldViewModel, "Добавить", "Отмена")
        {
        }

        //public override RelayCommand Save => new RelayCommand(async(obj) =>
        //{
        //    //try
        //    //{
        //        await repository.AddViewAsync(ViewModel);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    MessageBox.Show(ex.Message);
        //    //    throw;
        //    //}
        //});

        //public override RelayCommand End => new RelayCommand((obj) => { });

        public override Task EndAsync()
        {
            return Task.CompletedTask;
        }

        public override async Task SaveAsync()
        {
            await repository.AddViewAsync(ViewModel);
        }
    }
}
