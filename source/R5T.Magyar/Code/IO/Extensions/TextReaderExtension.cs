using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;


namespace R5T.Magyar.IO
{
    public static class TextReaderExtension
    {
        public static bool ReadLineIsNotEndSynchronous(this TextReader textReader, out string line)
        {
            var output = TextReaderHelper.ReadLineIsNotEndSynchronous(textReader, out line);
            return output;
        }

        public static Task<WasFound<string>> ReadLineIsNotEnd(this TextReader textReader)
        {
            var output = TextReaderHelper.ReadLineIsNotEnd(textReader);
            return output;
        }

        public static IEnumerable<string> ReadAllLines(this TextReader textReader)
        {
            while(textReader.ReadLineIsNotEndSynchronous(out var line))
            {
                yield return line;
            }
        }

        public static IEnumerable<string> ReadAtMostNLines(this TextReader textReader, int numberOfLines)
        {
            var count = 0;
            while (textReader.ReadLineIsNotEndSynchronous(out var line) && count < numberOfLines)
            {
                count++;

                yield return line;
            }
        }
    }
}
