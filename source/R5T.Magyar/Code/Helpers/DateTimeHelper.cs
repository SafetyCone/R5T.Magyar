using System;
using System.Globalization;


namespace R5T.Magyar
{
    public static class DateTimeHelper
    {
        public static DateTime FromYYYYMMDD_HHMMSS(string yyyymmdd_hhmmss)
        {
            var output = DateTime.ParseExact(yyyymmdd_hhmmss, "yyyyMMdd-HHmmss", CultureInfo.InvariantCulture);
            return output;
        }
    }
}
