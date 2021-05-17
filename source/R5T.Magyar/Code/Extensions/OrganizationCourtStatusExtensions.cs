using System;


namespace R5T.Magyar
{
    public static class OrganizationCourtStatusExtensions
    {
        public static T ChooseByDecision<T>(this OrganizationCourtStatus status,
            T approved,
            T denied)
        {
            status.EnsureIsDecided();

            if(status.IsApproved())
            {
                return approved;
            }
            else
            {
                return denied;
            }
        }

        public static T ChooseByDecision<T>(this OrganizationCourtStatus status,
            Func<T> approved,
            Func<T> denied)
        {
            status.EnsureIsDecided();

            if (status.IsApproved())
            {
                var approvedValue = approved();
                return approvedValue;
            }
            else
            {
                var deniedValue = denied();
                return deniedValue;
            }
        }

        /// <summary>
        /// Ensures an <see cref="OrganizationCourtStatus"/> is not <see cref="OrganizationCourtStatus.Pending"/>.
        /// </summary>
        public static void EnsureIsNotPending(this OrganizationCourtStatus status)
        {
            var isPending = status.IsPending();
            if(isPending)
            {
                status.ThrowWasStillPendingException();
            }
        }

        /// <summary>
        /// Ensures an <see cref="OrganizationCourtStatus"/> has been decided (and is not still <see cref="OrganizationCourtStatus.Pending"/>).
        /// </summary>
        /// <remarks>
        /// Uses <see cref="OrganizationCourtStatusExtensions.EnsureIsNotPending(OrganizationCourtStatus)"/>.
        /// </remarks>
        public static void EnsureIsDecided(this OrganizationCourtStatus status)
        {
            status.EnsureIsNotPending();
        }

        public static bool IsApproved(this OrganizationCourtStatus status)
        {
            var isApproved = status == OrganizationCourtStatus.Approved;
            return isApproved;
        }

        public static bool IsDecided(this OrganizationCourtStatus status)
        {
            var isDecided = !status.IsPending();
            return isDecided;
        }

        public static bool IsDenied(this OrganizationCourtStatus status)
        {
            var isDenied = status == OrganizationCourtStatus.Denied || status == OrganizationCourtStatus.DeniedWithReroute;
            return isDenied;
        }

        public static T Switch<T>(this OrganizationCourtStatus organizationCourtStatus, T approved, T denied, T pending)
        {
            switch (organizationCourtStatus)
            {
                case OrganizationCourtStatus.Approved:
                    return approved;

                case OrganizationCourtStatus.Denied:
                    return denied;

                case OrganizationCourtStatus.DeniedWithReroute:
                    return denied;

                case OrganizationCourtStatus.Pending:
                    return pending;

                default:
                    throw EnumerationHelper.SwitchDefaultCaseException(organizationCourtStatus);
            }
        }

        public static bool IsPending(this OrganizationCourtStatus status)
        {
            var isPending = status == OrganizationCourtStatus.Pending;
            return isPending;
        }

        public static void ThrowWasStillPendingException(this OrganizationCourtStatus status)
        {
            throw OrganizationCourtStatusHelper.GetApprovalWasStillPendingException();
        }

        public static string ToStringStandard(this OrganizationCourtStatus status)
        {
            var standardRepresentation = OrganizationCourtStatusHelper.ToStandardRepresentation(status);
            return standardRepresentation;
        }
    }
}


namespace R5T.Magyar.Extensions
{
    public static class OrganizationCourtStatusExtensions
    {
        public static OrganizationCourtStatus ToOrganizationCourtStatus(this string standardRepresentation)
        {
            var status = OrganizationCourtStatusHelper.FromStandardRepresentation(standardRepresentation);
            return status;
        }
    }
}
