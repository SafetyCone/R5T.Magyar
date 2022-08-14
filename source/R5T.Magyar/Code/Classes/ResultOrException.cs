using System;


namespace R5T.Magyar
{
    public class ResultOrException<T> : IEquatable<ResultOrException<T>>
    {
        #region Static

        public static implicit operator ResultOrException<T>(T result)
        {
            var output = ResultOrException.From(result);
            return output;
        }

        public static implicit operator ResultOrException<T>(Exception exception)
        {
            var output = ResultOrException.From<T>(exception);
            return output;
        }

        public static implicit operator T(ResultOrException<T> wasFound)
        {
            return wasFound.Result;
        }

        #endregion


        public Exception Exception { get; private set; }
        public bool HasResult { get; private set; }
        public T Result { get; private set; }

        public bool HasException
        {
            get
            {
                var output = this.Exception != null;
                return output;
            }
        }


        public ResultOrException(T result, bool hasResult, Exception exception)
        {
            this.Result = result;
            this.HasResult = hasResult;
            this.Exception = exception;
        }

        public ResultOrException(T result)
            : this(result, true, default)
        {
        }

        public ResultOrException(Exception exception)
            : this(default, false, exception)
        {
        }

        public override string ToString()
        {
            var hasException = this.HasException;

            var representation = hasException
                ? $"\n\t{this.Exception.Message}\n\tResult: {this.Result}"
                : this.Result.ToString()
                ;

            return representation;
        }

        public bool Equals(ResultOrException<T> other)
        {
            var output = true
                && this.HasResult == other.HasResult
                && this.Result.Equals(other.Result)
                && this.Exception == other.Exception
                ;

            return output;
        }
    }


    public static class ResultOrException
    {
        public static ResultOrException<T> From<T>(T result)
        {
            var output = new ResultOrException<T>(result);
            return output;
        }

        public static ResultOrException<T> From<T>(Exception exception)
        {
            var output = new ResultOrException<T>(exception);
            return output;
        }

        public static ResultOrException<T> Try<T>(Func<T> resultConstructor)
        {
            ResultOrException<T> output;

            try
            {
                var result = resultConstructor();

                output = ResultOrException.From(result);
            }
            catch (Exception exception)
            {
                output = ResultOrException.From<T>(exception);
            }

            return output;
        }
    }
}
