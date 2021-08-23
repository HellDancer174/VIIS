using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib
{
    public interface IRepository<T>
    {
        IEnumerable<T> Entities { get; }
    }
    public interface IAsyncRepository<T>
    {
        Task<IEnumerable<T>> Entities();
    }





}
