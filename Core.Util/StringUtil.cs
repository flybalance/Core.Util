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
        public static bool IsOutOfAllow(this string str, int length)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            return str.Length > length;
        }
    }
}