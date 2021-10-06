using System;

using R5T.Magyar.Extensions;


namespace R5T.Magyar
{
    public static class GuidHelper
    {
        public const string NoValueString = "<no value>";


        public static Guid GetNewGuid()
        {
            var guid = Guid.NewGuid();
            return guid;
        }

        /// <summary>
        /// Uses the <see cref="GuidExtensions.ToStringStandard(Guid)"/> functionality.
        /// </summary>
        public static string GetNewGuidString()
        {
            var guid = Guid.NewGuid();

            var standardRepresentation = guid.ToStringStandard();
            return standardRepresentation;
        }

        // Source: https://stackoverflow.com/a/13188409/10658484
        public static Guid GetNewSeededGuid(int seed = SeedHelper.DefaultSeed)
        {
            var random = new Random(seed);

            var guidBytes = new byte[16];

            random.NextBytes(guidBytes);

            var output = new Guid(guidBytes);
            return output;
        }
    }
}
