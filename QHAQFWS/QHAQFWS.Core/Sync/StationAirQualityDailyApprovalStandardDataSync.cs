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
    public class StationAirQualityDailyApprovalStandardDataSync : SyncBase<Air_StationAQIHistory_Day_App_Std>
    {
        public List<Station> StationList { get; set; }
        public StationAirQualityDailyApprovalStandardDataSync(QHAQFWSModel model) : base(model)
        {
            StationList = Model.Station.Where(o => o.Status && o.Area != "未知城市" && o.UniqueCode.StartsWith("63")).ToList();
        }

        protected override void Sync(SyncDataQueue queue)
        {
            List<Air_StationAQIHistory_Day_App_Std> list = GetSyncData(queue);
            if (list.Count + 15 >= StationList.Count)
            {
                Model.Set<Air_StationAQIHistory_Day_App_Std>().AddRange(list);
            }
            else
            {
                throw new Exception("数据获取失败！");
            }
        }

        protected override List<Air_StationAQIHistory_Day_App_Std> GetSyncData(SyncDataQueue queue)
        {
            List<Air_StationAQIHistory_Day_App_Std> list = new List<Air_StationAQIHistory_Day_App_Std>();
            using (DataServiceClient client = new DataServiceClient())
            {
                SiteDaily[] srcList = client.GetSiteDailyData(queue.Time, queue.Time, (int)AirQualityDataType.ApprovalStandard);
                foreach (SiteDaily src in srcList)
                {
                    Station station = StationList.FirstOrDefault(o => o.UniqueCode == src.SiteCode);
                    if (station != null)
                    {
                        Air_StationAQIHistory_Day_App_Std data = new Air_StationAQIHistory_Day_App_Std()
                        {
                            TimePoint = queue.Time,
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

        protected override DateTime GetStartTime(DateTime time)
        {
            return time.AddDays(3);
        }

        protected override DateTime GetEndTime(DateTime time)
        {
            return time.AddYears(30);
        }
    }
}
