using ElegantLib.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using VIIS.App.OrdersJournal.Models.OrdersDecorators;
using VIIS.App.OrdersJournal.OrderDetail.Models;
using VIIS.Domain.Customers;
using VIIS.Domain.Orders;
using VIIS.Domain.Services;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class PageTimes: VirtualObservableCollection<PageTime>
    {
        private int startIndex;
        private int finishIndex;
        private Action<int> validIndex;

        public VirtualObservableCollection<PageTime> Content { get; }

        public PageTimes(int startIndex, int finishIndex, VirtualObservableCollection<PageTime> content): base(content)
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
        public PageTimes(int startIndex, int finishIndex, Journal journal) : this(startIndex, finishIndex, new VirtualObservableCollection<PageTime>(new PageTime[12]))
        {
            for(int i = 0; i < 12; i++)
            {
                Content[i] = new PageTime(i + startIndex, journal);
            }
        }
        public PageTimes(TimeSpan start, TimeSpan finish, Journal journal): this(start.Hours, finish.Hours, journal)
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

        public virtual void AddContent(PageOrder order)
        {
            validIndex(order.ContentIndex());
            Content[order.ContentIndex() - startIndex].Add(order);
            Content[order.ContentIndex() - startIndex].Sort();
        }

        public void AddContent(Order order, ServiceValueList serviceValueList, Clients clients)
        {
            var masterPageOrders = new JournalOrder(order, serviceValueList, clients).PageOrders;
            var pageOrders = masterPageOrders.Value;
            foreach (var pageOrder in pageOrders)
                        AddContent(pageOrder);

        }

        public virtual void RemoveContent(PageOrder order)
        {
            validIndex(order.ContentIndex());
            Content[order.ContentIndex() - startIndex].Remove(order);
        }
        public virtual void RemoveContent(Order order)
        {
            var list = new List<PageOrder>();
            foreach(var time in Content)
            {
                foreach(var pageOrder in time.Content)
                {
                    if (pageOrder.Equals(order)) list.Add(pageOrder);
                }
            }
            foreach (var pageOrder in list)
                RemoveContent(pageOrder);

        }
        public virtual void RemoveContent(Service service)
        {
            var indexed = new IndexedService(service);
            validIndex(indexed.TimeIndex());
            Content[indexed.TimeIndex() - startIndex].Remove(Content[indexed.TimeIndex() - startIndex].Single(pageService => pageService.Equals(service)));
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
