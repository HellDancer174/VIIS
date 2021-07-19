using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIIS.API.Finance
{
    public class DBMasterCashList : List<DBMasterCash>, IDocument
    {
        

        public DBMasterCashList(IEnumerable<DBMasterCash> collection) : base(collection)
        {
        }

        public void Transfer()
        {
            var failedMessages = string.Empty;

            foreach(var cash in this)
            {
                try
                {
                    cash.Transfer();
                }
                catch (ArgumentException ex)
                {
                    failedMessages += ex.Message;
                }
            }
            if (failedMessages != string.Empty) throw new ArgumentException(failedMessages);
        }
    }
}
