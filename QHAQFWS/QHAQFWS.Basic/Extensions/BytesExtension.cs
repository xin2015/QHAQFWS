using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Basic.Extensions
{
    public static class BytesExtension
    {
        /// <summary>
        /// 将字节数组转换为Base64格式的字符串
        /// </summary>
        /// <param name="array">字节数组</param>
        /// <returns></returns>
        public static string ToBase64String(this byte[] array)
        {
            return Convert.ToBase64String(array);
        }

        /// <summary>
        /// 将字节数组转换为UTF8格式的字符串
        /// </summary>
        /// <param name="array">字节数组</param>
        /// <returns></returns>
        public static string ToUTF8String(this byte[] array)
        {
            return Encoding.UTF8.GetString(array);
        }

        /// <summary>
        /// 将字节数组转换为指定格式的字符串
        /// </summary>
        /// <param name="array">字节数组</param>
        /// <param name="format">一个数值格式字符串</param>
        /// <returns></returns>
        public static string ToFormatString(this byte[] array, string format)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte item in array)
            {
                sb.Append(item.ToString(format));
            }
            return sb.ToString();
        }
    }
}
