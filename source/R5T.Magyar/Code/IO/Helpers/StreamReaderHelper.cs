using System;
using System.IO;
using System.Text;


namespace R5T.Magyar.IO
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
    }
}
