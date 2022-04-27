using System;
using System.Collections.Generic;
using System.Linq;

using R5T.Magyar;
using R5T.Magyar.Results;


namespace System
{
    public static class OperationResultExtensions
    {
        public static OperationResult GetAggregateResult(this IEnumerable<OperationResult> results)
        {
            var foundWarning = false;

            foreach (var result in results)
            {
                var isFailure = result.IsFailure();
                if(isFailure)
                {
                    // Any failure creates a failure.
                    return OperationResult.Failure;
                }

                var isWarning = result.IsWarning();
                if(isWarning)
                {
                    foundWarning = true;
                }
            }

            if(foundWarning)
            {
                // As long as there were no failures, but a warning was found, it's a warning.
                return OperationResult.Warning;
            }

            // Else, if no failure or warning is found, it's a success.
            return OperationResult.Success;
        }

        public static bool AllSuccesses(this IEnumerable<OperationResult> results)
        {
            var anyNotSuccess = results
                .Where(x => x.Unsuccessful())
                .Any();

            var output = !anyNotSuccess;
            return output;
        }

        public static bool AnyFailures(this IEnumerable<OperationResult> results)
        {
            var output = results
                .Where(x => x.IsFailure())
                .Any();

            return output;
        }

        public static bool AnySuccesses(this IEnumerable<OperationResult> results)
        {
            var output = results
                .Where(x => x.IsSuccess())
                .Any();

            return output;
        }

        public static bool AnyWarnings(this IEnumerable<OperationResult> results)
        {
            var output = results
                .Where(x => x.IsWarning())
                .Any();

            return output;
        }

        /// <summary>
        /// Returns true if the result is <see cref="OperationResult.Failure"/>.
        /// </summary>
        public static bool Failed(this OperationResult result)
        {
            var output = result == OperationResult.Failure;
            return output;
        }

        /// <summary>
        /// Returns true if the result is <see cref="OperationResult.Failure"/> or <see cref="OperationResult.Warning"/>.
        /// </summary>
        public static bool Failed_OrWarning(this OperationResult result)
        {
            var output = false
                || result == OperationResult.Failure
                || result == OperationResult.Warning
                ;

            return output;
        }

        public static int GetIntegerValue(this OperationResult result)
        {
            switch (result)
            {
                case OperationResult.Failure:
                    return 100;

                case OperationResult.Warning:
                    return 10;

                case OperationResult.Success:
                    return 0;

                default:
                    throw EnumerationHelper.SwitchDefaultCaseException(result);
            }
        }

        public static bool IsFailure(this OperationResult result)
        {
            var output = result == OperationResult.Failure;
            return output;
        }

        public static bool IsSuccess(this OperationResult result)
        {
            var output = result == OperationResult.Success;
            return output;
        }

        public static bool IsWarning(this OperationResult result)
        {
            var output = result == OperationResult.Warning;
            return output;
        }

        public static bool Unsuccessful(this OperationResult result)
        {
            var output = result != OperationResult.Success;
            return output;
        }

        /// <summary>
        /// Returns true *only* if the result is <see cref="OperationResult.Success"/>.
        /// </summary>
        public static bool Succeeded_Strict(this OperationResult result)
        {
            var output = result == OperationResult.Success;
            return output;
        }

        /// <summary>
        /// Returns true if the result is <see cref="OperationResult.Success"/> or <see cref="OperationResult.Warning"/>.
        /// </summary>
        public static bool Succeeded_SuccessOrWarning(this OperationResult result)
        {
            var output = false
                || result == OperationResult.Success
                || result == OperationResult.Warning
                ;

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Succeeded_SuccessOrWarning(OperationResult)"/> as the default.
        /// </summary>
        public static bool Succeeded(this OperationResult result)
        {
            var output = result.Succeeded_SuccessOrWarning();
            return output;
        }

        public static string ToStringRepresentationStandard(this OperationResult result)
        {
            switch (result)
            {
                case OperationResult.Failure:
                    return "Failure";

                case OperationResult.Success:
                    return "Success";

                case OperationResult.Warning:
                    return "Warning";

                default:
                    throw EnumerationHelper.SwitchDefaultCaseException(result);
            }
        }

        /// <summary>
        /// Chooses <see cref="ToStringRepresentationStandard(OperationResult)"/> as the default.
        /// </summary>
        public static string ToStringRepresentation(this OperationResult result)
        {
            var output = result.ToStringRepresentationStandard();
            return output;
        }
    }
}
