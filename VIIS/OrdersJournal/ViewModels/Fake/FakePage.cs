using ElegantLib.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.ViewModels.DecoratedJournalTimes;
using VIIS.Domain.Orders;

namespace VIIS.App.OrdersJournal.ViewModels.Fake
{
    public class FakePage : WorkDaysPage
    {
        private WorkDaysPage primary;
        public FakePage(WorkDaysPage journal) : base(journal)
        {
            primary = journal;
        }

    }
}
