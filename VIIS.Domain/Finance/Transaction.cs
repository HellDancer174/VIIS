using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;

namespace VIIS.Domain.Finance
{
    public class Transaction: Notifier, IDocumentAsync
    {
        protected string name;
        protected decimal sale;

        public Transaction(string name, decimal sale)
        {
            this.name = name;
            this.sale = sale;
        }
        public Transaction(): this(nameof(name), 0)
        {
        }
        public Transaction(Transaction other): this(other.name, other.sale)
        {
        }

        public Transaction Sum(Transaction other)
        {
            return new Transaction("Сумма", sale + other.sale);
        }

        public Task Transfer()
        {
            return Task.CompletedTask;
        }
    }
}
