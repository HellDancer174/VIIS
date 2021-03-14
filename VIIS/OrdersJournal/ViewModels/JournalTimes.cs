using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class JournalTimes: IList<JournalTime>
    {
        private int startIndex;
        private int finishIndex;
        private Action<int> validIndex;

        public IList<JournalTime> Content { get; }

        public int Count => Content.Count;

        public bool IsReadOnly => Content.IsReadOnly;

        public JournalTimes(int startIndex, int finishIndex, IList<JournalTime> content)
        {
            if (content.Count > 12) throw new ArgumentException("В коллекции должно быть не больше 12 элементов");
            this.Content = content;
            this.startIndex = startIndex;
            this.finishIndex = finishIndex;
            validIndex = (index) =>
            {
                if (index >= finishIndex || index <= startIndex)
                    throw new ArgumentOutOfRangeException(String.Format("index должен быть >= {0} и {1} <=", startIndex, finishIndex));
            };
        }
        public JournalTimes(TimeSpan start, TimeSpan finish): this(start.Hours, finish.Hours, new List<JournalTime>(12))
        {
        }

        public JournalTimes(JournalTimes other): this(other.startIndex, other.finishIndex, other.Content)
        {
        }

        public JournalTime this[int index]
        {
            get
            {
                validIndex(index);
                return Content[index - startIndex];
            }
            set
            {
                validIndex(index);
                Content[index - startIndex] = value;
            }
        }

        public virtual void AddContent(JournalPageContent content)
        {
            validIndex(content.ContentIndex());
            this.Content[content.ContentIndex() - startIndex].Add(content);
        }

        public int IndexOf(JournalTime item)
        {
            var index = Content.IndexOf(item);
            if (index == -1) return index;
            else return index + startIndex;
        }

        public void Insert(int index, JournalTime item)
        {
            validIndex(index);
            Content.Insert(index - startIndex, item);
        }

        public void RemoveAt(int index)
        {
            validIndex(index);
            Content.RemoveAt(index - startIndex);
        }

        public void Add(JournalTime item)
        {
            if (Count >= 12) throw new InvalidOperationException("Нельзя добавить больше 12 элементов");
            Content.Add(item);
        }

        public void Clear()
        {
            Content.Clear();
        }

        public bool Contains(JournalTime item)
        {
            return Content.Contains(item);
        }

        public void CopyTo(JournalTime[] array, int arrayIndex)
        {
            Content.CopyTo(array, arrayIndex);
        }

        public bool Remove(JournalTime item)
        {
            return Content.Remove(item);
        }

        public IEnumerator<JournalTime> GetEnumerator()
        {
            return Content.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Content.GetEnumerator();
        }

    }
}
