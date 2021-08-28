using System;


namespace R5T.Magyar
{
    public static class ApprovalStatusHelper
    {
        public static class StandardRepresentation
        {
            public const string Approved = "Approved";
            public const string Denied = "Denied";
            public const string Pending = "Pending";
        }


        public static string ToStandardRepresentation(ApprovalStatus approvalStatus)
        {
            switch(approvalStatus)
            {
                case ApprovalStatus.Approved:
                    return ApprovalStatusHelper.StandardRepresentation.Approved;

                case ApprovalStatus.Denied:
                    return ApprovalStatusHelper.StandardRepresentation.Denied;

                case ApprovalStatus.Pending:
                    return ApprovalStatusHelper.StandardRepresentation.Pending;

                default:
                    throw EnumerationHelper.SwitchDefaultCaseException(approvalStatus);
            }
        }

        public static ApprovalStatus FromStandardRepresentation(string approvalStatusStandardRepresenation)
        {
            switch(approvalStatusStandardRepresenation)
            {
                case ApprovalStatusHelper.StandardRepresentation.Approved:
                    return ApprovalStatus.Approved;

                case ApprovalStatusHelper.StandardRepresentation.Denied:
                    return ApprovalStatus.Denied;

                case ApprovalStatusHelper.StandardRepresentation.Pending:
                    return ApprovalStatus.Pending;

                default:
                    throw EnumerationHelper.RepresentationUnrecognizedException<ApprovalStatus>(approvalStatusStandardRepresenation);
            }
        }


        public static string GetApprovalWasStillPendingExceptionMessage()
        {
            var message = $"Approval status was still pending. Approval status must be '{ApprovalStatus.Approved}' or '{ApprovalStatus.Denied}'.";
            return message;
        }

        public static ArgumentException GetApprovalWasStillPendingException(string argumentName = Strings.Empty)
        {
            var message = ApprovalStatusHelper.GetApprovalWasStillPendingExceptionMessage();

            var argumentNameIsNotEmpty = StringHelper.IsNotEmpty(argumentName);

            var exception = argumentNameIsNotEmpty
                ? new ArgumentException(message, argumentName)
                : new ArgumentException(message);

            return exception;
        }
    }
}
