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
    }
}
