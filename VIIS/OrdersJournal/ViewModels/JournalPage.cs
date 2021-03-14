using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class JournalPage: ViewModel<string>, IEquatable<JournalPage>
    {
        public string Master { get; set; } //Возможно стоит создать класс "Master";
        public ObservableCollection<JournalTime> Times { get; set; }

        public JournalPage(string master, JournalTimes content)
        {
            Master = master;
            Times = new ObservableCollection<JournalTime>(content);
        }

        public bool Equals(JournalPage other)
        {
            return Master == other.Master;
        }

        public bool IsOwner(string master)//Возможно стоит создать класс "Master";
        {
            return Master == master;
        }
    }
}
