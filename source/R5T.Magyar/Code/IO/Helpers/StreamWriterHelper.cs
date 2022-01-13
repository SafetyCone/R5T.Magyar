using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace System.IO
{
    /// <summary>
    /// A helper for the <see cref="StreamWriter"/> class.
    /// </summary>
    public static class StreamWriterHelper
    {
        /// <summary>
        /// The <see cref="StreamWriter"/> class has a constructor that helpfully leaves the underlying stream open after writing. However, this constructor puts the argument to leave the underlying stream open at the end of the input arguments list, behind lots of values crazy random values.
        /// This method produces a <see cref="StreamWriter"/> that will leave the underlying stream open with the ease of the default constructor.
        /// 
        /// Note: Returned writer produces no BOM.
        /// </summary>
        public static StreamWriter NewLeaveOpen(Stream stream)
        {
            // Note new UTF8Encoding(false), instead of Encoding.UTF8, to prevent random byte-order-marks (BOM) marks. This was a big problem in writing to existing memory streams since the odd-number of BOM bytes (3) would be placed where writing started, in the middle of the memory stream!
            var output = new StreamWriter(stream, new UTF8Encoding(false), StreamReaderHelper.DefaultBufferSize, true);
            return output;
        }

        /// <summary>
        /// The <see cref="StreamWriter"/> class has a constructor that helpfully leaves the underlying stream open after writing. However, this constructor puts the argument to leave the underlying stream open at the end of the input arguments list, behind lots of values crazy random values.
        /// This method produces a <see cref="StreamWriter"/> that will leave the underlying stream open with the ease of the default constructor.
        /// 
        /// Note: Returned writer produces byte-order-marks (BOM).
        /// </summary>
        public static StreamWriter NewLeaveOpenAddBOM(Stream stream)
        {
            // Note new UTF8Encoding(false), instead of Encoding.UTF8, to prevent random byte-order-marks (BOM) marks. This was a big problem in writing to existing memory streams since the odd-number of BOM bytes (3) would be placed where writing started, in the middle of the memory stream!
            var output = new StreamWriter(stream, Encoding.UTF8, StreamReaderHelper.DefaultBufferSize, true);
            return output;
        }

        /// <summary>
        /// The <see cref="StreamWriter"/> class by default closes the underlying stream to which it writes. The <see cref="StreamWriterHelper.NewLeaveOpen(Stream)"/> method creates a <see cref="StreamWriter"/> that will be left open.
        /// This method provides the default <see cref="StreamWriter"/> behavior, to allow library users to get in the habit of using the <see cref="StreamWriterHelper"/> in all cases, and to make the behavior of the <see cref="StreamWriter"/> explicit.
        /// 
        /// Note: Returned writer produces no BOM.
        /// </summary>
        public static StreamWriter NewCloseAfter(Stream stream)
        {
            // This constructor produces no BOM as proven in an ExaminingCSharp experiment.
            var output = new StreamWriter(stream);
            return output;
        }

        public static StreamWriter NewWrite(string filePath, bool overwrite = IOHelper.DefaultOverwriteValue)
        {
            var stream = FileStreamHelper.NewWrite(filePath, overwrite);

            var output = StreamWriterHelper.NewCloseAfter(stream);
            return output;
        }

        public static async Task WriteAllLinesOneByOne(StreamWriter writer, IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                await writer.WriteLineAsync(line);
            }
        }

        public static async Task WriteAllLinesOneByOne(string filePath, IEnumerable<string> lines, bool overwrite = IOHelper.DefaultOverwriteValue)
        {
            using (var streamWriter = StreamWriterHelper.NewWrite(filePath, overwrite))
            {
                await StreamWriterHelper.WriteAllLinesOneByOne(streamWriter, lines);
            }
        }

        public static Task WriteAllLines(StreamWriter writer, IEnumerable<string> lines, string lineSeparator)
        {
            var text = String.Join(lineSeparator, lines);

            return writer.WriteAsync(text);
        }

        public static void WriteAllLinesSynchronous(StreamWriter writer, IEnumerable<string> lines, string lineSeparator)
        {
            var text = String.Join(lineSeparator, lines);

            writer.Write(text);
        }

        public static Task WriteAllLines(StreamWriter writer, IEnumerable<string> lines)
        {
            return StreamWriterHelper.WriteAllLines(writer, lines, Strings.NewLineForEnvironment);
        }

        public static void WriteAllLinesSynchronous(StreamWriter writer, IEnumerable<string> lines)
        {
            StreamWriterHelper.WriteAllLinesSynchronous(writer, lines, Strings.NewLineForEnvironment);
        }

        public static async Task WriteAllLines(string filePath, IEnumerable<string> lines, string lineSeparator, bool overwrite = IOHelper.DefaultOverwriteValue)
        {
            using (var writer = StreamWriterHelper.NewWrite(filePath, overwrite))
            {
                await StreamWriterHelper.WriteAllLines(writer, lines, lineSeparator);
            }
        }

        public static void WriteAllLinesSynchronous(string filePath, IEnumerable<string> lines, string lineSeparator, bool overwrite = IOHelper.DefaultOverwriteValue)
        {
            using (var writer = StreamWriterHelper.NewWrite(filePath, overwrite))
            {
                StreamWriterHelper.WriteAllLinesSynchronous(writer, lines, lineSeparator);
            }
        }

        public static Task WriteAllLines(string filePath, IEnumerable<string> lines, bool overwrite = IOHelper.DefaultOverwriteValue)
        {
            return StreamWriterHelper.WriteAllLines(filePath, lines, Strings.NewLineForEnvironment, overwrite);
        }

        public static void WriteAllLinesSynchronous(string filePath, IEnumerable<string> lines, bool overwrite = IOHelper.DefaultOverwriteValue)
        {
            StreamWriterHelper.WriteAllLinesSynchronous(filePath, lines, Strings.NewLineForEnvironment, overwrite);
        }
    }
}
