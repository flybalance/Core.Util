namespace Core.Util
{
    using System;

    /// <summary>
    /// Decimal数据类型扩展方法
    /// </summary>
    public static class DecimalUtil
    {
        /// <summary>
        /// decimal保留指定位数小数
        /// </summary>
        /// <param name="num">原始数量</param>
        /// <param name="scale">保留小数位数</param>
        /// <returns>截取指定小数位数后的数量字符串</returns>
        public static string InterceptToString(this decimal num, int scale)
        {
            string numToString = num.ToString();
            int index = numToString.IndexOf(".");
            if (index <= -1)
            {
                return $"{numToString}.".PadRight(scale + numToString.Length + 1, '0');
            }

            int digtiNum = numToString.Substring(index + 1, numToString.Length - (index + 1)).Length;
            if (digtiNum < scale)
            {
                numToString = numToString.PadRight(numToString.Length + scale, '0');
            }

            return $"{numToString.Substring(0, index)}.{numToString.Substring(index + 1, Math.Min(numToString.Length - index - 1, scale))}";
        }

        /// <summary>
        /// decimal保留指定位数小数
        /// </summary>
        /// <param name="num"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static decimal InterceptToDecimal(this decimal num, int scale)
        {
            return Convert.ToDecimal(num.InterceptToString(scale));
        }
    }
}
