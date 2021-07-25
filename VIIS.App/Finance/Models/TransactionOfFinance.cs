using ElegantLib.Validate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIIS.Domain.Finance;
using VIIS.Domain.Global;

namespace VIIS.App.Finance.Models
{
    public class TransactionOfFinance : DecoratableTransaction, IValidatable<Transaction>
    {
        private ValidProperty<string> validName;
        private ValidProperty<decimal> validSale; 

        public TransactionOfFinance(Transaction other) : base(other)
        {
            validName = new ValidProperty<string>("Название транзакции", name, !(String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name)));
            validSale = new ValidProperty<decimal>("Стоимость транзакции", sale, sale != 0);
        }

        public Transaction Safe()
        {
            try
            {
                return UnSafe();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public Transaction UnSafe()
        {
            validSale.Validate();
            validName.Validate();
            return this;
        }
    }
}
