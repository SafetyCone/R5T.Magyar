using System;


namespace System.IO
{
    public static class FileStreamHelper
    {
        /// <summary>
        /// Eases construction of a new <see cref="FileStream"/> with a best-practice implementation of handling the overwrite parameter.
        /// </summary>
        public static FileStream NewWrite(string filePath, bool overwrite = true)
        {
            FileMode fileMode = FileMode.Create;
            if (!overwrite)
            {
                fileMode = FileMode.CreateNew;
            }

            var fileStream = new FileStream(filePath, fileMode);
            return fileStream;
        }

        /// <summary>
        /// Eases construction of a new <see cref="FileStream"/> for reading.
        /// </summary>
        public static FileStream NewRead(string filePath)
        {
            var fileStream = new FileStream(filePath, FileMode.Open);
            return fileStream;
        }
    }
}
