using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Core.AirQuality
{
    /// <summary>
    /// 空气质量指数数据接口
    /// </summary>
    public interface IAirQualityIndex
    {
        /// <summary>
        /// 空气质量指数
        /// </summary>
        decimal? AQI { get; set; }
        /// <summary>
        /// 首要污染物
        /// </summary>
        string PrimaryPollutant { get; set; }
        /// <summary>
        /// 空气质量指数类别
        /// </summary>
        string Type { get; set; }
    }
}
