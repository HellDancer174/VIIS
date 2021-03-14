using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class Journal
    {
        public string Admin { get; set; }
        public List<JournalPage> JournalPages { get; set; }

        public Journal(string admin, List<JournalPage> journalPages)
        {
            Admin = admin;
            JournalPages = journalPages;
        }

    }
}
