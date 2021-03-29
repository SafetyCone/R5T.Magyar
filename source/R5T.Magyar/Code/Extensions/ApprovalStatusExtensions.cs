using System;


namespace R5T.Magyar
{
    public static class ApprovalStatusExtensions
    {
        public static T ChooseByDecision<T>(this ApprovalStatus status,
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

        public static T ChooseByDecision<T>(this ApprovalStatus status,
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
        /// Ensures an <see cref="ApprovalStatus"/> is not <see cref="ApprovalStatus.Pending"/>.
        /// </summary>
        public static void EnsureIsNotPending(this ApprovalStatus status)
        {
            var isPending = status.IsPending();
            if(isPending)
            {
                status.ThrowWasStillPendingException();
            }
        }

        /// <summary>
        /// Ensures an <see cref="ApprovalStatus"/> has been decided (and is not still <see cref="ApprovalStatus.Pending"/>).
        /// </summary>
        /// <remarks>
        /// Uses <see cref="ApprovalStatusExtensions.EnsureIsNotPending(ApprovalStatus)"/>.
        /// </remarks>
        public static void EnsureIsDecided(this ApprovalStatus status)
        {
            status.EnsureIsNotPending();
        }

        public static bool IsApproved(this ApprovalStatus status)
        {
            var isApproved = status == ApprovalStatus.Approved;
            return isApproved;
        }

        public static bool IsDecided(this ApprovalStatus status)
        {
            var isDecided = !status.IsPending();
            return isDecided;
        }

        public static bool IsDenied(this ApprovalStatus status)
        {
            var isDenied = status == ApprovalStatus.Denied;
            return isDenied;
        }

        public static T Switch<T>(this ApprovalStatus approvalStatus, T approved, T denied, T pending)
        {
            switch (approvalStatus)
            {
                case ApprovalStatus.Approved:
                    return approved;

                case ApprovalStatus.Denied:
                    return denied;

                case ApprovalStatus.Pending:
                    return pending;

                default:
                    throw EnumerationHelper.SwitchDefaultCaseException(approvalStatus);
            }
        }

        public static bool IsPending(this ApprovalStatus status)
        {
            var isPending = status == ApprovalStatus.Pending;
            return isPending;
        }

        public static void ThrowWasStillPendingException(this ApprovalStatus status)
        {
            throw ApprovalStatusHelper.GetApprovalWasStillPendingException();
        }

        public static string ToStringStandard(this ApprovalStatus status)
        {
            var standardRepresentation = ApprovalStatusHelper.ToStandardRepresentation(status);
            return standardRepresentation;
        }
    }
}


namespace R5T.Magyar.Extensions
{
    public static class ApprovalStatusExtensions
    {
        public static ApprovalStatus ToApprovalStatus(this string standardRepresentation)
        {
            var status = ApprovalStatusHelper.FromStandardRepresentation(standardRepresentation);
            return status;
        }
    }
}
