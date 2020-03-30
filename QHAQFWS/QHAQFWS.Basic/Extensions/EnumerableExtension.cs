using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Basic.Extensions
{
    public static class EnumerableExtension
    {
        #region Percentile
        /// <summary>
        /// 计算序列的百分位数
        /// </summary>
        /// <param name="source">序列</param>
        /// <param name="p">百分位</param>
        /// <returns>值序列的百分位数</returns>
        public static double Percentile(this IEnumerable<double> source, double p)
        {
            int count = source.Count();
            if (count == 0)
            {
                throw new InvalidOperationException("序列不包含任何元素。");
            }
            else
            {
                source = source.OrderBy(o => o);
                double k = (count - 1) * p;
                int s = (int)Math.Floor(k);
                double sValue = source.ElementAt(s);
                if (k == s)
                {
                    return sValue;
                }
                else
                {
                    return sValue + (source.ElementAt(s + 1) - sValue) * (k - s);
                }
            }
        }

        public static double? Percentile(this IEnumerable<double?> source, double p)
        {
            double? percentile;
            IEnumerable<double> temp = source.Where(o => o.HasValue).Select(o => o.Value);
            if (temp.Any())
            {
                percentile = temp.Percentile(p);
            }
            else
            {
                percentile = null;
            }
            return percentile;
        }

        public static double Percentile<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector, double p)
        {
            return source.Select(o => selector(o)).Percentile(p);
        }

        public static double? Percentile<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector, double p)
        {
            return source.Select(o => selector(o)).Percentile(p);
        }

        /// <summary>
        /// 计算序列的百分位数
        /// </summary>
        /// <param name="source">序列</param>
        /// <param name="p">百分位</param>
        /// <returns>值序列的百分位数</returns>
        public static decimal Percentile(this IEnumerable<decimal> source, decimal p)
        {
            int count = source.Count();
            if (count == 0)
            {
                throw new InvalidOperationException("序列不包含任何元素。");
            }
            else
            {
                source = source.OrderBy(o => o);
                decimal k = (count - 1) * p;
                int s = (int)Math.Floor(k);
                decimal sValue = source.ElementAt(s);
                if (k == s)
                {
                    return sValue;
                }
                else
                {
                    return sValue + (source.ElementAt(s + 1) - sValue) * (k - s);
                }
            }
        }

        public static decimal? Percentile(this IEnumerable<decimal?> source, decimal p)
        {
            decimal? percentile;
            IEnumerable<decimal> temp = source.Where(o => o.HasValue).Select(o => o.Value);
            if (temp.Any())
            {
                percentile = temp.Percentile(p);
            }
            else
            {
                percentile = null;
            }
            return percentile;
        }

        public static decimal Percentile<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector, decimal p)
        {
            return source.Select(o => selector(o)).Percentile(p);
        }

        public static decimal? Percentile<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector, decimal p)
        {
            return source.Select(o => selector(o)).Percentile(p);
        }
        #endregion
    }
}
