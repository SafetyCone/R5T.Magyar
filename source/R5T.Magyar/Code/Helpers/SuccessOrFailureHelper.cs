using System;


namespace R5T.Magyar
{
    public static class SuccessOrFailureHelper
    {
        public static class StandardRepresentation
        {
            public const string Failure = "Failure";
            public const string Success = "Success";
        }


        public static SuccessOrFailure FromStandardRepresentation(string standardRepresentation)
        {
            switch (standardRepresentation)
            {
                case SuccessOrFailureHelper.StandardRepresentation.Failure:
                    return SuccessOrFailure.Failure;

                case SuccessOrFailureHelper.StandardRepresentation.Success:
                    return SuccessOrFailure.Success;

                default:
                    throw EnumerationHelper.RepresentationUnrecognizedException<ApprovalStatus>(standardRepresentation);
            }
        }

        public static bool ToBoolean(this SuccessOrFailure successOrFailure)
        {
            switch (successOrFailure)
            {
                case SuccessOrFailure.Failure:
                    return false;

                case SuccessOrFailure.Success:
                    return true;

                default:
                    throw EnumerationHelper.SwitchDefaultCaseException(successOrFailure);
            }
        }

        public static string ToStandardRepresentation(SuccessOrFailure successOrFailure)
        {
            switch (successOrFailure)
            {
                case SuccessOrFailure.Failure:
                    return SuccessOrFailureHelper.StandardRepresentation.Failure;

                case SuccessOrFailure.Success:
                    return SuccessOrFailureHelper.StandardRepresentation.Success;

                default:
                    throw EnumerationHelper.SwitchDefaultCaseException(successOrFailure);
            }
        }
    }
}
