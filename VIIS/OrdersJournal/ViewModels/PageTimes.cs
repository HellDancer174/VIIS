using ElegantLib.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class PageTimes: VirtualCollection<PageTime>
    {
        private int startIndex;
        private int finishIndex;
        private Action<int> validIndex;

        public VirtualCollection<PageTime> Content { get; }

        public PageTimes(int startIndex, int finishIndex, VirtualCollection<PageTime> content): base(content)
        {
            if (content.Count > 12) throw new ArgumentException("В коллекции должно быть не больше 12 элементов");
            Content = content;
            this.startIndex = startIndex;
            this.finishIndex = finishIndex;
            validIndex = (index) =>
            {
                if (index >= finishIndex || index <= startIndex)
                    throw new ArgumentOutOfRangeException(String.Format("index должен быть >= {0} и {1} <=", startIndex, finishIndex));
            };
        }
        public PageTimes(TimeSpan start, TimeSpan finish): this(start.Hours, finish.Hours, new VirtualCollection<PageTime>(12))
        {
        }

        public PageTimes(PageTimes other): this(other.startIndex, other.finishIndex, other.Content)
        {
        }

        public override PageTime this[int index]
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

        public virtual void AddContent(PageContent content)
        {
            validIndex(content.ContentIndex());
            Content[content.ContentIndex() - startIndex].Add(content);
        }

        public override int IndexOf(PageTime item)
        {
            var index = Content.IndexOf(item);
            if (index == -1) return index;
            else return index + startIndex;
        }

        public override void Insert(int index, PageTime item)
        {
            validIndex(index);
            Content.Insert(index - startIndex, item);
        }

        public override void RemoveAt(int index)
        {
            validIndex(index);
            Content.RemoveAt(index - startIndex);
        }

        public override void Add(PageTime item)
        {
            if (Count >= 12) throw new InvalidOperationException("Нельзя добавить больше 12 элементов");
            Content.Add(item);
        }

    }
}
