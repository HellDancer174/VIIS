using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElegantLib.Collections
{
    public class VirtualCollection<T>: IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection, IReadOnlyList<T>, IReadOnlyCollection<T>
    {
        private List<T> primary;
        public VirtualCollection():this(new List<T>())
        {
        }
        public VirtualCollection(int capasity): this(new List<T>(capasity))
        {
        }
        public VirtualCollection(IList<T> list)
        {
            primary = new List<T>(list);
        }

        public virtual T this[int index] { get => ((IList<T>)primary)[index]; set => ((IList<T>)primary)[index] = value; }
        object IList.this[int index] { get => ((IList)primary)[index]; set => ((IList)primary)[index] = value; }

        public virtual int Count => ((IList<T>)primary).Count;

        public virtual bool IsReadOnly => ((IList<T>)primary).IsReadOnly;

        public virtual bool IsFixedSize => ((IList)primary).IsFixedSize;

        public virtual object SyncRoot => ((IList)primary).SyncRoot;

        public virtual bool IsSynchronized => ((IList)primary).IsSynchronized;

        public virtual void Add(T item)
        {
            ((IList<T>)primary).Add(item);
        }

        public virtual int Add(object value)
        {
            return ((IList)primary).Add(value);
        }

        public virtual void Clear()
        {
            ((IList<T>)primary).Clear();
        }

        public virtual bool Contains(T item)
        {
            return ((IList<T>)primary).Contains(item);
        }

        public virtual bool Contains(object value)
        {
            return ((IList)primary).Contains(value);
        }

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            ((IList<T>)primary).CopyTo(array, arrayIndex);
        }

        public virtual void CopyTo(Array array, int index)
        {
            ((IList)primary).CopyTo(array, index);
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return ((IList<T>)primary).GetEnumerator();
        }

        public virtual int IndexOf(T item)
        {
            return ((IList<T>)primary).IndexOf(item);
        }

        public virtual int IndexOf(object value)
        {
            return ((IList)primary).IndexOf(value);
        }

        public virtual void Insert(int index, T item)
        {
            ((IList<T>)primary).Insert(index, item);
        }

        public virtual void Insert(int index, object value)
        {
            ((IList)primary).Insert(index, value);
        }

        public virtual bool Remove(T item)
        {
            return ((IList<T>)primary).Remove(item);
        }

        public virtual void Remove(object value)
        {
            ((IList)primary).Remove(value);
        }

        public virtual void RemoveAt(int index)
        {
            ((IList<T>)primary).RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<T>)primary).GetEnumerator();
        }

        public virtual void Sort()
        {
            primary.Sort();
        }
    }
}
