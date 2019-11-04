using System;
using System.IO;


namespace R5T.Magyar.IO
{
    public static class FileHelper
    {
        /// <summary>
        /// Deletes a file if it exists.
        /// Note: the <see cref="System.IO.File.Delete(string)"/> implementation is idempotent, meaning it will not throw an exception if the file does not exist.
        /// However, it's easy to forget this fact about the method's behavior. Thus this method provides a convenient name that communicates the expected behavior.
        /// </summary>
        public static void DeleteOnlyIfExists(string filePath)
        {
            File.Delete(filePath); // Idempotent, so ok.
        }

        public static bool Exists(string filePath)
        {
            var output = File.Exists(filePath);
            return output;
        }
    }
}
