using System;
using System.ComponentModel;
using System.Reflection;

namespace Core.Util
{
    /// <summary>
    /// 枚举工具类
    /// </summary>
    public static class EnumUtil
    {
        /// <summary>
        /// 获取枚举描述扩展方法
        /// </summary>
        /// <param name="enumItem">枚举项</param>
        /// <returns></returns>
        public static string GetDescription(this Enum enumItem)
        {
            // 获取类型
            Type type = enumItem.GetType();
            //获取成员
            MemberInfo[] memberInfos = type.GetMember(enumItem.ToString());
            if (memberInfos != null && memberInfos.Length > 0)
            {
                // 获取描述特性
                DescriptionAttribute[] attrs = memberInfos[0].GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

                if (null != attrs && attrs.Length > 0)
                {
                    // 返回当前描述
                    return attrs[0].Description;
                }
            }

            return string.Empty;
        }
    }
}