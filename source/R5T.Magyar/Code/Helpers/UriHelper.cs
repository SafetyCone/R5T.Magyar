using System;


namespace R5T.Magyar
{
    public static class UriHelper
    {
        public static UriBuilder NewHTTPS(string server)
        {
            var httpsSchemeName = UriScheme.HTTPS.ToName();

            var uriBuilder = new UriBuilder
            {
                Scheme = httpsSchemeName
            };
            uriBuilder.SetServer(server);
            
            return uriBuilder;
        }
    }
}
