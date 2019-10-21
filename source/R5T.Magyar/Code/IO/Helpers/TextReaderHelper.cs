using System;
using System.IO;


namespace R5T.Magyar.IO
{
    public static class TextReaderHelper
    {
        public const string EndOfString = null;


        public static bool ReadLine(this TextReader textReader, out string line)
        {
            line = textReader.ReadLine();

            var isEnd = line == TextReaderHelper.EndOfString;
            return isEnd;
        }
    }
}
