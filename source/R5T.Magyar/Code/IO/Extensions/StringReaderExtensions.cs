using System;
using System.IO;


namespace R5T.Magyar.IO
{
    public static class StringReaderExtensions
    {
        public static bool ReadLineIsEnd(this StringReader stringReader, out string line)
        {
            var output = TextReaderHelper.ReadLine(stringReader, out line);
            return output;
        }
    }
}
