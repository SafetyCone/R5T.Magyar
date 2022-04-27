using System;
using System.Collections.Generic;
using System.Linq;

using R5T.Magyar.Results;


namespace System
{
    public static class IHasOperationResultExtensions
    {
        public static OperationResult GetAggregateResult(this IEnumerable<IHasOperationResult> results)
        {
            var output = results
                .Select(x => x.Result)
                .GetAggregateResult();

            return output;
        }

        public static bool AnyFailed(this IEnumerable<IHasOperationResult> results)
        {
            var output = results
                .Where(x => x.Failed())
                .Any();

            return output;
        }

        /// <summary>
        /// <inheritdoc cref="OperationResultExtensions.Failed(OperationResult)"/>
        /// </summary>
        public static bool Failed(this IHasOperationResult result)
        {
            var output = result.Result.Failed();
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="OperationResultExtensions.Failed_OrWarning(OperationResult)"/>
        /// </summary>
        public static bool Failed_OrWarning(this IHasOperationResult result)
        {
            var output = result.Result.Failed_OrWarning();
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="OperationResultExtensions.Succeeded_Strict(OperationResult)"/>
        /// </summary>
        public static bool Succeeded_Strict(this IHasOperationResult result)
        {
            var output = result.Result.Succeeded_Strict();
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="OperationResultExtensions.Succeeded_SuccessOrWarning(OperationResult)"/>
        /// </summary>
        public static bool Succeeded_SuccessOrWarning(this IHasOperationResult result)
        {
            var output = result.Result.Succeeded_SuccessOrWarning();
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Succeeded_SuccessOrWarning(IHasOperationResult)"/> as the default.
        /// </summary>
        public static bool Succeeded(this IHasOperationResult result)
        {
            var output = result.Succeeded_SuccessOrWarning();
            return output;
        }
    }
}
