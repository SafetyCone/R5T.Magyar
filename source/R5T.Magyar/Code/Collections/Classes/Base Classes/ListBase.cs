using System;
using System.Collections;
using System.Collections.Generic;


namespace R5T.Magyar
{
    public abstract class ListBase<T> : IList<T>
    {
        protected readonly List<T> zList;
        public T this[int index]
        {
            get => this.zList[index];
            set => this.zList[index] = value;
        }
        public int Count => this.zList.Count;
        public bool IsReadOnly => (this.zList as IList<T>).IsReadOnly;


        private ListBase(List<T> list)
        {
            this.zList = list;
        }

        public ListBase()
            : this(new List<T>())
        {
        }

        public ListBase(IEnumerable<T> enumerable)
            : this(new List<T>(enumerable))
        {
        }

        public ListBase(int capacity)
            : this(new List<T>(capacity))
        {
        }

        public virtual void Add(T item)
        {
            this.zList.Add(item);
        }

        public virtual void Clear()
        {
            this.zList.Clear();
        }

        public virtual bool Contains(T item)
        {
            var output = this.zList.Contains(item);
            return output;
        }

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            this.zList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.zList.GetEnumerator();
        }

        public virtual int IndexOf(T item)
        {
            var output = this.zList.IndexOf(item);
            return output;
        }

        public virtual void Insert(int index, T item)
        {
            this.zList.Insert(index, item);
        }

        public virtual bool Remove(T item)
        {
            var output = this.zList.Remove(item);
            return output;
        }

        public virtual void RemoveAt(int index)
        {
            this.zList.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.zList.GetEnumerator();
        }
    }
}
