using ElegantLib.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIIS.App.Finance.ViewModels;
using VIIS.App.GlobalViewModel;
using VIIS.App.OrdersJournal.OrderDetail.ViewModels;
using VIIS.App.OrdersJournal.OrderDetail.Views;
using VIIS.Domain.Customers;
using VIIS.Domain.Finance;
using VIIS.Domain.Orders;
using VIIS.Domain.Services;
using VIIS.Domain.Staff;
using VIMVVM;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class ViewWorkDay : Notifier
    {
        public Master CurrentMaster { get; set; }

        public VirtualObservableCollection<PageTime> CurrentTimes { get; set; }

        protected Dictionary<Master, PageTimes> journalPages;
        private readonly Journal journal;
        private readonly ViewRepository<ViewTransaction, Transaction> transactions;
        private readonly Window owner;

        public ViewWorkDay(Dictionary<Master, PageTimes> journalPages, Journal journal, ViewRepository<ViewTransaction, Transaction> transactions, Window owner)
        {
            this.journalPages = journalPages;
            this.journal = journal;
            this.transactions = transactions;
            this.owner = owner;
            //if (journalPages.Count != 0) ChangeMaster(journalPages.Keys.First());
        }
        public ViewWorkDay(List<Master> masters, Journal journal, ViewRepository<ViewTransaction, Transaction> transactions, Window window) :
            this(masters.ToDictionary(master => master, master => new PageTimes(new TimeSpan(8, 0, 0), new TimeSpan(19, 0, 0), journal, transactions)), journal, transactions, window)
        {
        }
        public ViewWorkDay(ViewWorkDay other) : this(other.journalPages, other.journal, other.transactions, other.owner)
        {
        }
        public void AddOrder(Order order, ServiceValueList serviceValueList, Clients clients)
        {
 
            journalPages[order.KeyValue().Key].AddContent(new PageOrder(order, serviceValueList, clients, owner));
            
        }

        public void RemoveOrder(Order order)
        {
                journalPages[order.KeyValue().Key].RemoveContent(order);
        }

        public void ChangeMaster(Master master)
        {
            CurrentTimes = journalPages[master].Content;
            ChangeProperty(nameof(CurrentTimes));
            CurrentMaster = master;
            ChangeProperty(nameof(CurrentMaster));
        }
        public void Clear()
        {
            var pageTimesCollection = journalPages.Values;
            foreach (var pagetimes in pageTimesCollection)
                pagetimes.Clear();
        }
        //public void CreateOrder(DateTime date, ServiceValueList serviceValueList, Clients clients)
        //{
        //    var orderDetail = new OrderDetailView(new OrderDetailVM(new Order(CurrentMaster, date), journal, serviceValueList, clients, transactions));
        //    orderDetail.Show();
        //}
    }
}
