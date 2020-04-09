using QHAQFWS.Basic.Extensions;
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
    public class CityAirQualityDailyForecastCountryPublishDataSync : SyncBase<Tab_City_Result_Info_Publish>
    {
        public CityAirQualityDailyForecastCountryPublishDataSync(QHAQFWSModel model) : base(model)
        {
        }

        protected override DateTime GetTime()
        {
            return DateTime.Now.Hour <= 9 ? DateTime.Today.AddHours(9) : DateTime.Today.AddHours(17);
        }

        protected override DateTime GetStartTime(DateTime time)
        {
            return time;
        }

        protected override DateTime GetEndTime(DateTime time)
        {
            return time.AddYears(30);
        }

        protected override List<Tab_City_Result_Info_Publish> GetSyncData(SyncDataQueue queue)
        {
            List<Tab_City_Result_Info_Publish> list = new List<Tab_City_Result_Info_Publish>();
            using (MeteorologyDataClient client = new MeteorologyDataClient())
            {
                DateTime date = queue.Time.Hour == 9 ? queue.Time.Date.AddDays(-1) : queue.Time.Date;
                NationCityPollutantForecast[] srcList = client.GetCityPollutantForecast(date).Where(o => o.CityCode.Contains("63")).ToArray();
                foreach (var cityGroup in srcList.GroupBy(o => o.CityCode))
                {
                    IQueryable<Tab_City_Result_Info_Publish> existList = Model.Tab_City_Result_Info_Publish.Where(o => o.CityCode == cityGroup.Key && o.Publish_Date == date);
                    Model.Tab_City_Result_Info_Publish.RemoveRange(existList);
                    foreach (NationCityPollutantForecast src in cityGroup)
                    {
                        Tab_City_Result_Info_Publish data = new Tab_City_Result_Info_Publish()
                        {
                            AQI_Value_Lower = src.AQILow.ToNullableInt(),
                            AQI_Value_Upper = src.AQIHigh.ToNullableInt(),
                            CityCode = src.CityCode,
                            Health_Guide = src.HealthTips,
                            Publish_Date = src.PublishDate,
                            Create_Date = src.ReceiveTime,
                            Air_Quality_Level_Upper = src.AQILevel,
                            Forecast_Date = src.PublishDate.AddDays(src.ForecastType),
                            InscribeInfo = src.DetailInfo,
                            Primary_Pollutants = src.PrimaryPollutant,
                        };
                        list.Add(data);
                    }
                }
            }
            return list;
        }

        protected override bool IsSynchronized(DateTime time)
        {
            DateTime date = time.Hour == 9 ? time.Date.AddDays(-1) : time.Date;
            return Model.Tab_City_Result_Info_Publish.FirstOrDefault(o => o.Publish_Date == date) != null;
        }
    }
}
