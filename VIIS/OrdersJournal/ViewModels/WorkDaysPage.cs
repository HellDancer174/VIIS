using ElegantLib.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.Models.OrdersDecorators;
using VIIS.App.OrdersJournal.OrderDetail.Views;
using VIIS.Domain.Clients;
using VIIS.Domain.Orders;
using VIIS.Domain.Services;
using VIMVVM;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class WorkDaysPage : Notifier<string>
    {
        public string CurrentMaster { get; set; }
        //private VirtualObservableCollection<PageTime> currentTimes;

        public VirtualObservableCollection<PageTime> CurrentTimes { get; set; }

        protected Dictionary<string, PageTimes> journalPages;

        public WorkDaysPage(Dictionary<string, PageTimes> journalPages)
        {
            this.journalPages = journalPages;
            if(journalPages.Count != 0) ChangeMaster(journalPages.Keys.First());
        }
        public WorkDaysPage(List<string> masters) :
            this(masters.ToDictionary(master => master, master => new PageTimes(new TimeSpan(8, 0, 0), new TimeSpan(19, 0, 0))))
        {
        }
        public WorkDaysPage(WorkDaysPage other) : this(other.journalPages)
        {
        }
        public virtual void AddOrder(Order order, ServiceValueList serviceValueList, Clients clients)
        {
            var master = order.MasterName();
            var pageOrders = new JournalOrder(order, serviceValueList, clients).PageOrders;
            foreach (var pageOrder in pageOrders)
                journalPages[master].AddContent(pageOrder);
        }
        public void ChangeMaster(string master)
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
        public void CreateOrder()
        {
            var orderDetail = new OrderDetailView();//Передать во ViewModel this(WorkDaysPage).
        }
    }
}
