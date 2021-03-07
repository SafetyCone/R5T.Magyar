using System;


namespace R5T.Magyar
{
    public static class UriBuilderExtensions
    {
        public static UriBuilder AddPath(this UriBuilder uriBuilder, string path)
        {
            uriBuilder.Path += path;

            return uriBuilder;
        }

        public static UriBuilder AddPathAndQuery(this UriBuilder uriBuilder, string pathAndQuery)
        {
            var tokens = pathAndQuery.Split(UriComponentTokenSeparators.Query);

            uriBuilder.Path = tokens[0];
            if (tokens.Length > 1)
            {
                uriBuilder.Query = tokens[1];
            }

            return uriBuilder;
        }

        public static Uri BuildUri(this UriBuilder uriBuilder)
        {
            var output = uriBuilder.Uri;
            return output;
        }

        public static string Build(this UriBuilder uriBuilder)
        {
            var uri = uriBuilder.BuildUri();

            var output = uri.ToString();
            return output;
        }

        /// <summary>
        /// Server can include both host and port.
        /// </summary>
        public static UriBuilder SetServer(this UriBuilder uriBuilder, string server)
        {
            var tokens = server.Split(UriComponentTokenSeparators.Port);

            uriBuilder.Host = tokens[0];
            if (tokens.Length > 1)
            {
                uriBuilder.Port = Int32.Parse(tokens[1]);
            }

            return uriBuilder;
        }
    }
}
