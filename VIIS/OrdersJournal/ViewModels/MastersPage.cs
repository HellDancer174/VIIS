using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;

namespace VIIS.App.OrdersJournal.ViewModels
{
    /// <summary>
    /// Является сущностью страницы журнала
    /// </summary>
    public class MastersPage: ViewModel<string>, IEquatable<MastersPage>
    {
        public string Master { get; set; } //Возможно стоит создать класс "Master";
        public ObservableCollection<PageTime> Times { get; set; }

        public MastersPage(string master, PageTimes times)
        {
            Master = master;
            Times = new ObservableCollection<PageTime>(times);
        }

        public bool Equals(MastersPage other)
        {
            return Master == other.Master;
        }

        public bool IsOwner(string master)//Возможно стоит создать класс "Master";
        {
            return Master == master;
        }

        public KeyValuePair<string, ObservableCollection<PageTime>> KeyValue => new KeyValuePair<string, ObservableCollection<PageTime>>(Master, Times);
    }
}
