using System;
using System.IO;
using System.Threading.Tasks;


namespace R5T.Magyar.IO
{
    public static class FileHelper
    {
        /// <summary>
        /// Actually reads all lines. The <see cref="File.ReadLines(string)"/> method omits blank last lines!
        /// </summary>
        public static string[] ActuallyReadAllLines(string filePath)
        {
            var text = File.ReadAllText(filePath);

            var lines = text.Split(new[] { "\n", "\r\n" }, StringSplitOptions.None);
            return lines;
        }

        public static Task DeleteAsync(string filePath)
        {
            var delete = Task.Run(() => File.Delete(filePath));
            return delete;
        }

        public static Task DeleteOnlyIfExistsAsync(string filePath)
        {
            var delete = Task.Run(() => FileHelper.DeleteOnlyIfExistsAsync(filePath));
            return delete;
        }

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

        /// <summary>
        /// Determine if a path is a file.
        /// </summary>
        public static bool IsFile(string path)
        {
            var isDirectory = DirectoryHelper.IsDirectory(path);

            var isFile = !isDirectory; // Assumes that file-system entries are either files, or directories.
            return isFile;
        }

        public static string GetParentDirectoryPath(string filePath)
        {
            var fileInfo = new FileInfo(filePath);

            var parentDirectoryPath = fileInfo.Directory.FullName;
            return parentDirectoryPath;
        }

        /// <summary>
        /// Ease of use name for the <see cref="ActuallyReadAllLines(string)"/> method.
        /// </summary>
        public static string[] ReadAllLines(string filePath)
        {
            var lines = FileHelper.ActuallyReadAllLines(filePath);
            return lines;
        }
    }
}
