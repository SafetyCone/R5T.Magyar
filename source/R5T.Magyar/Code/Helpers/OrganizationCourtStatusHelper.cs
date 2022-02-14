using System;


namespace R5T.Magyar
{
    public static class OrganizationCourtStatusHelper
    {
        public static class StandardRepresentation
        {
            public const string Approved = "Approved";
            public const string Denied = "Denied";
            public const string DeniedWithReroute = "Denied with reroute";
            public const string Pending = "Pending";
        }


        public static string ToStandardRepresentation(OrganizationCourtStatus organizationCourtStatus)
        {
            switch(organizationCourtStatus)
            {
                case OrganizationCourtStatus.Approved:
                    return OrganizationCourtStatusHelper.StandardRepresentation.Approved;

                case OrganizationCourtStatus.Denied:
                    return OrganizationCourtStatusHelper.StandardRepresentation.Denied;

                case OrganizationCourtStatus.DeniedWithReroute:
                    return OrganizationCourtStatusHelper.StandardRepresentation.DeniedWithReroute;

                case OrganizationCourtStatus.Pending:
                    return OrganizationCourtStatusHelper.StandardRepresentation.Pending;

                default:
                    throw EnumerationHelper.SwitchDefaultCaseException(organizationCourtStatus);
            }
        }

        public static OrganizationCourtStatus FromStandardRepresentation(string organizationCourtStatusStandardRepresenation)
        {
            switch(organizationCourtStatusStandardRepresenation)
            {
                case OrganizationCourtStatusHelper.StandardRepresentation.Approved:
                    return OrganizationCourtStatus.Approved;

                case OrganizationCourtStatusHelper.StandardRepresentation.Denied:
                    return OrganizationCourtStatus.Denied;

                case OrganizationCourtStatusHelper.StandardRepresentation.DeniedWithReroute:
                    return OrganizationCourtStatus.DeniedWithReroute;

                case OrganizationCourtStatusHelper.StandardRepresentation.Pending:
                    return OrganizationCourtStatus.Pending;

                default:
                    throw EnumerationHelper.RepresentationUnrecognizedException<OrganizationCourtStatus>(organizationCourtStatusStandardRepresenation);
            }
        }


        public static string GetApprovalWasStillPendingExceptionMessage()
        {
            var message = $"Approval status was still pending. Approval status must be '{OrganizationCourtStatus.Approved}', '{OrganizationCourtStatus.Denied}', or '{OrganizationCourtStatus.DeniedWithReroute}.";
            return message;
        }

        public static ArgumentException GetApprovalWasStillPendingException(string argumentName = Strings.Empty_Const)
        {
            var message = OrganizationCourtStatusHelper.GetApprovalWasStillPendingExceptionMessage();

            var argumentNameIsNotEmpty = StringHelper.IsNotEmpty(argumentName);

            var exception = argumentNameIsNotEmpty
                ? new ArgumentException(message, argumentName)
                : new ArgumentException(message);

            return exception;
        }
    }
}
