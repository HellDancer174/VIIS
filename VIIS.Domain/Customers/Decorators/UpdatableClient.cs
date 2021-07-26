using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElegantLib.Authorize.Tokenize;
using ElegantLib.Requests.JsonRequests;

namespace VIIS.Domain.Customers.Decorators
{
    public class UpdatableClient : InsertableClient
    {
        public UpdatableClient(Client other, Action<RefreshViewModel> saveToken, RefreshViewModel token) : base(other, saveToken, token)
        {
            request = new PutJsonRequest(baseRequest, entity);
        }
    }
}
