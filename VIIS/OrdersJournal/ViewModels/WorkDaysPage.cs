using ElegantLib.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.Models.OrdersDecorators;
using VIIS.Domain.Orders;
using VIMVVM;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class WorkDaysPage : ViewModel<string>
    {
        public string CurrentMaster { get; set; }
        public VirtualObservableCollection<PageTime> CurrentTimes { get; set; }

        protected Dictionary<string, PageTimes> journalPages;

        public WorkDaysPage(Dictionary<string, PageTimes> journalPages)
        {
            this.journalPages = journalPages;
        }
        public WorkDaysPage(List<string> masters):
            this(masters.ToDictionary(master => master, master => new PageTimes(new TimeSpan(8,0,0), new TimeSpan(19,0,0))))
        {
        }
        public WorkDaysPage(WorkDaysPage other): this(other.journalPages)
        {
        }
        public virtual void AddOrder(Order order)
        {
            order = new ViewTransferableOrder(order, journalPages);
            order.Transfer();
        }
        public void ChangePage(string master)
        {
            CurrentTimes = journalPages[master];
            CurrentMaster = master;
        }

        public void CreateOrder()
        {
            new OrderDetail.Views.OrderDetail();
        }
    }
}
