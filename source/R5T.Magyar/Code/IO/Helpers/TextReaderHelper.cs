﻿using System;
using System.Threading.Tasks;

using R5T.Magyar;


namespace System.IO
{
    public static class TextReaderHelper
    {
        public const string EndOfTextLine = null;


        public static bool IsEndOfTextLine(string line)
        {
            var output = line == TextReaderHelper.EndOfTextLine;
            return output;
        }

        public static TextReader New(string filePath)
        {
            var output = new StreamReader(filePath);
            return output;
        }

        public static bool ReadLineIsNotEndSynchronous(TextReader textReader, out string line)
        {
            line = textReader.ReadLine();

            var hasLine = !TextReaderHelper.IsEndOfTextLine(line);
            return hasLine;
        }

        public static async Task<WasFound<string>> ReadLineIsNotEnd(TextReader textReader)
        {
            var line = await textReader.ReadLineAsync();

            var hasLine = !TextReaderHelper.IsEndOfTextLine(line);

            var wasFound = WasFound.From(hasLine, line);
            return wasFound;
        }
    }
}
