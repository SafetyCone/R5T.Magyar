using System;


namespace R5T.Magyar
{
    public static class UriHelper
    {
        public static UriBuilder NewHTTPS(string hostName)
        {
            var httpsSchemeName = UriScheme.HTTPS.ToName();

            var uriBuilder = new UriBuilder(httpsSchemeName, hostName);
            return uriBuilder;
        }
    }
}
