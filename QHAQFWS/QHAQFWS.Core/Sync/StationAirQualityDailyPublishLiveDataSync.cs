using QHAQFWS.Basic.Extensions;
using QHAQFWS.Core.AirQuality;
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
    public class StationAirQualityDailyPublishLiveDataSync : SyncBase<Air_StationAQIHistory_Day_Pub>
    {
        public List<Station> StationList { get; set; }

        public StationAirQualityDailyPublishLiveDataSync(QHAQFWSModel model) : base(model)
        {
            StationList = Model.Station.Where(o => o.Status && o.Area != "未知城市").ToList();
        }

        protected override List<Air_StationAQIHistory_Day_Pub> GetSyncData(DateTime time)
        {
            List<Air_StationAQIHistory_Day_Pub> list = new List<Air_StationAQIHistory_Day_Pub>();
            using (MeteorologyDataClient client = new MeteorologyDataClient())
            {
                StationHourData[] srcList = client.GetStationHourDataHistory(time.AddDays(1), time.AddDays(1));
                foreach (StationHourData src in srcList)
                {
                    Station station = Model.Station.FirstOrDefault(o => o.StationCode == src.StationCode);
                    if (station != null)
                    {
                        Air_StationAQIHistory_Day_Pub data = new Air_StationAQIHistory_Day_Pub()
                        {
                            TimePoint = time,
                            Area = station.Area,
                            CityCode = station.DistrictCode.Value,
                            UniqueCode = station.UniqueCode,
                            PositionName = station.PositionName,
                            CO_24h = src.CO_24h,
                            NO2_24h = src.NO2_24h,
                            O3_8h_24h = src.O3_8h,
                            PM10_24h = src.PM10_24h,
                            PM2_5_24h = src.PM2_5_24h,
                            SO2_24h = src.SO2_24h,
                            CreatetTime = DateTime.Now,
                            UpdateTime = DateTime.Now,
                        };
                        AirQualityIndexCalculate calculate = new AirQualityIndexCalculate()
                        {
                            SO2 = data.SO2_24h.ToNullableDecimal(),
                            NO2 = data.NO2_24h.ToNullableDecimal(),
                            PM10 = data.PM10_24h.ToNullableDecimal(),
                            CO = data.CO_24h.ToNullableDecimal(),
                            O3 = data.O3_8h_24h.ToNullableDecimal(),
                            PM25 = data.PM2_5_24h.ToNullableDecimal()
                        };
                        DailyAirQualityIndexCalculator calculator = new DailyAirQualityIndexCalculator();
                        calculator.CalculateAirQualityIndex(calculate);
                        data.AQI = calculate.AQI.HasValue ? calculate.AQI.ToString() : NullValueString;
                        data.PrimaryPollutant = string.IsNullOrEmpty(calculate.PrimaryPollutant) ? NullValueString : calculate.PrimaryPollutant;
                        data.Quality = string.IsNullOrEmpty(calculate.Type) ? NullValueString : calculate.Type;
                        list.Add(data);
                    }
                }
            }
            return list;
        }

        protected override bool IsSynchronized(DateTime time)
        {
            return Model.Air_StationAQIHistory_Day_Pub.FirstOrDefault(o => o.TimePoint == time) != null;
        }

        protected override void RemoveData(DateTime time)
        {
            IQueryable<Air_StationAQIHistory_Day_Pub> list = Model.Air_StationAQIHistory_Day_Pub.Where(o => o.TimePoint == time);
            if (list.Any())
            {
                Model.Air_StationAQIHistory_Day_Pub.RemoveRange(list);
            }
        }
    }
}
