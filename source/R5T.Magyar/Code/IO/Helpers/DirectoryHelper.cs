using System;
using System.IO;


namespace R5T.Magyar.IO
{
    public static class DirectoryHelper
    {
        /// <summary>
        /// Creates a directory idempotently (meaning there is no problem with issuing the command multiple times). 
        /// Note: <see cref="Directory.CreateDirectory(string)"/> already does not throw an exception if you create a directory that already exists. However, it's hard to remember this fact. Thus, this method name makes that fact explicit.
        /// </summary>
        public static void CreateDirectoryOkIfExists(string directoryPath)
        {
            // Does not throw an exception if a directory already exists.
            // See proof at: https://github.com/MinexAutomation/Public/blob/a8c302415b56fb8903c751436cbeef3eae8e1692/Source/Experiments/CSharp/ExaminingCSharp/ExaminingCSharp/Code/Experiments/IOExperiments.cs#L24
            Directory.CreateDirectory(directoryPath);
        }

        public static void DeleteDirectoryOkIfNotExists(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath, true);
            }
        }

        /// <summary>
        /// Deletes a directory path.
        /// The <see cref="System.IO.Directory.Delete(string)"/> method throws a <see cref="System.IO.DirectoryNotFoundException"/> if attempting to delete a non-existent directory. This is annoying.
        /// All you really want is the directory to not exist, so this method simply takes care of checking if the directory exists.
        /// Also annoying, you need to specify the recursive option to delete a directory with anything in it. This method also takes care of specifying true for the recursive option.
        /// Even more annoying, even after specifying the recursive option, the system method will not delete read-only files. Thus this method disables read-only options on all files recursively.
        /// </summary>
        public static void DeleteRobust(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                DirectoryHelper.DisableReadOnly(directoryPath);

                Directory.Delete(directoryPath, true);
            }
        }

        public static void DisableReadOnly(string directoryPath)
        {
            var directoryInfo = new DirectoryInfo(directoryPath);

            DirectoryHelper.DisableReadOnly(directoryInfo);
        }

        /// <summary>
        /// Remove the read-only attribute from all files.
        /// </summary>
        /// <remarks>
        /// Adapted from: https://stackoverflow.com/questions/1982209/cannot-programatically-delete-svn-working-copy
        /// </remarks>
        public static void DisableReadOnly(DirectoryInfo directoryInfo)
        {
            foreach (var file in directoryInfo.GetFiles())
            {
                if (file.IsReadOnly)
                {
                    file.IsReadOnly = false;
                }
            }

            foreach (var subdirectory in directoryInfo.GetDirectories())
            {
                DirectoryHelper.DisableReadOnly(subdirectory);
            }
        }

        /// <summary>
        /// Determine if a path is a directory.
        /// </summary>
        /// <remarks>
        /// StackOverflow: https://stackoverflow.com/questions/1395205/better-way-to-check-if-a-path-is-a-file-or-a-directory
        /// </remarks>
        public static bool IsDirectory(string path)
        {
            var fileSystemEntryAttributes = File.GetAttributes(path); // Directories are actually files, with a special attribute.

            var isDirectory = (fileSystemEntryAttributes & FileAttributes.Directory) == FileAttributes.Directory;
            return isDirectory;
        }
    }
}
