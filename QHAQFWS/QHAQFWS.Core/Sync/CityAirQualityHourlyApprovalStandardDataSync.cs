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
    public class CityAirQualityHourlyApprovalStandardDataSync : SyncBase<Air_CityAQIHistory_H_App_Std>
    {
        public CityAirQualityHourlyApprovalStandardDataSync(QHAQFWSModel model) : base(model)
        {

        }

        protected override List<Air_CityAQIHistory_H_App_Std> GetSyncData(SyncDataQueue queue)
        {
            List<Air_CityAQIHistory_H_App_Std> list = new List<Air_CityAQIHistory_H_App_Std>();
            using (DataServiceClient client = new DataServiceClient())
            {
                CityDaily[] srcList = client.GetCityHoursData(queue.Time, queue.Time, (int)AirQualityDataType.ApprovalStandard);
                foreach (CityDaily src in srcList)
                {
                    Air_CityAQIHistory_H_App_Std data = new Air_CityAQIHistory_H_App_Std()
                    {
                        TimePoint = queue.Time,
                        Area = src.CityName,
                        CityCode = Convert.ToInt32(src.CityCode),
                        SO2 = Format(src.SO2, 1000),
                        NO2 = Format(src.NO2, 1000),
                        PM10 = Format(src.PM10, 1000),
                        CO = Format(src.CO),
                        O3 = Format(src.O3, 1000),
                        PM2_5 = Format(src.PM2_5, 1000),
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

        protected override DateTime GetTime()
        {
            return DateTime.Today.AddHours(DateTime.Now.Hour);
        }

        protected override DateTime GetStartTime(DateTime time)
        {
            return time.AddDays(3).AddMinutes(20);
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
