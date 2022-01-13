using System;

using R5T.Magyar.IO;


namespace System.IO
{
    public static class TextWriterHelper
    {
        public static TextWriter New(string filePath, bool overwrite = IOHelper.DefaultOverwriteValue)
        {
            var stream = FileStreamHelper.NewWrite(filePath, overwrite);

            var output = StreamWriterHelper.NewCloseAfter(stream);
            return output;
        }
    }
}
