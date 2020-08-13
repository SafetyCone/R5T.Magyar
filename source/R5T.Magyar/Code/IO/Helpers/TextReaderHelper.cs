using System;
using System.IO;


namespace R5T.Magyar.IO
{
    public static class TextReaderHelper
    {
        public const string EndOfTextLine = null;


        public static bool IsEndOfTextLine(string line)
        {
            var output = line == TextReaderHelper.EndOfTextLine;
            return output;
        }

        public static bool ReadLineIsNotEnd(TextReader textReader, out string line)
        {
            line = textReader.ReadLine();

            var hasLine = !TextReaderHelper.IsEndOfTextLine(line);
            return hasLine;
        }
    }
}
