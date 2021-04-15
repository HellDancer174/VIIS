using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VIIS.App.Finance.Models;
using VIIS.App.Finance.Views;
using VIIS.App.GlobalViewModel;
using VIIS.Domain.Finance;
using VIIS.Domain.Global;
using VIMVVM;

namespace VIIS.App.Finance.ViewModels
{
    public class ViewTransactions : ViewRepository<ViewTransaction, Transaction>
    {

        private decimal proceeds;
        private decimal middleSale;
        private decimal cost;

        public ViewTransactions(Repository<Transaction> other, ObservableCollection<ViewTransaction> collection) : base(other, collection)
        {
            var sum = new SumTransaction(this);
            proceeds = sum.Summary();
            cost = sum.Cost();
            middleSale = 0;
        }
        public ViewTransactions(Repository<Transaction> other) : this(other, new ObservableCollection<ViewTransaction>(other.Select(transact => new ViewTransaction(transact)).ToArray()))
        {
        }
        public ViewTransactions():this(new Repository<Transaction>(new Transaction[] { new Transaction(), new Transaction(), new Transaction() }))
        {
        }

        public override ICommand AddCommand => new RelayCommand((obj) => { new ViewTransactionDetail(this); });

        public override ICommand ChangeCommand => new RelayCommand((obj) => { new ViewTransactionDetail(this, Selected); });

        public override ICommand RemoveCommand => new RelayCommand(async(obj) => { await RemoveViewAsync(Selected); });

        public decimal Proceeds
        {
            get => proceeds;
            set
            {
                if (value == proceeds) return;
                proceeds = value;
                ChangeProperty();
            }
        }

        public decimal MiddleSale
        {
            get => middleSale;
            set
            {
                if (value == middleSale) return;
                middleSale = value;
                ChangeProperty();
            }
        }

        public decimal Cost
        {
            get => cost;
            set
            {
                if (value == cost) return;
                middleSale = value;
                ChangeProperty();
            }
        }

    }
}
