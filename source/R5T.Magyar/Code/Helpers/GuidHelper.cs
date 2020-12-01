using System;

using R5T.Magyar.Extensions;


namespace R5T.Magyar
{
    public static class GuidHelper
    {
        public const string NoValueString = "<no value>";


        /// <summary>
        /// Uses the <see cref="GuidExtensions.ToStringStandard(Guid)"/> functionality.
        /// </summary>
        public static string GetNewGuidString()
        {
            var guid = Guid.NewGuid();

            var standardRepresentation = guid.ToStringStandard();
            return standardRepresentation;
        }
    }
}
