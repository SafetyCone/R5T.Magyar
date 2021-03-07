using System;
using System.Collections.Generic;


namespace R5T.Magyar
{
    public static class UriSchemeNames
    {
        public const string FTP = "ftp";
        public const string Git = "git";
        public const string HTTP = "http";
        public const string HTTPS = "https";
        public const string MailTo = "mailto";
        public const string SFTP = "sftp";
        public const string Svn = "svn";


        #region Static

        public static Lazy<Dictionary<UriScheme, string>> NamesByUriScheme = new Lazy<Dictionary<UriScheme, string>>(UriSchemeNames.GetNamesByUriScheme);
        public static Lazy<Dictionary<string, UriScheme>> UriSchemesByName = new Lazy<Dictionary<string, UriScheme>>(UriSchemeNames.GetUriNamesByToken);


        public static Dictionary<UriScheme, string> GetNamesByUriScheme()
        {
            var output = new Dictionary<UriScheme, string>
            {
                { UriScheme.FTP, UriSchemeNames.FTP },
                { UriScheme.Git, UriSchemeNames.Git },
                { UriScheme.HTTP, UriSchemeNames.HTTP },
                { UriScheme.HTTPS, UriSchemeNames.HTTPS },
                { UriScheme.MailTo, UriSchemeNames.MailTo },
                { UriScheme.SFTP, UriSchemeNames.SFTP },
                { UriScheme.Svn, UriSchemeNames.Svn },
            };

            return output;
        }

        public static Dictionary<string, UriScheme> GetUriNamesByToken()
        {
            var namesByUriScheme = UriSchemeNames.GetNamesByUriScheme();

            var uriSchemesByName = namesByUriScheme.Invert();
            return uriSchemesByName;
        }

        #endregion
    }
}
