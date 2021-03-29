using System;


namespace R5T.Magyar
{
    public static class UriHelper
    {
        /// <summary>
        /// Uses the <see cref="UriHelper.NewBetterDefaults"/> method.
        /// </summary>
        public static UriBuilder New()
        {
            var output = UriHelper.NewBetterDefaults();
            return output;
        }

        /// <summary>
        /// Uses the <see cref="UriHelper.NewBetterDefaults"/> methods to set better default values than <see cref="UriBuilder"/> parameterless constructor.
        /// </summary>
        public static UriBuilder NewBetterDefaults()
        {
            // The parameterless constructor for the UriBuilder sets defaults as specified by: https://docs.microsoft.com/en-us/dotnet/api/system.uribuilder.-ctor?view=netcore-2.2
            var uriBuilder = new UriBuilder
            {
                Host = String.Empty,
                Scheme = String.Empty,
            };

            return uriBuilder;
        }

        public static UriBuilder NewHTTPS(string server)
        {
            var httpsSchemeName = UriScheme.HTTPS.ToName();

            var uriBuilder = UriHelper.New();

            uriBuilder.Scheme = httpsSchemeName;

            uriBuilder.SetServer(server);
            
            return uriBuilder;
        }

        public static UriBuilder NewRelative()
        {
            var uriBuilder = UriHelper.NewBetterDefaults();
            return uriBuilder;
        }
    }
}
