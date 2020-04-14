using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Basic.Extensions
{
    public static class NullableDecimalExtension
    {
        public static decimal? Round(this decimal? value)
        {
            return value.HasValue ? decimal.Round(value.Value) : value;
        }

        public static decimal? Round(this decimal? value, int decimals)
        {
            return value.HasValue ? decimal.Round(value.Value, decimals) : value;
        }
    }
}
