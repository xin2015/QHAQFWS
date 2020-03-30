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
    public class StationAirQualityHourlySourceStandardDataSync : SyncBase<Air_StationAQIHistory_H_Src_Std>
    {
        public List<Station> StationList { get; set; }
        public StationAirQualityHourlySourceStandardDataSync(QHAQFWSModel model) : base(model)
        {
            StationList = Model.Station.Where(o => o.Status && o.Area != "未知城市" && o.UniqueCode.StartsWith("63")).ToList();
        }

        protected override void Sync(SyncDataQueue queue)
        {
            List<Air_StationAQIHistory_H_Src_Std> list = GetSyncData(queue);
            if (list.Count + 15 >= StationList.Count)
            {
                Model.Set<Air_StationAQIHistory_H_Src_Std>().AddRange(list);
            }
            else
            {
                throw new Exception("数据获取失败！");
            }
        }

        protected override List<Air_StationAQIHistory_H_Src_Std> GetSyncData(SyncDataQueue queue)
        {
            List<Air_StationAQIHistory_H_Src_Std> list = new List<Air_StationAQIHistory_H_Src_Std>();
            using (DataServiceClient client = new DataServiceClient())
            {
                SiteDaily[] srcList = client.GetSiteHoursData(queue.Time, queue.Time, (int)AirQualityDataType.SourceStandard);
                foreach (SiteDaily src in srcList)
                {
                    Station station = StationList.FirstOrDefault(o => o.UniqueCode == src.SiteCode);
                    if (station != null)
                    {
                        Air_StationAQIHistory_H_Src_Std data = new Air_StationAQIHistory_H_Src_Std()
                        {
                            TimePoint = queue.Time,
                            Area = station.Area,
                            CityCode = station.DistrictCode.Value,
                            UniqueCode = station.UniqueCode,
                            PositionName = station.PositionName,
                            SO2 = Format(src.SO2, 1000),
                            NO2 = Format(src.NO2, 1000),
                            PM10 = Format(src.PM10, 1000),
                            CO = Format(src.CO),
                            O3 = Format(src.O3, 1000),
                            PM2_5 = Format(src.PM2_5, 1000),
                            SO2Mark = src.SO2_Mark,
                            NO2Mark = src.NO2_Mark,
                            PM10Mark = src.PM10_Mark,
                            COMark = src.CO_Mark,
                            O3Mark = src.O3_Mark,
                            PM2_5Mark = src.PM2_5_Mark,
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

        protected override DateTime GetTime()
        {
            return DateTime.Today.AddHours(DateTime.Now.Hour);
        }

        protected override DateTime GetStartTime(DateTime time)
        {
            return time.AddMinutes(10);
        }

        protected override DateTime GetEndTime(DateTime time)
        {
            return time.AddYears(30);
        }

        protected override DateTime GetNextTime(DateTime time)
        {
            return time.AddHours(1);
        }
    }
}
