namespace Core.Util
{
    public static class StringUtil
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static bool IsOutOfAllow(string str, int length)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            if (str.Length <= length)
            {
                return false;
            }

            return true;
        }

    }
}
