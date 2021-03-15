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
        public WorkDaysPage Fake()
        {
            var orders = new Orders();
            var list = new VirtualCollection<PageTime>() { new PageTime(8, orders), new PageTime(9, orders), new PageTime(10, orders), new PageTime(11, orders), new PageTime(12, orders), new PageTime(13, orders), new PageTime(14, orders), new PageTime(15, orders), new PageTime(16, orders), new PageTime(17, orders), new PageTime(18, orders), new PageTime(19, orders) };

            PageTimes content = new SafeJournalTimes(new PageTimes(8, 20, list));
            content.AddContent(new PageContent("Игнатьев В.А", "455476", "", new TimeSpan(9, 00, 0)));
            content.AddContent(new PageContent("Игнатьев В.А", "455476", "", new TimeSpan(9, 30, 0)));
            return new WorkDaysPage("Иванова В.В.", new Dictionary<string, ObservableCollection<PageTime>> { { "Иванова И.И.", new ObservableCollection<PageTime>(content) } });
        }
    }
}
