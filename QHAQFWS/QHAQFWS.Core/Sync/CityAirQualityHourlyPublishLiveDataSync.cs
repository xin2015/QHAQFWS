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
    public class CityAirQualityHourlyPublishLiveDataSync : SyncBase<Air_CityAQIHistory_H_Pub>
    {
        public CityAirQualityHourlyPublishLiveDataSync(QHAQFWSModel model) : base(model)
        {
        }

        protected override DateTime GetTime()
        {
            return DateTime.Today.AddHours(DateTime.Now.Hour);
        }

        protected override DateTime GetStartTime(DateTime time)
        {
            return time.AddMinutes(28);
        }

        protected override DateTime GetNextTime(DateTime time)
        {
            return time.AddHours(1);
        }

        protected override List<Air_CityAQIHistory_H_Pub> GetSyncData(SyncDataQueue queue)
        {
            List<Air_CityAQIHistory_H_Pub> list = new List<Air_CityAQIHistory_H_Pub>();
            using (MeteorologyDataClient client = new MeteorologyDataClient())
            {
                CityHourData[] srcList = client.GetCityHourDataHistory(queue.Time, queue.Time);
                foreach (CityHourData src in srcList)
                {
                    Air_CityAQIHistory_H_Pub data = new Air_CityAQIHistory_H_Pub()
                    {
                        TimePoint = src.TimePoint,
                        Area = src.Area,
                        CityCode = src.CityCode,
                        CO = src.CO,
                        NO2 = src.NO2,
                        O3 = src.O3,
                        PM10 = src.PM10,
                        PM2_5 = src.PM2_5,
                        SO2 = src.SO2,
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

        protected override bool IsSynchronized(DateTime time)
        {
            return Model.Air_CityAQIHistory_H_Pub.FirstOrDefault(o => o.TimePoint == time) != null;
        }
    }
}
