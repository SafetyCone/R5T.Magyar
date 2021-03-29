using System;


namespace R5T.Magyar
{
    public static class SuccessOrFailureExtensions
    {
        public static bool ToBoolean(this SuccessOrFailure successOrFailure)
        {
            var output = SuccessOrFailureHelper.ToBoolean(successOrFailure);
            return output;
        }

        public static string ToStringStandard(this SuccessOrFailure successOrFailure)
        {
            var output = SuccessOrFailureHelper.ToStandardRepresentation(successOrFailure);
            return output;
        }
    }
}


namespace R5T.Magyar.Extensions
{
    public static class SuccessOrFailureExtensions
    {
        public static SuccessOrFailure ToSuccessOrFailure(this string standardRepresentation)
        {
            var successOrFailure = SuccessOrFailureHelper.FromStandardRepresentation(standardRepresentation);
            return successOrFailure;
        }
    }
}
