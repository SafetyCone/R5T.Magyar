using System;
using System.Threading.Tasks;


namespace R5T.Magyar.IO
{
    /// <summary>
    /// Helper for writing files.
    /// </summary>
    /// <remarks>
    /// Note: there is no FileWriter class in System.IO. So while <see cref="FileWriterHelper"/> is modeled on <see cref="StreamWriterHelper"/> and <see cref="FileStreamHelper"/>, just don't go looking for a System.IO.FileWriter class.
    /// </remarks>
    public static class FileWriterHelper
    {
        public static Task Write(string filePath, string content, bool overwrite = IOHelper.DefaultOverwriteValue)
        {
            return FileHelper.Write(filePath, content, overwrite);
        }
    }
}
