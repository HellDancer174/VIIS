﻿using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;
using VIMVVM.Detail;

namespace VIIS.App.GlobalViewModel
{
    public class ViewNewDetail<Repo, V, T> : ViewDetail<Repo, V, T>
             where Repo : ViewRepository<V, T> where V : T, IDetailedViewModel where T : IDocumentAsync
    {
        public ViewNewDetail(Repo repository, V viewModel, V oldViewModel) : base(repository, viewModel, oldViewModel, "Добавить", "Отмена")
        {
        }

        public override RelayCommand Save => new RelayCommand(async(obj) => await repository.AddViewAsync(ViewModel));

        public override RelayCommand End => new RelayCommand((obj) => { });
    }
}
