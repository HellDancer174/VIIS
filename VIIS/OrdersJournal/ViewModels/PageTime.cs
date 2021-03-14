using ElegantLib.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Orders;

namespace VIIS.App.OrdersJournal.ViewModels
{
    public class PageTime: VirtualObservableCollection<PageContent>
    {
        private readonly int timeIndex;
        private readonly Orders orders;

        public string TimeIndex => string.Format("{0}:00",timeIndex);

        private PageContent selected;
        public PageContent Selected
        {
            get => selected;
            set
            {
                selected = value;
            }
        }

        public ObservableCollection<PageContent> Content { get; }

        public PageTime(List<PageContent> content, int timeIndex, Orders orders)
        {
            this.Content = new ObservableCollection<PageContent>(content);
            this.timeIndex = timeIndex;
            this.orders = orders;
        }
        public PageTime(int timeIndex, Orders orders):this(new List<PageContent>(), timeIndex, orders)
        {
        }

        public override void Add(PageContent item)
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
