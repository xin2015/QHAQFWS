using QHAQFWS.Core.QHDataService;
using QHAQFWS.Core.Sync.Base;
using QHAQFWS.Core.Sync.QHDataService;
using QHAQFWS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Core.Sync
{
    public class StationAirQualityDailyApprovalLiveDataSync : SyncBase<Air_StationAQIHistory_Day_App>
    {
        public List<Station> StationList { get; set; }
        public StationAirQualityDailyApprovalLiveDataSync(QHAQFWSModel model) : base(model)
        {
            StationList = Model.Station.Where(o => o.Status && o.Area != "未知城市" && o.UniqueCode.StartsWith("63")).ToList();
        }

        protected override DateTime GetStartTime(DateTime time)
        {
            return time.AddDays(3);
        }

        protected override List<Air_StationAQIHistory_Day_App> GetSyncData(DateTime time)
        {
            List<Air_StationAQIHistory_Day_App> list = new List<Air_StationAQIHistory_Day_App>();
            using (DataServiceClient client = new DataServiceClient())
            {
                SiteDaily[] srcList = client.GetSiteDailyData(time, time, (int)AirQualityDataType.ApprovalLive);
                List<Air_StationAQIHistory_Day_App> existList = Model.Air_StationAQIHistory_Day_App.Where(o => o.TimePoint == time).ToList();
                foreach (SiteDaily src in srcList)
                {
                    Station station = StationList.FirstOrDefault(o => o.UniqueCode == src.SiteCode);
                    if (station != null && !existList.Any(o => o.UniqueCode == station.UniqueCode))
                    {
                        Air_StationAQIHistory_Day_App data = new Air_StationAQIHistory_Day_App()
                        {
                            TimePoint = time,
                            Area = station.Area,
                            CityCode = station.DistrictCode.Value,
                            UniqueCode = station.UniqueCode,
                            PositionName = station.PositionName,
                            SO2_24h = Format(src.SO2, 1000),
                            NO2_24h = Format(src.NO2, 1000),
                            PM10_24h = Format(src.PM10, 1000),
                            CO_24h = Format(src.CO),
                            O3_8h_24h = Format(src.O3_8h, 1000),
                            PM2_5_24h = Format(src.PM2_5, 1000),
                            AQI = Format(src.AQI),
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
            return Model.Air_StationAQIHistory_Day_App.Count(o => o.TimePoint == time) + 15 > StationList.Count;
        }

        protected override void RemoveData(DateTime time)
        {
            IQueryable<Air_StationAQIHistory_Day_App> list = Model.Air_StationAQIHistory_Day_App.Where(o => o.TimePoint == time);
            if (list.Any())
            {
                Model.Air_StationAQIHistory_Day_App.RemoveRange(list);
            }
        }
    }
}
