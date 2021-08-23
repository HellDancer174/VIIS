using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib.Collections
{
    public class VirtualObservableCollection<T>: VirtualCollection<T>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        private ObservableCollection<T> primary;
        public VirtualObservableCollection()
        {
            primary = new ObservableCollection<T>();
        }
        public VirtualObservableCollection(IEnumerable<T> items):base(items.ToList())
        {
            primary = new ObservableCollection<T>(items);
        }


        public event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add
            {
                ((INotifyCollectionChanged)primary).CollectionChanged += value;
            }

            remove
            {
                ((INotifyCollectionChanged)primary).CollectionChanged -= value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void ChangeProperty([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public override void Add(T item)
        {
            base.Add(item);
            this.primary.Add(item);
        }

        public override bool Remove(T item)
        {
            return primary.Remove(item) && base.Remove(item);
        }

        public override void Clear()
        {
            base.Clear();
            primary.Clear();
        }
    }
}
