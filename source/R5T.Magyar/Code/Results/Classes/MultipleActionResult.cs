using System;
using System.Collections.Generic;
using System.Linq;


namespace R5T.Magyar.Results
{
    public class MultipleActionResult : IHasOperationResult
    {
        #region Static

        public static MultipleActionResult From(params ActionResult[] actionResults)
        {
            var output = new MultipleActionResult(actionResults);
            return output;
        }

        public static MultipleActionResult From(IEnumerable<ActionResult> actionResults)
        {
            var actionResultsArray = actionResults.Now();

            var output = MultipleActionResult.From(actionResultsArray);
            return output;
        }

        public static MultipleActionResult From(MultipleActionResult multipleActionResult, params ActionResult[] actionResults)
        {
            var actionResultsEnumeration = multipleActionResult.ActionResults
                .Concat(actionResults)
                ;

            var output = MultipleActionResult.From(actionResultsEnumeration);
            return output;
        }

        public static MultipleActionResult From(MultipleActionResult multipleActionResult, IEnumerable<ActionResult> actionResults)
        {
            var actionResultsEnumeration = multipleActionResult.ActionResults
                .Concat(actionResults)
                ;

            var output = MultipleActionResult.From(actionResultsEnumeration);
            return output;
        }

        public static MultipleActionResult From(IEnumerable<MultipleActionResult> multipleActionResults)
        {
            var actionResultsEnumeration = multipleActionResults
                .SelectMany(x => x.ActionResults)
                ;

            var output = MultipleActionResult.From(actionResultsEnumeration);
            return output;
        }

        public static MultipleActionResult From(params MultipleActionResult[] multipleActionResults)
        {
            var actionResultsEnumeration = multipleActionResults
                .SelectMany(x => x.ActionResults)
                ;

            var output = MultipleActionResult.From(actionResultsEnumeration);
            return output;
        }

        public static MultipleActionResult From_UnsuccessfulOnlyOrSingleSuccess(params MultipleActionResult[] multipleActionResults)
        {
            var actionResults = multipleActionResults
                .SelectMany(x => x.ActionResults)
                ;

            var output = MultipleActionResult.From_UnsuccessfulOnlyOrSingleSuccess(actionResults);
            return output;
        }

        public static MultipleActionResult From_UnsuccessfulOnlyOrSingleSuccess(IEnumerable<ActionResult> actionResults)
        {
            var actionResultsArray = actionResults.Now();

            var output = MultipleActionResult.From_UnsuccessfulOnlyOrSingleSuccess(actionResultsArray);
            return output;
        }

        public static MultipleActionResult From_UnsuccessfulOnlyOrSingleSuccess(params ActionResult[] actionResults)
        {
            var unsuccessful = actionResults
                .Where(x => x.Result.Unsuccessful())
                .Now();

            var anyUnsuccessful = unsuccessful.Any();

            var output = anyUnsuccessful
                ? MultipleActionResult.From(unsuccessful)
                : MultipleActionResult.Success()
                ;

            return output;
        }

        public static MultipleActionResult Success()
        {
            var output = new MultipleActionResult(
                ActionResult.Success());

            return output;
        }

        #endregion


        public ActionResult[] ActionResults { get; }
        public OperationResult Result
        {
            get
            {
                var output = this.ActionResults.GetAggregateResult();
                return output;
            }
        }

        public MultipleActionResult(params ActionResult[] actionResults)
        {
            this.ActionResults = actionResults;
        }

        public MultipleActionResult(IEnumerable<ActionResult> actionResults)
            : this(actionResults.Now())
        {
        }
    }
}
