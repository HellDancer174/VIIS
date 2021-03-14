using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class JournalTime: ObservableCollection<JournalPageContent>
    {
        private readonly ObservableCollection<JournalPageContent> content;
        private readonly int timeIndex;

        public string TimeIndex => string.Format("{0}:00",timeIndex);

        public JournalTime(List<JournalPageContent> content, int timeIndex)
        {
            this.content = new ObservableCollection<JournalPageContent>(content);
            this.timeIndex = timeIndex;
        }
        public JournalTime(int timeIndex):this(new List<JournalPageContent>(), timeIndex)
        {
        }

        public bool IsReadOnly => ((IList<JournalPageContent>)content).IsReadOnly;

        public ObservableCollection<JournalPageContent> Content => content;

        public new virtual void Add(JournalPageContent item)
        {
            if (!item.IsOwnerIndex(timeIndex)) throw new ArgumentOutOfRangeException(String.Format("timeIndex content-а не соответствует timeIndex-у коллекции"));
            foreach(var element in content)
            {
                if (!element.CheckOrders(item)) throw new ArgumentException(String.Format("Конфликт заказов: {0}; {1}", element.ToString(), item.ToString()));
            }
            Content.Add(item);
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Content)));

        }

        public new void Clear()
        {
            content.Clear();
        }

        public new bool Contains(JournalPageContent item)
        {
            return content.Contains(item);
        }

        public new void CopyTo(JournalPageContent[] array, int arrayIndex)
        {
            content.CopyTo(array, arrayIndex);
        }

        public new IEnumerator<JournalPageContent> GetEnumerator()
        {
            return ((IList<JournalPageContent>)content).GetEnumerator();
        }

        public new int IndexOf(JournalPageContent item)
        {
            return content.IndexOf(item);
        }

        public new void Insert(int index, JournalPageContent item)
        {
            content.Insert(index, item);
        }

        public new virtual bool Remove(JournalPageContent item)
        {
            return content.Remove(item);
        }

        public new virtual void RemoveAt(int index)
        {
            content.RemoveAt(index);
        }

    }
}
