using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VIIS.App.GlobalViewModel;
using VIIS.Domain.Finance;
using VIIS.Domain.Global;
using VIMVVM;

namespace VIIS.App.Finance.ViewModels
{
    public class ViewTransactions : ViewRepository<ViewTransaction, Transaction>
    {
        public ViewTransactions(Repository<Transaction> other, ObservableCollection<ViewTransaction> collection) : base(other, collection)
        {
        }
        public ViewTransactions(Repository<Transaction> other) : this(other, new ObservableCollection<ViewTransaction>(other.Select(transact => new ViewTransaction(transact)).ToArray()))
        {
        }
        public ViewTransactions():this(new Repository<Transaction>(new Transaction[] { new Transaction(), new Transaction(), new Transaction() }))
        {
        }

        public override ICommand AddCommand => new RelayCommand((obj) => { });

        public override ICommand ChangeCommand => new RelayCommand((obj) => { });

        public override ICommand RemoveCommand => new RelayCommand((obj) => { });
    }
}
