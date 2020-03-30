﻿using QHAQFWS.Core.QHDataService;
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
    public class CityAirQualityDailyApprovalStandardDataSync : SyncBase<Air_CityAQIHistory_Day_App_Std>
    {
        public CityAirQualityDailyApprovalStandardDataSync(QHAQFWSModel model) : base(model)
        {

        }

        protected override List<Air_CityAQIHistory_Day_App_Std> GetSyncData(SyncDataQueue queue)
        {
            List<Air_CityAQIHistory_Day_App_Std> list = new List<Air_CityAQIHistory_Day_App_Std>();
            using (DataServiceClient client = new DataServiceClient())
            {
                CityDaily[] srcList = client.GetCityDailyData(queue.Time, queue.Time, (int)AirQualityDataType.ApprovalStandard);
                foreach (CityDaily src in srcList)
                {
                    Air_CityAQIHistory_Day_App_Std data = new Air_CityAQIHistory_Day_App_Std()
                    {
                        TimePoint = queue.Time,
                        Area = src.CityName,
                        CityCode = Convert.ToInt32(src.CityCode),
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