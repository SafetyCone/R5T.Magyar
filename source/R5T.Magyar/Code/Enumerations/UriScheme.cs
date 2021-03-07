using System;


namespace R5T.Magyar
{
    // Good resource: https://www.iana.org/assignments/uri-schemes/uri-schemes.xhtml
    public enum UriScheme
    {
        FTP,
        Git,
        HTTP,
        HTTPS,
        MailTo,
        SFTP,
        Svn,
    }


    public static class UriSchemeExtensions
    {
        public static string ToName(this UriScheme uriScheme)
        {
            var tokensByUriScheme = UriSchemeNames.NamesByUriScheme.Value;

            var token = tokensByUriScheme[uriScheme];
            return token;
        }
    }
}
