using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.App.OrdersJournal.ViewModels.DecoratedJournalTimes
{
    public class SafeJournalTimes : PageTimes
    {
        private readonly PageTimes other;

        public SafeJournalTimes(PageTimes other) : base(other)
        {
            this.other = other;
        }

        public override void AddContent(PageContent content)
        {
            int counter = 0;
            try
            {
                base.AddContent(content);
            }
            catch (ArgumentOutOfRangeException)
            {
                counter++;
            }
        }
    }
}
