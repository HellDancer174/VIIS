using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIMVVM;

namespace VIIS.App.GlobalViewModel
{
    public class ViewWindowDetail<Repo, V, T> : ViewDetail<Repo, V, T>
     where Repo : ViewRepository<V, T> where V : T where T : IDocumentAsync
    {
        private readonly ViewDetail<Repo, V, T> other;
        protected readonly Window view;

        public ViewWindowDetail(ViewDetail<Repo, V, T> other, Window view) : base(other)
        {
            this.other = other;
            this.view = view;
            view.DataContext = this;
            view.Show();
        }

        public override RelayCommand Save => new RelayCommand((obj) => { other.Save.Execute(obj); view.Close(); });

        public override RelayCommand End => new RelayCommand((obj) => { other.End.Execute(obj); view.Close(); });
    }
}
