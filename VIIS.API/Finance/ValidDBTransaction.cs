using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.GlobalModel;

namespace VIIS.API.Finance
{
    public class ValidDBTransaction : DBTransaction
    {
        private readonly DBTransaction dBTransaction;
        private ValidID validID;

        public ValidDBTransaction(DBTransaction dBTransaction, Func<int, bool> validateID) : base(dBTransaction)
        {
            validID = new ValidID("TransactionID", id, validateID);
            this.dBTransaction = dBTransaction;
        }

        public override void Transfer()
        {
            validID.Validate();
            dBTransaction.Transfer();
        }
    }
}
