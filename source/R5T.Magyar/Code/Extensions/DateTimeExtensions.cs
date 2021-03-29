﻿using System;


namespace R5T.Magyar.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToMM_DD_YYYY(this DateTime dateTime)
        {
            var output = $"{dateTime:MM/dd/yyyy}";
            return output;
        }

        public static string ToYYYYMMDD(this DateTime dateTime)
        {
            var output = $"{dateTime:yyyyMMdd}";
            return output;
        }

        public static string ToHHMMSS(this DateTime dateTime)
        {
            string output = $"{dateTime:HHmmss}";
            return output;
        }

        public static string TohhMMSS_tt(this DateTime dateTime)
        {
            var output = $"{dateTime:hhmmss tt}";
            return output;
        }

        public static string ToMMSlashDD_HHColonMM(this DateTime dateTime)
        {
            var output = $"{dateTime:MM/dd HH:mm}";
            return output;
        }

        public static string ToYYYYMMDD_HHMMSS(this DateTime dateTime)
        {
            string yyyymmdd = dateTime.ToYYYYMMDD();
            string hhmmss = dateTime.ToHHMMSS();

            string output = $"{yyyymmdd}-{hhmmss}";
            return output;
        }

        public static string ToYYYYMMDD_hhMMSS_tt(this DateTime dateTime)
        {
            string dateRepresentation = dateTime.ToYYYYMMDD();
            string timeRepresentation = dateTime.TohhMMSS_tt();

            string output = $"{dateRepresentation}-{timeRepresentation}";
            return output;
        }

        public static string ToHHMMSS_FFF(this DateTime dateTime)
        {
            var output = $"{dateTime:HHmmss.fff}";
            return output;
        }

        public static string ToYYYYMMDD_HHMMSS_FFF(this DateTime dateTime)
        {
            var yyyymmdd = dateTime.ToYYYYMMDD();
            var hhmmssfff = dateTime.ToHHMMSS_FFF();

            var output = $"{yyyymmdd}-{hhmmssfff}";
            return output;
        }

        public static string ToMostLegibleUS(this DateTime dateTime)
        {
            var output = $"{dateTime:MM/dd/yyyy HH:mm:ss tt}";
            return output;
        }

        // Note! Cannot convert this way since OSX/Ubuntu/Linux does not have "Pacific Standard Time".
        // Instead, use the TimeZoneConverter NuGet package: https://devblogs.microsoft.com/dotnet/cross-platform-time-zones-with-net-core/
        //public static DateTime ToPacificFromUTC(this DateTime dateTimeUtc)
        //{
        //    TimeZoneInfo pacificStandardTime = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

        //    var pacificDateTime = TimeZoneInfo.ConvertTimeFromUtc(dateTimeUtc, pacificStandardTime);
        //    return pacificDateTime;
        //}
    }
}
