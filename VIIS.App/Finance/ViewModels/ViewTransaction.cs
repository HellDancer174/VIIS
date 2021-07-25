using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Finance;
using VIMVVM.Detail;

namespace VIIS.App.Finance.ViewModels
{
    public class ViewTransaction: Transaction, IDetailedViewModel<Transaction>
    {
        public ViewTransaction(): this(new Transaction(nameof(Name), 0))
        {
        }

        public ViewTransaction(Transaction other) : base(other)
        {
        }



        public string Name
        {
            get => name;
            set
            {
                if (value == name) return;
                name = value;
            }
        }
        public decimal Price
        {
            get => sale;
            set
            {
                if (value == sale) return;
                sale = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is ViewTransaction) return base.Equals(obj);
            else return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Transaction Model()
        {
            return new Transaction(this);
        }

        public void NotifySelector()
        {
            ChangeProperty(nameof(Name));
            ChangeProperty(nameof(Price));
        }

    }
}
