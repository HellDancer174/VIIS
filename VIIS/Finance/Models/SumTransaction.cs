using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Finance;

namespace VIIS.App.Finance.Models
{
    public class SumTransaction : DecoratableTransaction
    {
        private readonly IEnumerable<Transaction> transactionList;
        private Transaction proceedsTransact;
        private Transaction costTransact;

        public SumTransaction(IEnumerable<Transaction> transactionList) : base(new Transaction())
        {
            this.transactionList = transactionList;
            proceedsTransact = new Transaction();
            costTransact = new Transaction();
            foreach (var transact in transactionList)
            {
                if (transact.IsCost()) costTransact = costTransact.Sum(transact);
                else proceedsTransact = proceedsTransact.Sum(transact);

            }

        }

        public decimal Summary()
        {
            return proceedsTransact.Sale;
        }

        public decimal Cost()
        {
            return Math.Abs(costTransact.Sale);
        }

    }
}
