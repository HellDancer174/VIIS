using ElegantLib.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.Models.OrdersDecorators;
using VIIS.App.OrdersJournal.OrderDetail.ViewModels;
using VIIS.App.OrdersJournal.OrderDetail.Views;
using VIIS.Domain.Clients;
using VIIS.Domain.Orders;
using VIIS.Domain.Services;
using VIIS.Domain.Staff;
using VIMVVM;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class WorkDaysPage : Notifier<string>
    {
        public Master CurrentMaster { get; set; }

        public VirtualObservableCollection<PageTime> CurrentTimes { get; set; }

        protected Dictionary<Master, PageTimes> journalPages;

        public WorkDaysPage(Dictionary<Master, PageTimes> journalPages)
        {
            this.journalPages = journalPages;
            if(journalPages.Count != 0) ChangeMaster(journalPages.Keys.First());
        }
        public WorkDaysPage(List<Master> masters) :
            this(masters.ToDictionary(master => master, master => new PageTimes(new TimeSpan(8, 0, 0), new TimeSpan(19, 0, 0))))
        {
        }
        public WorkDaysPage(WorkDaysPage other) : this(other.journalPages)
        {
        }
        public virtual void AddOrder(Order order, ServiceValueList serviceValueList, Clients clients)
        {
            var masterPageOrders = new JournalOrder(order, serviceValueList, clients).PageOrders;
            var pageOrders = masterPageOrders.Value;
            foreach (var pageOrder in pageOrders)
                journalPages[masterPageOrders.Key].AddContent(pageOrder);
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
        public void CreateOrder()
        {
            var orderDetail = new OrderDetailView();//Передать во ViewModel this(WorkDaysPage).
        }
    }
}
