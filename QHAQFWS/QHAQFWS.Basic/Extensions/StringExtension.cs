using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Basic.Extensions
{
    /// <summary>
    /// 字符串扩展类
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 字符串截取，前闭后开
        /// </summary>
        /// <param name="source">字符串</param>
        /// <param name="startIndex">开始索引</param>
        /// <param name="endIndex">结束索引</param>
        /// <returns></returns>
        public static string Substr(this string source, int startIndex, int endIndex)
        {
            return source.Substring(startIndex, endIndex - startIndex);
        }

        /// <summary>
        /// 将Base64格式的字符串转换为字节数组
        /// </summary>
        /// <param name="text">字符串</param>
        /// <returns></returns>
        public static byte[] FromBase64String(this string text)
        {
            return Convert.FromBase64String(text);
        }

        /// <summary>
        /// 将UTF8格式的字符串转换为字节数组
        /// </summary>
        /// <param name="text">字符串</param>
        /// <returns></returns>
        public static byte[] FromUTF8String(this string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        /// <summary>
        /// 将数值字符串转换为可空double数值
        /// </summary>
        /// <param name="text">数值字符串</param>
        /// <returns></returns>
        public static double? ToNullableDouble(this string text)
        {
            double value;
            if (double.TryParse(text, out value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        public static decimal? ToNullableDecimal(this string text)
        {
            decimal value;
            if (decimal.TryParse(text, out value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 将时间字符串转换为DateTime
        /// </summary>
        /// <param name="text">时间字符串</param>
        /// <param name="format">格式说明符</param>
        /// <returns></returns>
        public static DateTime ToDateTimeExact(this string text, string format)
        {
            return DateTime.ParseExact(text, format, CultureInfo.CurrentCulture);
        }
    }
}
