using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class WorkDaysPage: ViewModel<string>
    {
        public string Admin { get; set; } // Возможно стоит сделать класс Admin
        public MastersPage CurrentPage { get; set; }
        protected List<MastersPage> journalPages;

        public WorkDaysPage(string admin, List<MastersPage> journalPages)
        {
            Admin = admin;
            this.journalPages = journalPages;
        }
        public WorkDaysPage(WorkDaysPage other): this(other.Admin, other.journalPages)
        {
        }

        public void ChangePage(string master)
        {
            CurrentPage = journalPages.Single(page => page.IsOwner(master));
        }

    }
}
