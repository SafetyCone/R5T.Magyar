using System;
using System.Collections.Generic;
using System.IO;


namespace R5T.Magyar.IO
{
    public static class TextReaderExtension
    {
        public static bool ReadLineIsNotEnd(this TextReader textReader, out string line)
        {
            var output = TextReaderHelper.ReadLineIsNotEnd(textReader, out line);
            return output;
        }

        public static IEnumerable<string> ReadAllLines(this TextReader textReader)
        {
            while(textReader.ReadLineIsNotEnd(out var line))
            {
                yield return line;
            }
        }

        public static IEnumerable<string> ReadAtMostNLines(this TextReader textReader, int numberOfLines)
        {
            var count = 0;
            while (textReader.ReadLineIsNotEnd(out var line) && count < numberOfLines)
            {
                count++;

                yield return line;
            }
        }
    }
}
