﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace R5T.Magyar.IO
{
    using System.IO;

    using R5T.Magyar.Extensions;


    public static class IDictionaryExtensions
    {
        public static IEnumerable<string> GetLines<T>(this IDictionary<string, T> stringsByString)
            where T : IEnumerable<string>
        {
            string line;
            
            foreach (var key in stringsByString.Keys)
            {
                var strings = stringsByString[key];

                line = $"{key} (Count: {strings.Count()})";
                
                yield return line;

                foreach (var @string in strings)
                {
                    line = $"{Strings.Tab}{@string}";

                    yield return line;
                }

                // Group separator.
                yield return "\n***\n";
            }
        }

        public static void WriteToFile<T>(this IDictionary<string, T> stringsByString,
            string filePath,
            bool overwrite = IOHelper.DefaultOverwriteValue)
            where T : IEnumerable<string>
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

        public static void WriteToFileInAlphabeticalOrder<T>(this IDictionary<string, T> stringsByString,
            string filePath,
            bool overwrite = IOHelper.DefaultOverwriteValue)
            where T : IEnumerable<string>
        {
            var stringsByStringsInOrder = stringsByString
                .OrderAlphabetically(xPair => xPair.Key)
                .ToDictionary(
                    xPair => xPair.Key,
                    xPair => xPair.Value
                        .OrderAlphabetically());

            stringsByStringsInOrder.WriteToFile(filePath, overwrite);
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
                    var strings = stringsByString.AcquireValue_OLD(key, () => new List<string>());

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
