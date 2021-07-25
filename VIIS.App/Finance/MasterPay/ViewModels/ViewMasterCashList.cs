using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VIIS.App.Finance.ViewModels;
using VIIS.App.GlobalViewModel;
using VIIS.App.Staff.ViewModels;
using VIIS.Domain.Finance;
using VIIS.Domain.Finance.Decorators;
using VIIS.Domain.Global;
using VIMVVM;

namespace VIIS.App.Finance.MasterPay.ViewModels
{
    public class ViewMasterCashList: ViewRepository<ViewMasterCash, MasterCash>
    {
        private readonly ViewTransactions transactions;
        private readonly List<ViewEmployee> masters;

        public ViewMasterCashList(Repository<MasterCash> other, ViewTransactions transactions, List<ViewEmployee> masters) : this(other, new ObservableCollection<ViewMasterCash>(other.Select(cash => new ViewMasterCash(cash)).ToArray()), transactions, masters)
        {
        }
        public ViewMasterCashList(ViewMasterCashList other): this(other, other.Collection, other.transactions, other.masters)
        {
        }
        public ViewMasterCashList(Repository<MasterCash> repo, ViewMasterCashList other): this(repo, other.transactions, other.masters)
        {
        }

        public ViewMasterCashList(Repository<MasterCash> other, ObservableCollection<ViewMasterCash> collection, ViewTransactions transactions, List<ViewEmployee> masters) : base(other, collection)
        {
            this.transactions = transactions;
            this.masters = masters;
        }

        public override ICommand AddCommand => new RelayCommand((obj) => new WindowMasterCashDetail(this, masters));

        public override ICommand ChangeCommand => new RelayCommand((obj) => new WindowMasterCashDetail(this, masters));

        public override ICommand RemoveCommand => new RelayCommand(async (obj) =>
        {
            await RemoveViewAsync(Selected);

        });

        public async Task AddRange(IEnumerable<ViewMasterCash> viewMasterCashes)
        {
            foreach(var cash in viewMasterCashes)
            {
                Collection.Add(cash);
                this.Add(cash);
            }

            await Task.CompletedTask; //отправить список на сервер
            await transactions.AddRange(viewMasterCashes.Select(cash => new ViewTransaction(cash.Transaction))); //Добавить транзакции
        }

        public async Task AddRange(IEnumerable<ViewMasterCash> viewMasterCashes, DateTime startDate, DateTime finishDate)
        {
            if (finishDate.Month != startDate.Month || finishDate.Year != startDate.Year) throw new ArgumentException("Начало и конец периода должны быть в одном месяце");
            var monthCollection = Collection.Where(cash => cash.CheckMonth(finishDate)).ToList();
            foreach(var cash in viewMasterCashes)
            {
                foreach(var otherCash in monthCollection)
                {
                    if (otherCash.CheckCollision(cash)) throw new InvalidOperationException(String.Format("Найдена коллизия: {0} и {1}", cash, otherCash));
                }
            }
            await AddRange(viewMasterCashes);
        }

        public override async Task RemoveViewAsync(ViewMasterCash item)
        {
            await base.RemoveViewAsync(item);
            var transact = item.Transaction;
            await transactions.AddViewAsync(new ViewTransaction(new Transaction(String.Format("Возврат транзакции ${0}$", transact), 0 - transact.Sale)));
        }

        public override async Task AddViewAsync(ViewMasterCash item)
        {
            await base.AddViewAsync(item);
            await transactions.AddViewAsync(new ViewTransaction(item.Transaction));
        }
    }
}
