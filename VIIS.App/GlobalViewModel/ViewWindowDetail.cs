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
    public class ViewWindowDetail<Repo, V, T> : ViewDetail<Repo, V, T>
     where Repo : ViewRepository<V, T> where V : T, IDetailedViewModel<T> where T : IDocumentAsync
    {
        private readonly ViewDetail<Repo, V, T> other;
        protected readonly Window view;

        public ViewWindowDetail(ViewDetail<Repo, V, T> other, Window view) : base(other)
        {
            this.other = other;
            this.view = view;
            view.DataContext = this;
            view.Show();
            repository.Selected = default(V);
        }

        public override async Task SaveAsync()
        {
            try
            {
                await other.SaveAsync();
                view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        public override async Task EndAsync()
        {
            try
            {
                await other.EndAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        //public override RelayCommand Save => new RelayCommand((obj) => 
        //{
        //    try
        //    {
        //        other.Save.Execute(obj);
        //        view.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return;
        //    }
        //});

        //public override RelayCommand End => new RelayCommand((obj) => 
        //{
        //    try
        //    {
        //        other.End.Execute(obj);
        //        view.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return;
        //    }
        //});
    }
}
