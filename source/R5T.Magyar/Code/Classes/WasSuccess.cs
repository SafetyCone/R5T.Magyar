using System;


namespace R5T.Magyar
{
    public class WasSuccess
    {
        #region Static

        public static WasSuccess<T> From<T>(
            T value,
            bool success,
            string failureMessage = default)
        {
            var output = new WasSuccess<T>(
                success,
                value,
                failureMessage);

            return output;
        }

        public static WasSuccess<T> From<T>(
            T value,
            WasSuccess wasSuccess)
        {
            var output = new WasSuccess<T>(
                wasSuccess.Success,
                value,
                wasSuccess.FailureMessage);

            return output;
        }

        public static WasSuccess<T> Successful<T>(T value)
        {
            var output = new WasSuccess<T>(true, value);
            return output;
        }

        public static WasSuccess<T> Failure<T>(string reason, T value = default)
        {
            var output = new WasSuccess<T>(false, value, reason);
            return output;
        }

        public static WasSuccess From(
            bool success,
            string failureMessage = default)
        {
            var output = new WasSuccess(
                success,
                failureMessage);

            return output;
        }

        public static WasSuccess Successful()
        {
            var output = new WasSuccess(true);
            return output;
        }

        public static WasSuccess Failure(string reason)
        {
            var output = new WasSuccess(false, reason);
            return output;
        }

        public static implicit operator bool(WasSuccess isSuccess)
        {
            return isSuccess.Success;
        }

        #endregion


        public bool Success { get; }
        public string FailureMessage { get; }


        public WasSuccess(
            bool success,
            string failureMessage = default)
        {
            this.Success = success;
            this.FailureMessage = failureMessage;
        }
    }


    public class WasSuccess<T>
    {
        #region Static

        public static implicit operator bool(WasSuccess<T> isSuccess)
        {
            return isSuccess.Success;
        }

        #endregion


        public bool Success { get; }
        public T Result { get; }
        public string FailureMessage { get; }


        public WasSuccess(
            bool success,
            T value = default,
            string failureMessage = default)
        {
            this.Result = value;
            this.Success = success;
            this.FailureMessage = failureMessage;
        }
    }


    public static class WasSuccessExtensions
    {
        
    }
}
