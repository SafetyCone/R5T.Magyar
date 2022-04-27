using System;

using R5T.Magyar;


namespace System.Collections.Generic
{
    using N8;


    public class DistinctList<T> : ListBase<T>, IDistinctList<T>
    {
        protected readonly HashSet<T> zHash;


        private DistinctList(
            List<T> list,
            HashSet<T> hash)
            : base(list)
        {
            this.zHash = hash;
        }

        public DistinctList()
            : this(new List<T>(), new HashSet<T>())
        {
        }

        public DistinctList(IEnumerable<T> enumerable)
            : this()
        {
            this.AddRange(enumerable);
        }

        public DistinctList(IEqualityComparer<T> equalityComparer)
            : this(new List<T>(), new HashSet<T>(equalityComparer))
        {
        }

        public DistinctList(IEnumerable<T> enumerable, IEqualityComparer<T> equalityComparer)
            : this(equalityComparer)
        {
            this.AddRange(enumerable);
        }

        public override void Add(T item)
        {
            var alreadyExists = this.zHash.Contains(item);
            if(alreadyExists)
            {
                throw this.zHash.GetValueAlreadyExistsException();
            }

            base.Add(item);
        }

        public void AddRange(IEnumerable<T> enumerable)
        {
            this.zHash.AddRangeThrowIfDuplicate(enumerable);

            this.zList.AddRange(enumerable);
        }
    }
}
