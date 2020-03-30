using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Core.AirQuality
{
    /// <summary>
    /// 空气质量指数计算器
    /// </summary>
    public abstract class AirQualityIndexCalculator : BaseAirQualityCalculator
    {
        protected decimal[] AQILimits { get; set; }
        protected Dictionary<string, decimal[]> PollutantConcentrationLimitsDic { get; set; }
        protected decimal PrimaryPollutantLimit { get; set; }
        protected decimal NonAttainmentPollutantLimit { get; set; }
        protected string[] AirQualityTypes { get; set; }

        public AirQualityIndexCalculator()
        {
            AQILimits = new decimal[] { 0, 50, 100, 150, 200, 300, 400, 500 };
            PollutantConcentrationLimitsDic = new Dictionary<string, decimal[]>();
            PollutantConcentrationLimitsDic.Add("PM10", new decimal[] { 0, 50, 150, 250, 350, 420, 500, 600 });
            PollutantConcentrationLimitsDic.Add("PM25", new decimal[] { 0, 35, 75, 115, 150, 250, 350, 500 });
            PrimaryPollutantLimit = 50;
            NonAttainmentPollutantLimit = 100;
            AirQualityTypes = new string[] { "优", "良", "轻度污染", "中度污染", "重度污染", "严重污染" };
        }

        #region 私有方法
        protected virtual decimal CalculateAirQualityIndividualIndex(decimal[] pollutantConcentrationLimits, decimal value)
        {
            for (int i = 1; i < pollutantConcentrationLimits.Length; i++)
            {
                if (value <= pollutantConcentrationLimits[i])
                {
                    return Math.Ceiling((AQILimits[i] - AQILimits[i - 1]) * (value - pollutantConcentrationLimits[i - 1]) / (pollutantConcentrationLimits[i] - pollutantConcentrationLimits[i - 1])) + AQILimits[i - 1];
                }
            }
            return 500;
        }

        protected virtual decimal CalculateAirQualityIndividualIndex2(decimal[] pollutantConcentrationLimits, decimal value)
        {
            decimal pollutantConcentrationLimitPrev = pollutantConcentrationLimits[0];
            decimal AQILimitPrev = AQILimits[0];
            for (int i = 1; i < pollutantConcentrationLimits.Length; i++)
            {
                if (value <= pollutantConcentrationLimits[i])
                {
                    return Math.Ceiling((AQILimits[i] - AQILimitPrev) * (value - pollutantConcentrationLimitPrev) / (pollutantConcentrationLimits[i] - pollutantConcentrationLimitPrev)) + AQILimitPrev;
                }
                pollutantConcentrationLimitPrev = pollutantConcentrationLimits[i];
                AQILimitPrev = AQILimits[i];
            }
            return 500;
        }

        protected virtual Dictionary<string, decimal> CalculateAirQualityIndividualIndexDic(Dictionary<string, decimal?> data)
        {
            Dictionary<string, decimal> airQualityIndividualIndexDic = new Dictionary<string, decimal>();
            foreach (var item in data)
            {
                if (Validate(item.Value))
                {
                    decimal[] pollutantConcentrationLimits = PollutantConcentrationLimitsDic[item.Key];
                    if (pollutantConcentrationLimits.Length == 8 || item.Value <= pollutantConcentrationLimits.Last())
                    {
                        airQualityIndividualIndexDic.Add(item.Key, CalculateAirQualityIndividualIndex(pollutantConcentrationLimits, item.Value.Value));
                    }
                }
            }
            return airQualityIndividualIndexDic;
        }

        protected virtual int CalculateAirQualityTypeIndex(decimal aqi)
        {
            for (int i = 5; i >= 0; i--)
            {
                if (aqi > AQILimits[i])
                {
                    return i;
                }
            }
            return 0;
        }

        protected virtual string CalculateAirQualityType(decimal aqi)
        {
            int index = CalculateAirQualityTypeIndex(aqi);
            return AirQualityTypes[index];
        }

        protected virtual void CalculateAirQualityIndex(IAirQualityIndex airQualityIndex, Dictionary<string, decimal> airQualityIndividualIndexDic)
        {
            if (airQualityIndividualIndexDic.Count > 0)
            {
                decimal max = airQualityIndividualIndexDic.Max(o => o.Value);
                bool calculate = CheckIntegrity ? (airQualityIndividualIndexDic.Count == 6 || max > NonAttainmentPollutantLimit) : true;
                if (calculate)
                {
                    airQualityIndex.AQI = max;
                    if (max > PrimaryPollutantLimit)
                    {
                        airQualityIndex.PrimaryPollutant = string.Join(",", airQualityIndividualIndexDic.Where(o => o.Value == max).Select(o => PrimaryPollutantDic[o.Key]));
                    }
                    airQualityIndex.Type = CalculateAirQualityType(max);
                }
            }
        }
        #endregion

        #region 公有方法
        public virtual void CalculateAirQualityIndex(IAirQualityIndexCalculate data)
        {
            Dictionary<string, decimal> airQualityIndividualIndexDic = CalculateAirQualityIndividualIndexDic(data);
            CalculateAirQualityIndex(data, airQualityIndividualIndexDic);
        }

        public virtual Dictionary<string, decimal> CalculateAirQualityIndividualIndexDic(IAirQualityIndexCalculate data)
        {
            Dictionary<string, decimal?> dic = ToDictionary(data);
            return CalculateAirQualityIndividualIndexDic(dic);
        }
        #endregion
    }
}
