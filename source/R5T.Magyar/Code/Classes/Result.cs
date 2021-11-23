using System;
using System.Linq;


namespace R5T.Magyar
{
    public class Result<T>
    {
        #region Static

        public static implicit operator bool(Result<T> wasFound)
        {
            return wasFound.Success;
        }

        public static implicit operator T(Result<T> wasFound)
        {
            return wasFound.Value;
        }

        #endregion

        public bool Success { get; }
        public T Value { get; }
        public string[] ErrorMessages { get; }
        public string[] OutputMessages { get; }


        public Result(T value, bool success, string[] errorMessages, string[] outputMessages)
        {
            this.Value = value;
            this.Success = success;
            this.ErrorMessages = errorMessages;
            this.OutputMessages = outputMessages;
        }

        public Result(T value, bool success)
            : this(value, success, Array.Empty<string>(), Array.Empty<string>())
        {
        }

        public override string ToString()
        {
            var successRepresentation = this.Success
                ? "Success"
                : "Failure"
                ;

            var errorMessagesIndicator = this.ErrorMessages.Any()
                ? " (see error messages)"
                : String.Empty
                ;

            var outputMessagesIndicator = this.OutputMessages.Any()
                ? " (see output messages)"
                : String.Empty
                ;

            var representation = $"{successRepresentation}{errorMessagesIndicator}{outputMessagesIndicator}, {this.Value}";
            return representation;
        }
    }


    public static class Result
    {
        public static Result<T> Success<T>(T value)
        {
            var output = new Result<T>(value, true);
            return output;
        }

        public static Result<T> Success<T>(T value, string[] outputMessages)
        {
            var output = new Result<T>(value, true, Array.Empty<string>(), outputMessages);
            return output;
        }

        public static Result<T> Failure<T>(T value)
        {
            var output = new Result<T>(value, true);
            return output;
        }
    }
}
