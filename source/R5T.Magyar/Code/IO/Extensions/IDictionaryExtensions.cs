using System;
using System.Collections.Generic;
using System.Linq;


namespace R5T.Magyar.IO
{
    public static class IDictionaryExtensions
    {
        public static void WriteToFile(this IDictionary<string, List<string>> stringsByString,
            string filePath,
            bool overwrite = IOHelper.DefaultOverwriteValue)
        {
            using (var writer = StreamWriterHelper.NewWrite(filePath, overwrite))
            {
                foreach (var key in stringsByString.Keys)
                {
                    writer.WriteLine(key);

                    var strings = stringsByString[key];
                    foreach (var @string in strings)
                    {
                        var line = $"{Strings.Tab}{@string}";

                        writer.WriteLine(line);
                    }
                }
            }
        }

        public static T FillFromFile<T>(this T stringsByString,
            string filePath)
            where T : IDictionary<string, List<string>>
        {
            using (var reader = StreamReaderHelper.New(filePath))
            {
                if(reader.EndOfStream)
                {
                    return stringsByString; // Empty file, done.
                }

                var key = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var strings = stringsByString.AcquireValue(key, () => new List<string>());

                    while(!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        if(line.First() == Characters.Tab)
                        {
                            var @string = line.ExceptFirstCharacter();

                            strings.Add(@string);
                        }
                        else
                        {
                            key = line;

                            break;
                        }
                    }
                }
            }

            return stringsByString;
        }
    }
}
