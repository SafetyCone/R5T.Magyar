using System;


namespace R5T.Magyar.Results
{
    /// <summary>
    /// Represents the result of a function (an operation where there is an output value).
    /// </summary>
    /// <typeparam name="T">The type of the output of the function which has this result.</typeparam>
    public class FunctionResult<T> : IHasOperationResult
    {
        #region Static

        public static implicit operator T(FunctionResult<T> result)
        {
            return result.Value;
        }

        #endregion


        public OperationResult Result { get; }
        public T Value { get; }
        public string Message { get; }


        public FunctionResult(T value, OperationResult result, string message)
        {
            this.Value = value;
            this.Result = result;
            this.Message = message;
        }

        public FunctionResult(T value, OperationResult result)
            : this(value, result, String.Empty)
        {
        }

        public override string ToString()
        {
            var successRepresentation = this.Result.ToStringRepresentation();

            var messageRepresentation = this.Message == String.Empty
                ? String.Empty
                : $": {this.Message}"
                ;

            var representation = $"{successRepresentation}: {messageRepresentation}";
            return representation;
        }
    }


    public static class FunctionResult
    {
        public static FunctionResult<T> Success<T>(T value)
        {
            var output = new FunctionResult<T>(value, OperationResult.Success);
            return output;
        }

        public static FunctionResult<T> Success<T>(T value, string message)
        {
            var output = new FunctionResult<T>(value, OperationResult.Success, message);
            return output;
        }

        public static FunctionResult<T> Failure<T>()
        {
            var output = new FunctionResult<T>(default, OperationResult.Failure, String.Empty);
            return output;
        }

        public static FunctionResult<T> Failure<T>(string message)
        {
            var output = new FunctionResult<T>(default, OperationResult.Failure, message);
            return output;
        }

        public static FunctionResult<T> Failure<T>(T value, string message)
        {
            var output = new FunctionResult<T>(value, OperationResult.Failure, message);
            return output;
        }

        // There is no parameterless warning: if it's a warning (ambiguous as to success or failure), it a message is needed explaining why.

        public static FunctionResult<T> Warning<T>(string message)
        {
            var output = new FunctionResult<T>(default, OperationResult.Warning, message);
            return output;
        }

        public static FunctionResult<T> Warning<T>(T value, string message)
        {
            var output = new FunctionResult<T>(value, OperationResult.Warning, message);
            return output;
        }
    }
}
