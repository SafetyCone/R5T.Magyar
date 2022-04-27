using System;


namespace R5T.Magyar.Results
{
    /// <summary>
    /// Represents the result of an action (an operation where there is no output value).
    /// </summary>
    public class ActionResult : IHasOperationResult
    {
        #region Static

        public static ActionResult Success()
        {
            var output = new ActionResult(OperationResult.Success);
            return output;
        }

        public static ActionResult Success(string message)
        {
            var output = new ActionResult(OperationResult.Success, message);
            return output;
        }

        public static ActionResult Failure()
        {
            var output = new ActionResult(OperationResult.Failure);
            return output;
        }

        public static ActionResult Failure(string message)
        {
            var output = new ActionResult(OperationResult.Failure, message);
            return output;
        }

        // There is no parameterless warning: if it's a warning (ambiguous as to success or failure), it a message is needed explaining why.

        public static ActionResult Warning(string message)
        {
            var output = new ActionResult(OperationResult.Warning, message);
            return output;
        }

        #endregion


        public OperationResult Result { get; }
        public string Message { get; }


        public ActionResult(OperationResult result, string message)
        {
            this.Result = result;
            this.Message = message;
        }

        public ActionResult(OperationResult result)
            : this(result, String.Empty)
        {
        }

        public override string ToString()
        {
            var successRepresentation = this.Result.ToStringRepresentation();

            var messageRepresentation = this.Message == String.Empty
                ? "< No message. >"
                : $"{this.Message}"
                ;

            var representation = $"{successRepresentation}: {messageRepresentation}";
            return representation;
        }
    }
}
