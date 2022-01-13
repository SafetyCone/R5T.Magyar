using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace System.IO
{
    public static class FileHelper
    {
        /// <summary>
        /// Actually reads all lines. The <see cref="File.ReadLines(string)"/> method omits blank last lines!
        /// </summary>
        public static string[] ActuallyReadAllLines(string filePath)
        {
            var text = File.ReadAllText(filePath);

            if(StringHelper.IsEmpty(text))
            {
                return Array.Empty<string>();
            }

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

        public static void DeleteOkIfNotExists(string filePath)
        {
            File.Delete(filePath); // Idempotent, so ok.
        }

        public static void EnsureDirectoryForFilePathExists(string filePath)
        {
            var directoryPath = FileHelper.GetParentDirectoryPath(filePath);

            DirectoryHelper.CreateDirectoryOkIfExists(directoryPath);
        }

        /// <summary>
        /// Note, there is no system supported asynchrons method for testing file existence. :-( See: https://stackoverflow.com/questions/19076652/check-if-a-file-exists-async
        /// </summary>
        public static bool Exists(string filePath)
        {
            var output = File.Exists(filePath);
            return output;
        }

        public static string GetParentDirectoryPath(string filePath)
        {
            var fileInfo = new FileInfo(filePath);

            var parentDirectoryPath = fileInfo.Directory.FullName;
            return parentDirectoryPath;
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

        public static StreamWriter WriteTextFile(string filePath, bool overwrite = IOHelper.DefaultOverwriteValue)
        {
            var output = StreamWriterHelper.NewWrite(filePath, overwrite);
            return output;
        }

        /// <summary>
        /// Ease of use name for the <see cref="ActuallyReadAllLines(string)"/> method.
        /// </summary>
        public static string[] ReadAllLinesSynchronous(string filePath)
        {
            var lines = FileHelper.ActuallyReadAllLines(filePath);
            return lines;
        }

        public static Task<string[]> ReadAllLines(string filePath)
        {
            return StreamReaderHelper.ReadAllLines(filePath);
        }

        public static async Task<string> Read(string filePath)
        {
            using (var reader = StreamReaderHelper.New(filePath))
            {
                var output = await reader.ReadToEndAsync();
                return output;
            }
        }

        public static void HandleOverwrite(string filePath, bool overwrite)
        {
            if(overwrite)
            {
                FileHelper.DeleteOnlyIfExists(filePath);
            }
        }

        public static void ThrowIfExists(string filePath)
        {
            if(FileHelper.Exists(filePath))
            {
                throw new IOException($"File exists: {filePath}");
            }
        }

        public static void ThrowIfExists(string filePath, bool overwrite)
        {
            if(!overwrite)
            {
                FileHelper.ThrowIfExists(filePath);
            }
        }

        public static Task WriteAllLines(string filePath, IEnumerable<string> lines, bool overwrite = IOHelper.DefaultOverwriteValue)
        {
            return StreamWriterHelper.WriteAllLines(filePath, lines, overwrite);
        }

        public static void WriteAllLinesSynchronous(string filePath, IEnumerable<string> lines, bool overwrite = IOHelper.DefaultOverwriteValue)
        {
            StreamWriterHelper.WriteAllLinesSynchronous(filePath, lines, overwrite);
        }

        public static async Task Write(string filePath, string content, bool overwrite = IOHelper.DefaultOverwriteValue)
        {
            using (var writer = StreamWriterHelper.NewWrite(filePath, overwrite))
            {
                await writer.WriteAsync(content);
            }
        }
    }
}
