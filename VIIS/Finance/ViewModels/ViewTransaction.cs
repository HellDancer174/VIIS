using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Finance;

namespace VIIS.App.Finance.ViewModels
{
    public class ViewTransaction: Transaction
    {
        public ViewTransaction(): this(new Transaction(nameof(Name), 0))
        {
        }

        public ViewTransaction(Transaction other) : base(other)
        {
        }

        public string Name { get => name; set => name = value; }
        public decimal Sale { get => sale; set => sale = value; }
    }
}
