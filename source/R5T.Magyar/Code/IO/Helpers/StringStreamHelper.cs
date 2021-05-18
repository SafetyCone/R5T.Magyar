using System;
using System.IO;
using System.Text;


namespace R5T.Magyar.IO
{
    public static class StringStreamHelper
    {
        public static MemoryStream New(string @string)
        {
            var encoding = Encoding.UTF8;

            var bytes = Encoding.UTF8.GetBytes(@string);

            return new MemoryStream(bytes);
        }
    }
}
