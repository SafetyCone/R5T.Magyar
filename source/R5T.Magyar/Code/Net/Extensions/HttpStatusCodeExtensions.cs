using System;


namespace System.Net
{
    public static class HttpStatusCodeExtensions
    {
        public static bool IsOk(this HttpStatusCode httpStatusCode)
        {
            var isOk = httpStatusCode == HttpStatusCode.OK;
            return isOk;
        }
    }
}
