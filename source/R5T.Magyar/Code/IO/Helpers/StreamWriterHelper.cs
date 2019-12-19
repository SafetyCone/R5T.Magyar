using System;
using System.IO;
using System.Text;


namespace R5T.Magyar.IO
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
    }
}
