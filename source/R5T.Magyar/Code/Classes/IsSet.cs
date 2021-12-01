using System;


namespace R5T.Magyar
{
    public static class IsSet
    {
        public static IsSet<T> Set<T>(T value)
        {
            var output = new IsSet<T>(true, value);
            return output;
        }

        public static IsSet<T> NotSet<T>(T value)
        {
            var output = new IsSet<T>(false, value);
            return output;
        }

        public static IsSet<T> NotSet<T>()
        {
            var output = IsSet.NotSet<T>(default);
            return output;
        }
    }


    public struct IsSet<T>
    {
        #region Static

        public static implicit operator IsSet<T>(T value)
        {
            var output = new IsSet<T>(true, value);
            return output;
        }

        public static implicit operator bool(IsSet<T> isSet)
        {
            return isSet.Set;
        }

        public static implicit operator T(IsSet<T> isSet)
        {
            return isSet.Value;
        }

        #endregion


        public bool Set { get; }
        public T Value { get; }


        public IsSet(bool set, T value)
        {
            this.Set = set;
            this.Value = value;
        }
    }
}
