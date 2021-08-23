using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIMVVM
{
    public interface IViewModel<T>: INotifyPropertyChanged
    {
        T Model();
    }
}
