using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIIS.App.Finance.Views;
using VIIS.App.GlobalViewModel;
using VIIS.Domain.Finance;
using VIMVVM;

namespace VIIS.App.Finance.ViewModels
{
    public class ViewTransactionDetail : ViewWindowDetail<ViewTransactions, ViewTransaction, Transaction>
    {

        public ViewTransactionDetail(ViewDetail<ViewTransactions, ViewTransaction, Transaction> other, Window view) : base(other, view)
        {
        }
        public ViewTransactionDetail(ViewTransactions transactions, ViewTransaction transaction) : 
            this(new ViewDetail<ViewTransactions, ViewTransaction, Transaction>(transactions, transaction, new ViewTransaction(transaction)), new TransactionDetailView())
        {
        }
        public ViewTransactionDetail(ViewTransactions transactions) : this(new ViewNewDetail<ViewTransactions, ViewTransaction, Transaction>(transactions, new ViewTransaction(), new ViewTransaction()), new TransactionDetailView())
        {
        }

        public override RelayCommand Save => new RelayCommand((obj) => { base.Save.Execute(obj); repository.CalcTotal(); });

    }
}
