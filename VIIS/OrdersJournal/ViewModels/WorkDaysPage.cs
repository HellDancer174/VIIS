using ElegantLib.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class WorkDaysPage : ViewModel<string>
    {
        public string Admin { get; set; } // Возможно стоит сделать класс Admin

        public string CurrentMaster { get; set; }
        public VirtualObservableCollection<PageTime> CurrentTimes { get; set; }

        protected Dictionary<string, VirtualObservableCollection<PageTime>> journalPages;

        public WorkDaysPage(string admin, Dictionary<string, VirtualObservableCollection<PageTime>> journalPages)
        {
            Admin = admin;
            this.journalPages = journalPages;
        }
        public WorkDaysPage(WorkDaysPage other): this(other.Admin, other.journalPages)
        {
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
