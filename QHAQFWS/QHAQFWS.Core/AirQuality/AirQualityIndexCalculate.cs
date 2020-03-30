using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Core.AirQuality
{
    /// <summary>
    /// 空气质量指数计算类
    /// </summary>
    public class AirQualityIndexCalculate : IAirQualityIndexCalculate
    {
        /// <summary>
        /// 二氧化硫（SO2）平均浓度（μg/m³）
        /// </summary>
        public decimal? SO2 { get; set; }
        /// <summary>
        /// 二氧化氮（NO2）平均浓度（μg/m³）
        /// </summary>
        public decimal? NO2 { get; set; }
        /// <summary>
        /// 颗粒物（粒径小于等于10μm）平均浓度（μg/m³）
        /// </summary>
        public decimal? PM10 { get; set; }
        /// <summary>
        /// 一氧化碳（CO）平均浓度（mg/m³）
        /// </summary>
        public decimal? CO { get; set; }
        /// <summary>
        /// 臭氧（O3）平均浓度（μg/m³）
        /// </summary>
        public decimal? O3 { get; set; }
        /// <summary>
        /// 颗粒物（粒径小于等于2.5μm）平均浓度（μg/m³）
        /// </summary>
        public decimal? PM25 { get; set; }
        /// <summary>
        /// 空气质量指数
        /// </summary>
        public decimal? AQI { get; set; }
        /// <summary>
        /// 首要污染物
        /// </summary>
        public string PrimaryPollutant { get; set; }
        /// <summary>
        /// 空气质量指数类别
        /// </summary>
        public string Type { get; set; }
    }
}
