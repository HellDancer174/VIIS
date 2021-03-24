using ElegantLib.Collections;
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
        private readonly PageTimes pageTimes;

        public string TimeIndex => string.Format("{0}:00",timeIndex);

        private PageOrder selected;
        public PageOrder Selected
        {
            get => selected;
            set
            {
                selected = value;
                selected.ShowDetail(pageTimes);
            }
        }

        public ObservableCollection<PageOrder> Content { get; }

        public PageTime(List<PageOrder> content, int timeIndex, PageTimes pageTimes): base(content)
        {
            this.Content = new ObservableCollection<PageOrder>(content);
            this.timeIndex = timeIndex;
            this.pageTimes = pageTimes;
            ChangeProperty(nameof(TimeIndex));
        }
        public PageTime(int timeIndex, PageTimes pageTimes):this(new List<PageOrder>(), timeIndex, pageTimes)
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

    }
}
