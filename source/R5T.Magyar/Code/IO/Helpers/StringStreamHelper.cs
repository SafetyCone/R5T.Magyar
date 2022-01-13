using System;
using System.Text;


namespace System.IO
{
    public static class StringStreamHelper
    {
        public static MemoryStream New(string @string)
        {
            var encoding = Encoding.UTF8;

            var bytes = encoding.GetBytes(@string);

            return new MemoryStream(bytes);
        }
    }
}
