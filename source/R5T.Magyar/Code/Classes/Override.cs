using System;


namespace R5T.Magyar
{
    public static class Override
    {
        public static Override<T> Overridden<T>(T value)
        {
            var output = new Override<T>(true, value);
            return output;
        }

        public static Override<T> NotOverridden<T>(T value)
        {
            var output = new Override<T>(false, value);
            return output;
        }

        public static Override<T> NotOverridden<T>()
        {
            var output = Override.NotOverridden<T>(default);
            return output;
        }
    }


    public class Override<T>
    {
        #region Static

        public static implicit operator Override<T>(T value)
        {
            var output = new Override<T>(true, value);
            return output;
        }

        public static implicit operator bool(Override<T> isSet)
        {
            return isSet.IsOverridden;
        }

        public static implicit operator T(Override<T> isSet)
        {
            return isSet.Value;
        }

        #endregion


        public bool IsOverridden { get; private set; }
        public T Value { get; private set; }


        public Override(bool set, T value)
        {
            this.IsOverridden = set;
            this.Value = value;
        }

        public void SetOverride(T value)
        {
            this.Value = value;

            this.IsOverridden = true;
        }
    }
}
