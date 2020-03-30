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
    public class CityAirQualityDailyPublishLiveDataSync : SyncBase<Air_CityAQIHistory_Day_Pub>
    {
        public CityAirQualityDailyPublishLiveDataSync(QHAQFWSModel model) : base(model)
        {
        }

        protected override List<Air_CityAQIHistory_Day_Pub> GetSyncData(SyncDataQueue queue)
        {
            List<Air_CityAQIHistory_Day_Pub> list = new List<Air_CityAQIHistory_Day_Pub>();
            using (MeteorologyDataClient client = new MeteorologyDataClient())
            {
                CityDayData[] srcList = client.GetCityDayDataHistory(queue.Time, queue.Time);
                foreach (CityDayData src in srcList)
                {
                    Air_CityAQIHistory_Day_Pub data = new Air_CityAQIHistory_Day_Pub()
                    {
                        TimePoint = src.TimePoint,
                        Area = src.Area,
                        CityCode = src.CityCode,
                        CO_24h = src.CO_24h,
                        NO2_24h = src.NO2_24h,
                        O3_8h_24h = src.O3_8h_24h,
                        PM10_24h = src.PM10_24h,
                        PM2_5_24h = src.PM2_5_24h,
                        SO2_24h = src.SO2_24h,
                        AQI = src.AQI,
                        PrimaryPollutant = src.PrimaryPollutant,
                        Quality = src.Quality,
                        Measure = src.Measure,
                        Unheathful = src.Unheathful,
                        CreatetTime = DateTime.Now,
                        UpdateTime = DateTime.Now
                    };
                    list.Add(data);
                }
            }
            return list;
        }

        protected override DateTime GetEndTime(DateTime time)
        {
            return time.AddYears(30);
        }
    }
}
