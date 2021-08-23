using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIMVVM.Detail
{
    public interface IDetailedViewModel<T>: IViewModel<T>
    {
        void NotifySelector();
    }
}
