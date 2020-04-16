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
    public class StationAirQualityHourlyPublishLiveDataSync : SyncBase<Air_StationAQIHistory_H_Pub>
    {
        public List<Station> StationList { get; set; }

        public StationAirQualityHourlyPublishLiveDataSync(QHAQFWSModel model) : base(model)
        {
            StationList = Model.Station.Where(o => o.Status && o.Area != "未知城市").ToList();
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

        protected override List<Air_StationAQIHistory_H_Pub> GetSyncData(DateTime time)
        {
            List<Air_StationAQIHistory_H_Pub> list = new List<Air_StationAQIHistory_H_Pub>();
            using (MeteorologyDataClient client = new MeteorologyDataClient())
            {
                StationHourData[] srcList = client.GetStationHourDataHistory(time, time);
                foreach (StationHourData src in srcList)
                {
                    Station station = StationList.FirstOrDefault(o => o.StationCode == src.StationCode);
                    if (station != null)
                    {
                        Air_StationAQIHistory_H_Pub data = new Air_StationAQIHistory_H_Pub()
                        {
                            TimePoint = time,
                            Area = station.Area,
                            CityCode = station.DistrictCode.Value,
                            UniqueCode = station.UniqueCode,
                            PositionName = station.PositionName,
                            CO = src.CO,
                            NO2 = src.NO2,
                            O3 = src.O3_24h,
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
            }
            return list;
        }

        protected override bool IsSynchronized(DateTime time)
        {
            return Model.Air_StationAQIHistory_H_Pub.FirstOrDefault(o => o.TimePoint == time) != null;
        }

        protected override void RemoveData(DateTime time)
        {
            IQueryable<Air_StationAQIHistory_H_Pub> list = Model.Air_StationAQIHistory_H_Pub.Where(o => o.TimePoint == time);
            if (list.Any())
            {
                Model.Air_StationAQIHistory_H_Pub.RemoveRange(list);
            }
        }
    }
}
