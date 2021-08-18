using ElegantLib.Authorize.Tokenize;
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
using VIIS.Domain.Account;
using VIIS.Domain.Finance;
using VIIS.Domain.Finance.Decorators;
using VIIS.Domain.Global;
using VIIS.Domain.Global.Documents;
using VIMVVM;

namespace VIIS.App.Finance.MasterPay.ViewModels
{
    public class ViewMasterCashList: ViewUpdatableRepository<ViewMasterCash, MasterCash>
    {
        private readonly Action<RefreshViewModel> saveToken;
        private readonly ViewTransactions transactions;
        private readonly List<ViewEmployee> masters;

        public ViewMasterCashList(Repository<MasterCash> other, ViewTransactions transactions, List<ViewEmployee> masters) :
            this(other, (token) => App.Token = token, transactions, masters)
        {
        }
        public ViewMasterCashList(ViewMasterCashList other): this(other, (token) => App.Token = token, other.transactions, other.masters)
        {
        }
        public ViewMasterCashList(Repository<MasterCash> repo, ViewMasterCashList other): this(repo, other.transactions, other.masters)
        {
        }

        public ViewMasterCashList(Repository<MasterCash> other, Action<RefreshViewModel> saveToken, ViewTransactions transactions, List<ViewEmployee> masters) : 
            base(other, saveToken, (cash) => new ViewMasterCash(cash), new VIISJwtURL().MasterCashUrl)
        {
            this.saveToken = saveToken;
            this.transactions = transactions;
            this.masters = masters;
        }

        public override ICommand AddCommand => new RelayCommand((obj) => new WindowMasterCashDetail(this, masters));

        public override ICommand ChangeCommand => new RelayCommand((obj) => new WindowMasterCashDetail(this, Selected, masters), (obj) => Selected is ViewMasterCash);

        public override ICommand RemoveCommand => new RelayCommand(async (obj) =>
        {
            await RemoveViewAsync(Selected);
        }, (obj) => Selected is ViewMasterCash);

        public async Task AddRange(IEnumerable<ViewMasterCash> viewMasterCashes)
        {
            await new InsertableDocument(new MasterCashList(viewMasterCashes), saveToken, App.Token, new VIISJwtURL().MasterCashListUrl).TransferAsync();
            foreach(var cash in viewMasterCashes)
            {
                Collection.Add(cash);
                this.Add(cash);
            }
            await transactions.AddRange(viewMasterCashes.Select(cash => new ViewTransaction(cash.Transaction)).ToArray()); //Добавить транзакции
        }

        public async Task AddRange(IEnumerable<ViewMasterCash> viewMasterCashes, DateTime startDate, DateTime finishDate)
        {
            if (finishDate.Month != startDate.Month || finishDate.Year != startDate.Year) throw new ArgumentException("Начало и конец периода должны быть в одном месяце");
            var monthCollection = Collection.Where(cash => cash.CheckMonth(finishDate)).ToList();
            //var masterListOfMonthCollection = monthCollection.ToDictionary(cash => cash.MasterName);
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
            await transactions.AddViewAsync(new ViewTransaction(new Transaction(String.Format("Возврат транзакции ${0}$", transact.ToString()), 0 - transact.Sale)));
        }

        public override async Task AddViewAsync(ViewMasterCash item)
        {
            await base.AddViewAsync(item);
            await transactions.AddViewAsync(new ViewTransaction(item.Transaction));
        }

        public override async Task UpdateViewAsync(ViewMasterCash oldItem, ViewMasterCash item)
        {
            var index = IndexOf(oldItem);
            if (index == -1) index = IndexOf(item);
            this[index] = item;
            await new UpdatableDocument(new UpdateMasterCashViewModel(oldItem.Model(), item.Model()), (token) => App.Token = token, App.Token, new VIISJwtURL().MasterCashUrl).TransferAsync();
            var oldTransact = oldItem.Transaction;
            await transactions.AddViewAsync(new ViewTransaction(new Transaction(String.Format("Возврат транзакции ${0}$", oldTransact.ToString()), 0 - oldTransact.Sale)));
            await transactions.AddViewAsync(new ViewTransaction(item.Transaction));
            await UpdateCollectionAsync();
        }
    }
}
