namespace Core.Util
{
    using System;

    /// <summary>
    /// 日期格式化工具类
    /// </summary>
    public static class DateUtil
    {
        /// <summary>
        /// 默认格式化类型
        /// </summary>
        public const string FORMATTER_PATTERN_DEFAULT = "yyyy-MM-dd";

        /// <summary>
        /// yyyy格式化类型
        /// </summary>
        public const string FORMATTER_PATTERN_YYYY = "yyyy";

        /// <summary>
        /// yyyy-MM格式化类型
        /// </summary>
        public const string FORMATTER_PATTERN_YYYY_MM = "yyyy-MM";

        /// <summary>
        /// yyyy-MM-dd HH:mm:ss格式化类型
        /// </summary>
        public const string FORMATTER_PATTERN_YYYY_MM_DD_HH_MM_SS = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// yyyy/MM格式化类型
        /// </summary>
        public const string FORMATTER_LEFT_PATTERN = "yyyy/MM";

        /// <summary>
        /// yyyy/MM/dd格式化类型
        /// </summary>
        public const string FORMATTER_LEFT_PATTERN_YYYY_MM_DD = "yyyy/MM/dd";

        /// <summary>
        /// yyyy/MM/dd HH:mm:ss格式化类型
        /// </summary>
        public const string FORMATTER_LEFT_PATTERN_YYYY_MM_DD_HH_MM_SS = "yyyy/MM/dd HH:mm:ss";

        /// <summary>
        /// 字符串转日期类型
        /// </summary>
        /// <param name="dateStr"></param>
        /// <returns></returns>
        public static DateTime Parse(string dateStr)
        {
            if (string.IsNullOrEmpty(dateStr))
            {
                return DateTime.Now;
            }

            var parseResult = DateTime.TryParse(dateStr, out DateTime parseDateTime);
            if (!parseResult)
            {
                return DateTime.Now;
            }

            return parseDateTime;
        }

        /// <summary>
        /// 日期类型格式化
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string FormatterDate(DateTime date)
        {
            return FormatterDate(date, FORMATTER_PATTERN_DEFAULT);
        }

        /// <summary>
        /// 日期类型格式化
        /// </summary>
        /// <param name="date"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static string FormatterDate(DateTime date, string pattern)
        {
            string result = string.Empty;
            if (null == date)
            {
                return result;
            }

            if (string.IsNullOrEmpty(pattern))
            {
                pattern = FORMATTER_PATTERN_DEFAULT;
            }

            return date.ToString(pattern);
        }

        /// <summary>
        /// 日期类型转时间戳
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static long ToMillisecond(this DateTime date)
        {
            DateTime value = new DateTime(1970, 1, 1).AddHours(8.0);
            return (long)date.Subtract(value).TotalMilliseconds;
        }

        /// <summary>
        /// 字符串转时间戳
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static long ToMillisecond(this string date)
        {
            return (long)new TimeSpan(TimeZoneInfo.ConvertTimeToUtc(Parse(date)).Ticks - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks).TotalMilliseconds;
        }

        /// <summary>
        /// 时间戳转日期类型
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime Long2Date(this long date)
        {
            return new DateTime(1970, 1, 1).AddHours(8.0).AddMilliseconds(date);
        }

        /// <summary>
        /// 时间戳转字符串
        /// </summary>
        /// <param name="date"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static string Long2String(this long date, string pattern = "")
        {
            if (string.IsNullOrEmpty(pattern))
            {
                pattern = FORMATTER_PATTERN_DEFAULT;
            }

            return date.Long2Date().ToString(pattern);
        }

    }
}
