using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib.Documents
{
    public class AnyDocument : IDocument
    {
        public virtual void Transfer()
        {
            return;
        }
    }

    public class AnyAsyncDocument : IDocumentAsync
    {
        public virtual async Task TransferAsync()
        {
            await Task.CompletedTask;
        }
    }

    public class AnyDocument<T>: IDocument<T>
    where T: new()
    {
        public T TransferWithKey()
        {
            return new T();
        }
    }

}
