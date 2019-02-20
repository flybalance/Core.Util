using System.Text.RegularExpressions;

namespace Core.Util
{
    /// <summary>
    /// String操作工具类
    /// </summary>
    public static class StringUtil
    {
        /// <summary>
        /// 字符串长度判断
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static bool IsOutOfLength(this string str, int length)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            return str.Length > length;
        }

        /// <summary>
        /// 判断字符串是否为数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }
    }
}