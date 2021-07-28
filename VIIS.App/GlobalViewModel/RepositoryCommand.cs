using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VIMVVM;
using VIMVVM.Detail;

namespace VIIS.App.GlobalViewModel
{
    public class RepositoryCommand<T> : RelayCommand
    {
        public RepositoryCommand(Action<object> execute, T selected) : base(execute, (obj) => selected is T)
        {
        }
    }
}
