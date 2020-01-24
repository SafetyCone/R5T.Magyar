using System;
using System.IO;


namespace R5T.Magyar.IO.Extensions
{
    public static class TextReaderExtension
    {
        public static bool ReadLine(this TextReader textReader, out string line)
        {
            var output = TextReaderHelper.ReadLine(textReader, out line);
            return output;
        }
    }
}
