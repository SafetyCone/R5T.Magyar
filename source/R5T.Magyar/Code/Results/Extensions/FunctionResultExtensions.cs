using System;

using R5T.Magyar.Results;


namespace System
{
    public static class FunctionResultExtensions
    {
        public static ActionResult GetActionResult<T>(this FunctionResult<T> functionResult)
        {
            var output = new ActionResult(
                functionResult.Result,
                functionResult.Message);

            return output;
        }

    }
}
