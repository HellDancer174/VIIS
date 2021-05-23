using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Finance;
using VIIS.Domain.Orders;
using VIIS.Domain.Orders.Decorators;

namespace VIIS.App.Finance.Models
{
    public class TransactableOrders : OrdersDecorator
    {
        private readonly string transactionName;

        public TransactableOrders(Orders other, string transactionName) : base(other)
        {
            this.transactionName = transactionName;
        }

        public Transaction Transaction()
        {
            return new Transaction(transactionName, TotalSale);
        }
    }
}
