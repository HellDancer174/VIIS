using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib.Validate.Interfaces
{
    public interface IValidatable<T>
    {
        T Safe();
        T UnSafe();
    }
}
