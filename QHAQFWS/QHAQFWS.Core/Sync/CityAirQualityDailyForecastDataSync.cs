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
    public class CityAirQualityDailyForecastDataSync : SyncBase<Tab_City_Result_Info>
    {
        public CityAirQualityDailyForecastDataSync(QHAQFWSModel model) : base(model)
        {
        }

        protected override DateTime GetTime()
        {
            return DateTime.Today;
        }

        protected override DateTime GetStartTime(DateTime time)
        {
            return time.AddHours(9);
        }

        protected override List<Tab_City_Result_Info> GetSyncData(DateTime time)
        {
            List<Tab_City_Result_Info> list = new List<Tab_City_Result_Info>();
            List<City_Result_State> states = Model.City_Result_State.Where(o => o.Create_Date == time).ToList();
            DateTime prevDay = time.AddDays(-1);
            foreach (City_Result_State state in states)
            {
                List<Tab_City_Result_Info> oldList = Model.Tab_City_Result_Info.Where(o => o.CityCode == state.CityCode && o.Publish_Date == prevDay).ToList();
                for (int i = 0; i < 15; i++)
                {
                    DateTime forecastDate = time.AddDays(i);
                    Tab_City_Result_Info old = oldList.FirstOrDefault(o => o.Forecast_Date == forecastDate);
                    Tab_City_Result_Info data;
                    if (old == null)
                    {
                        data = new Tab_City_Result_Info()
                        {
                            CityCode = state.CityCode,
                            Publish_Date = time,
                            Forecast_Date = forecastDate,
                            Create_Date = DateTime.Now,
                            State_TableID = state.ID,
                            Air_Quality_Level_Upper = "",
                            Primary_Pollutants = "",
                            Health_Guide = "",
                            Suggest_Measures = ""
                        };
                    }
                    else
                    {
                        data = new Tab_City_Result_Info()
                        {
                            CityCode = state.CityCode,
                            Publish_Date = time,
                            Forecast_Date = forecastDate,
                            Create_Date = DateTime.Now,
                            State_TableID = state.ID,
                            Air_Quality_Level_Upper = old.Air_Quality_Level_Upper,
                            Primary_Pollutants = old.Primary_Pollutants,
                            Health_Guide = old.Health_Guide,
                            Suggest_Measures = old.Suggest_Measures,
                            AQI_Value_Lower = old.AQI_Value_Lower,
                            AQI_Value_Upper = old.AQI_Value_Upper,
                            PM2_5_Lower = old.PM2_5_Lower,
                            PM2_5_Upper = old.PM2_5_Upper,
                            PM10_Lower = old.PM10_Lower,
                            PM10_Upper = old.PM10_Upper,
                            SO2_Lower = old.SO2_Lower,
                            SO2_Upper = old.SO2_Upper,
                            NO2_Lower = old.NO2_Lower,
                            NO2_Upper = old.NO2_Upper,
                            O3_8H_Lower = old.O3_8H_Lower,
                            O3_8H_Upper = old.O3_8H_Upper,
                            CO_Lower = old.CO_Lower,
                            CO_Upper = old.CO_Upper
                        };
                    }
                    list.Add(data);
                }
            }
            return list;
        }

        protected override bool IsSynchronized(DateTime time)
        {
            return Model.Tab_City_Result_Info.FirstOrDefault(o => o.Publish_Date == time) != null;
        }

        protected override void RemoveData(DateTime time)
        {
            IQueryable<Tab_City_Result_Info> list = Model.Tab_City_Result_Info.Where(o => o.Publish_Date == time);
            if (list.Any())
            {
                Model.Tab_City_Result_Info.RemoveRange(list);
            }
        }
    }
}
