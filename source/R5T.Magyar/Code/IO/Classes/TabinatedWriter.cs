using System;
using System.IO;


namespace R5T.Magyar.IO
{
    /// <summary>
    /// A <see cref="System.IO.TextWriter"/> wrapper that allows prefixing lines with consistent tabination.
    /// </summary>
    /// <remarks>
    /// Based on: https://github.com/MinexAutomation/R5T.NetStandard.IO.Serialization/blob/master/source/R5T.NetStandard.IO.Serialization/Code/Classes/TabinatedWriter.cs
    /// </remarks>
    public class TabinatedWriter
    {
        public const bool DefaultReplaceTabsWithSpaces = true;
        public const int DefaultNumberOfSpacesPerTab = 4;


        private TextWriter TextWriter { get; }
        private int NumberOfTabs { get; set; } = 0;
        private bool ReplaceTabsWithSpaces { get; }
        private int NumberOfSpacesPerTab { get; }


        public TabinatedWriter(TextWriter textWriter, bool replaceTabsWithSpaces = TabinatedWriter.DefaultReplaceTabsWithSpaces, int numberOfSpacesPerTab = TabinatedWriter.DefaultNumberOfSpacesPerTab)
        {
            this.TextWriter = textWriter;
        }

        public void WriteLine(string line)
        {
            var charToRepeat = this.ReplaceTabsWithSpaces ? ' ' : '\t';
            var numberOfRepeats = this.ReplaceTabsWithSpaces ? this.NumberOfTabs * this.NumberOfSpacesPerTab : this.NumberOfTabs;

            var tabs = new string(charToRepeat, numberOfRepeats);

            var outputLine = $@"{tabs}{line}";

            this.TextWriter.WriteLine(outputLine);
        }

        public void WriteEmptyLine()
        {
            this.TextWriter.WriteLine();
        }

        public void IncreaseTabination()
        {
            this.NumberOfTabs++;
        }

        public void DecreaseTabination()
        {
            this.NumberOfTabs--;
        }
    }
}
