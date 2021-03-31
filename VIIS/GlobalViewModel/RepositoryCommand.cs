using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VIIS.App.GlobalViewModel
{
    public class RepositoryCommand<V, T> : ICommand
        where V:T, new() where T: IDocumentAsync
    {
        private readonly V viewModel;
        private readonly ViewRepository<V, T> repository;

        public RepositoryCommand(V viewModel, ViewRepository<V,T> repository)
        {
            this.viewModel = viewModel;
            this.repository = repository;
        }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public virtual void Execute(object parameter)
        {

        }
    }
}
