using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib
{
    public interface IDocument
    {
        void Transfer();
    }
    public interface IDocument<T>
    {
        T TransferWithKey();
    }
    public interface IDocumentAsync
    {
        Task TransferAsync();
    }

}
