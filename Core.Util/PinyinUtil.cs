namespace Core.Util
{
    using Microsoft.International.Converters.PinYinConverter;
    using System.Text;

    /// <summary>
    /// 中文拼音工具类
    /// </summary>
    public static class PinyinUtil
    {
        /// <summary>
        /// 获取中文的全拼(大写)
        /// </summary>
        /// <param name="chineseStr"></param>
        /// <returns></returns>
        public static string GetPinYin(string chineseStr)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < chineseStr.Length; i++)
            {
                char c = chineseStr[i];
                try
                {
                    ChineseChar chineseChar = new ChineseChar(c);
                    string text2 = chineseChar.Pinyins[0].ToString();
                    stringBuilder.Append(text2.Substring(0, text2.Length - 1));
                }
                catch
                {
                    stringBuilder.Append(c.ToString());
                }
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// 获取中文的拼音首字母(大写)
        /// </summary>
        /// <param name="chineseStr"></param>
        /// <returns></returns>
        public static string GetSimplifiedPinYin(string chineseStr)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < chineseStr.Length; i++)
            {
                char c = chineseStr[i];
                try
                {
                    ChineseChar chineseChar = new ChineseChar(c);
                    string text2 = chineseChar.Pinyins[0].ToString();
                    stringBuilder.Append(text2.Substring(0, 1));
                }
                catch
                {
                    stringBuilder.Append(c.ToString());
                }
            }

            return stringBuilder.ToString();
        }
    }
}