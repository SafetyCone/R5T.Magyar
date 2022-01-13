using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using R5T.Magyar.Extensions;


namespace System.IO
{
    /// <summary>
    /// A helper for the <see cref="StreamReader"/> class.
    /// </summary>
    public static class StreamReaderHelper
    {
        public const int DefaultBufferSize = 1024;


        /// <summary>
        /// The <see cref="StreamReader"/> class has a constructor that helpfully leaves the underlying stream open after reading. However, this constructor puts the argument to leave the underlying stream open at the end of the input arguments list, behind lots of values crazy random values.
        /// This method produces a <see cref="StreamReader"/> that will leave the underlying stream open with the ease of the default constructor.
        /// </summary>
        public static StreamReader NewLeaveOpen(Stream stream)
        {
            var output = new StreamReader(stream, Encoding.UTF8, true, StreamReaderHelper.DefaultBufferSize, true);
            return output;
        }

        public static StreamReader New(Stream stream)
        {
            var output = new StreamReader(stream);
            return output;
        }

        public static StreamReader New(string filePath)
        {
            var output = new StreamReader(filePath);
            return output;
        }

        public static async Task<List<string>> ReadAllLinesOneByOne(StreamReader streamReader)
        {
            var lines = new List<string>();

            var lineWasFound = await streamReader.ReadLineIsNotEnd();
            while(lineWasFound)
            {
                lines.Add(lineWasFound);

                lineWasFound = await streamReader.ReadLineIsNotEnd();
            }

            return lines;
        }

        public static async Task<List<string>> ReadAllLinesOneByOne(string filePath)
        {
            using (var streamReader = StreamReaderHelper.New(filePath))
            {
                var output = await StreamReaderHelper.ReadAllLinesOneByOne(streamReader);
                return output;
            }
        }

        public static async Task<string[]> ReadAllLines(StreamReader streamReader, string lineSeparator)
        {
            var allText = await streamReader.ReadToEndAsync();

            var lines = allText.Split(lineSeparator);
            return lines;
        }

        public static Task<string[]> ReadAllLines(StreamReader streamReader)
        {
            return StreamReaderHelper.ReadAllLines(streamReader, Strings.NewLineForEnvironment);
        }

        public static async Task<string[]> ReadAllLines(string filePath, string lineSeparator)
        {
            using (var streamReader = StreamReaderHelper.New(filePath))
            {
                var output = await StreamReaderHelper.ReadAllLines(streamReader, lineSeparator);
                return output;
            }
        }

        public static Task<string[]> ReadAllLines(string filePath)
        {
            return StreamReaderHelper.ReadAllLines(filePath, Strings.NewLineForEnvironment);
        }
    }
}
