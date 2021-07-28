using ElegantLib.Authorize.Tokenize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Account
{
    public class VIISJwtURL : JwtURL
    {
        public VIISJwtURL() : base("https://localhost:44395/")
        {
        }

        public virtual string ClientsUrl => string.Format("{0}/api/Clients", url);
        public virtual string MasterssUrl => string.Format("{0}/api/Masters", url);
        public virtual string MasterCashUrl => string.Format("{0}/api/MasterCash", url);
        public virtual string MasterCashListUrl => string.Format("{0}/api/MasterCash/MasterCashList", url);
        public virtual string ServiceValuesUrl => string.Format("{0}/api/ServiceValue", url);
        public virtual string TransactionsUrl => string.Format("{0}/api/Transactions", url);
        public virtual string WorkDaysUrl => string.Format("{0}/api/WorkDays", url);

        public virtual string UsersURL => string.Format("{0}/Account/GetUsers", url);
        public virtual string RemoveUserURL => string.Format("{0}/Account/RemoveUser", url);
        

    }
}
