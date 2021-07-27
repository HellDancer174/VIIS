using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElegantLib;
using ElegantLib.Authorize.Tokenize;
using ElegantLib.Requests.JsonRequests;

namespace VIIS.Domain.Global.Documents
{
    public class RemovableDocument : InsertableDocument
    {
        public RemovableDocument(IDocumentAsync document, Action<RefreshViewModel> saveToken, RefreshViewModel token, string url) : base(document, saveToken, token, url)
        {
            request = new DeleteJsonRequest(baseRequest, entity);
        }
    }
}
