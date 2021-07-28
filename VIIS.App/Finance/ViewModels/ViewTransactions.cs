using ElegantLib.Authorize.Tokenize;
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
using VIIS.Domain.Account;
using VIIS.Domain.Finance;
using VIIS.Domain.Global;
using VIMVVM;

namespace VIIS.App.Finance.ViewModels
{
    public class ViewTransactions : ViewUpdatableRepository<ViewTransaction, Transaction>
    {

        private decimal proceeds;
        private decimal balance;
        private decimal cost;

        public ViewTransactions(Repository<Transaction> other, Action<RefreshViewModel> saveToken) : 
            base(other, saveToken, (transaction) => new ViewTransaction(transaction), new VIISJwtURL().TransactionsUrl)
        {
            CalcTotal();
        }
        //public ViewTransactions(Repository<Transaction> other) : this(other, new ObservableCollection<ViewTransaction>(other.Select(transact => new ViewTransaction(transact)).ToList()))
        //{
        //}
        public ViewTransactions():this(new Repository<Transaction>(new Transaction[] { new Transaction(), new Transaction("pro", 5), new Transaction("dsp", 9) }), (token) => App.Token = token)
        {
        }

        public override ICommand AddCommand => new RelayCommand((obj) => { new ViewTransactionDetail(this); });

        public override ICommand ChangeCommand => new RelayCommand((obj) => { new ViewTransactionDetail(this, new ViewTransaction(Selected)); });

        public override ICommand RemoveCommand => new RelayCommand(async(obj) => { await RemoveViewAsync(Selected); CalcTotal(); });

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

        public decimal Balance
        {
            get => balance;
            set
            {
                if (value == balance) return;
                balance = value;
                ChangeProperty();
            }
        }

        public decimal Cost
        {
            get => cost;
            set
            {
                if (value == cost) return;
                cost = value;
                ChangeProperty();
            }
        }

        public void CalcTotal()
        {
            var sum = new SumTransaction(this);
            Proceeds = sum.Summary();
            Cost = sum.Cost();
            Balance = Proceeds - Cost;
        }

        public override async Task AddViewAsync(ViewTransaction item)
        {
            await base.AddViewAsync(item);
            CalcTotal();
        }

        public override async Task RemoveViewAsync(ViewTransaction item)
        {
            await base.RemoveViewAsync(item);
            CalcTotal();
        }

        public async Task AddRange(IEnumerable<ViewTransaction> viewTransactions)
        {
            foreach(var transact in viewTransactions)
            {
                await AddAsync(transact.Model());
            }
            await UpdateCollectionAsync();
            CalcTotal();
            //await Task.CompletedTask; // отправить на сервер
        }
    }
}
