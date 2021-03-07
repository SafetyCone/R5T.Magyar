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
    }
}
