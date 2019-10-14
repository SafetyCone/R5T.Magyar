using System;


namespace R5T.Magyar.Extensions
{
    public static class GuidExtensions
    {
        /// <summary>
        /// The standard string representation of a GUID.
        /// Uses <see cref="GuidExtensions.ToStringUppercase(Guid)"/>.
        /// </summary>
        /// <remarks>
        /// See the discussion of formats here: https://docs.microsoft.com/en-us/dotnet/api/system.guid.tostring?view=netcore-2.2.
        /// </remarks>
        public static string ToStringStandard(this Guid guid)
        {
            var representation = guid.ToStringUppercase();
            return representation;
        }

        /// <summary>
        /// Returns a GUID in uppercase format.
        /// Example: 382C74C3-721D-4F34-80E5-57657B6CBC27.
        /// </summary>
        public static string ToStringUppercase(this Guid guid)
        {
            var representation = guid.ToString("D").ToUpperInvariant();
            return representation;
        }

        /// <summary>
        /// Returns a GUID in uppercase format, bracketed.
        /// Example: {382C74C3-721D-4F34-80E5-57657B6CBC27}.
        /// </summary>
        public static string ToStringUppercaseBracketed(this Guid guid)
        {
            var representation = guid.ToString("B").ToUpperInvariant();
            return representation;
        }
    }
}
