using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Core.AirQuality
{
    /// <summary>
    /// 空气质量基本评价项目浓度值/百分位数数据接口
    /// </summary>
    public interface IAirQualityPollutantConcentration
    {
        /// <summary>
        /// 二氧化硫（SO2）平均浓度（μg/m³）/第98百分位数
        /// </summary>
        decimal? SO2 { get; set; }
        /// <summary>
        /// 二氧化氮（NO2）平均浓度（μg/m³）/第98百分位数
        /// </summary>
        decimal? NO2 { get; set; }
        /// <summary>
        /// 颗粒物（粒径小于等于10μm）平均浓度（μg/m³）/第95百分位数
        /// </summary>
        decimal? PM10 { get; set; }
        /// <summary>
        /// 一氧化碳（CO）平均浓度（mg/m³）/第95百分位数
        /// </summary>
        decimal? CO { get; set; }
        /// <summary>
        /// 臭氧（O3）平均浓度（μg/m³）/第90百分位数
        /// </summary>
        decimal? O3 { get; set; }
        /// <summary>
        /// 颗粒物（粒径小于等于2.5μm）平均浓度（μg/m³）/第95百分位数
        /// </summary>
        decimal? PM25 { get; set; }
    }
}
