﻿using ElegantLib.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.OrderDetail.Views;
using VIIS.Domain.Orders;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class PageTime: VirtualObservableCollection<PageOrder>
    {
        private readonly int timeIndex;
        private readonly Journal journal;

        public string TimeIndex => string.Format("{0}:00",timeIndex);

        private PageOrder selected;
        public PageOrder Selected
        {
            get => selected;
            set
            {
                selected = value;
                if(selected != null) selected.ShowDetail(journal);
            }
        }

        public ObservableCollection<PageOrder> Content { get; private set; }

        public PageTime(List<PageOrder> content, int timeIndex, Journal journal): base(content)
        {
            this.Content = new ObservableCollection<PageOrder>(content);
            this.timeIndex = timeIndex;
            this.journal = journal;
            ChangeProperty(nameof(TimeIndex));
        }
        public PageTime(int timeIndex, Journal journal):this(new List<PageOrder>(), timeIndex, journal)
        {
        }

        public override void Add(PageOrder item)
        {
            if (!item.IsOwnerIndex(timeIndex)) throw new ArgumentOutOfRangeException(String.Format("timeIndex content-а не соответствует timeIndex-у коллекции"));
            foreach(var element in Content)
            {
                if (!element.CheckOrders(item)) throw new ArgumentException(String.Format("Конфликт заказов: {0}; {1}", element.ToString(), item.ToString()));
            }
            Content.Add(item);
        }

        public override bool Remove(PageOrder item)
        {

            return Content.Remove(item);
        }

        public override void Sort()
        {
            var sorted = Content.ToList();
            sorted.Sort();
            Content = new ObservableCollection<PageOrder>(sorted);
            ChangeProperty(nameof(Content));
            
        }
    }
}
