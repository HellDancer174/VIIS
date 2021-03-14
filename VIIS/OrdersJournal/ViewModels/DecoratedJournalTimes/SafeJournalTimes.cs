using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.App.OrdersJournal.ViewModels.DecoratedJournalTimes
{
    public class SafeJournalTimes : JournalTimes
    {
        private readonly JournalTimes other;

        public SafeJournalTimes(JournalTimes other) : base(other)
        {
            this.other = other;
        }

        public override void AddContent(JournalPageContent content)
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
