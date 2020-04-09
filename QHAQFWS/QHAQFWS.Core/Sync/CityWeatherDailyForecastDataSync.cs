using QHAQFWS.Core.MeteorologyDataService;
using QHAQFWS.Core.Sync.Base;
using QHAQFWS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Core.Sync
{
    public class CityWeatherDailyForecastDataSync : SyncBase<City_WeatherForeastInfo>
    {
        protected Dictionary<string, string> CityDic;
        public CityWeatherDailyForecastDataSync(QHAQFWSModel model) : base(model)
        {
            CityDic = new Dictionary<string, string>();
            CityDic.Add("101150101", "西宁市");
            CityDic.Add("101150202", "海东市");
            CityDic.Add("101150301", "黄南藏族自治州");
            CityDic.Add("101150409", "海南藏族自治州");
            CityDic.Add("101150508", "果洛藏族自治州");
            CityDic.Add("101150601", "玉树藏族自治州");
            CityDic.Add("101150716", "海西蒙古族藏族自治州");
            CityDic.Add("101150804", "海北藏族自治州");
        }

        protected override DateTime GetTime()
        {
            return DateTime.Today;
        }

        protected override DateTime GetStartTime(DateTime time)
        {
            return time.AddHours(8);
        }

        protected override DateTime GetEndTime(DateTime time)
        {
            return time.AddYears(30);
        }

        protected override List<City_WeatherForeastInfo> GetSyncData(SyncDataQueue queue)
        {
            List<City_WeatherForeastInfo> list = new List<City_WeatherForeastInfo>();
            using (MeteorologyDataClient client = new MeteorologyDataClient())
            {
                City_WeatherForecastInfo[] srcList = client.GetDayForecastData(CityDic.Keys.ToArray(), queue.Time, queue.Time);
                List<City_WeatherForeastInfo> existList = Model.City_WeatherForeastInfo.Where(o => o.Timepoint == queue.Time).ToList();
                foreach (City_WeatherForecastInfo src in srcList)
                {
                    if (!existList.Any(o => o.CityCode == src.CityCode && o.ForTime == src.ForTime))
                    {
                        City_WeatherForeastInfo data = new City_WeatherForeastInfo()
                        {
                            Timepoint = src.TimePoint,
                            ForTime = src.ForTime,
                            CreateTime = DateTime.Now,
                            CityName = CityDic[src.CityCode],
                            CityCode = src.CityCode,
                            WindDirection = src.WindDirection,
                            WindSpeed = src.WindSpeed,
                            AirPress = src.AirPress,
                            AirTemp = src.AirTemp,
                            High_AirTemp = src.Day_AirTemp,
                            Low_High_AirTemp = src.Night_AirTemp,
                            Day_Condition = src.Day_Condition,
                            Night_Condition = src.Night_Condition,
                            DayWindDirection = src.Day_WindDirection,
                            NightWindDirection = src.Night_WindDirection,
                            DayWindSpeed = src.Day_WindSpeed,
                            NightWindSpeed = src.Night_WindSpeed,
                            RelativeHumidity = src.RelativeHumidity,
                            CloundCover = src.CloundCover,
                            Visibility = src.Visibility,
                            RainFall = src.RainFall
                        };
                        list.Add(data);
                    }
                }
            }
            return list;
        }

        protected override bool IsSynchronized(DateTime time)
        {
            return Model.City_WeatherForeastInfo.Count(o => o.Timepoint == time) == CityDic.Count * 7;
        }
    }
}
