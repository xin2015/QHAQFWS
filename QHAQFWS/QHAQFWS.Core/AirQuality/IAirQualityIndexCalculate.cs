using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Core.AirQuality
{
    /// <summary>
    /// 空气质量指数计算接口
    /// </summary>
    public interface IAirQualityIndexCalculate : IAirQualityPollutantConcentration, IAirQualityIndex
    {
    }
}
