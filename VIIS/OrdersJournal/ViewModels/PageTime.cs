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
    public class PageTime: VirtualObservableCollection<PageViewService>
    {
        private readonly int timeIndex;

        public string TimeIndex => string.Format("{0}:00",timeIndex);

        private PageViewService selected;
        public PageViewService Selected
        {
            get => selected;
            set
            {
                selected = value;
                selected.ShowDetail(this);
            }
        }

        public ObservableCollection<PageViewService> Content { get; }

        public PageTime(List<PageViewService> content, int timeIndex): base(content)
        {
            this.Content = new ObservableCollection<PageViewService>(content);
            this.timeIndex = timeIndex;
            ChangeProperty(nameof(TimeIndex));
        }
        public PageTime(int timeIndex):this(new List<PageViewService>(), timeIndex)
        {
        }

        public override void Add(PageViewService item)
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
