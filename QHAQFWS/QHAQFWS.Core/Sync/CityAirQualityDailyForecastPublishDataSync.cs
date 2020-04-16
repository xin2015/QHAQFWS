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
    public class CityAirQualityDailyForecastPublishDataSync : SyncBase<Tab_City_Result_Info_Publish>
    {
        public CityAirQualityDailyForecastPublishDataSync(QHAQFWSModel model) : base(model)
        {
        }

        protected override DateTime GetTime()
        {
            return DateTime.Today;
        }

        protected override DateTime GetStartTime(DateTime time)
        {
            return time.AddHours(10);
        }

        protected override List<Tab_City_Result_Info_Publish> GetSyncData(SyncDataQueue queue)
        {
            List<Tab_City_Result_Info_Publish> list = new List<Tab_City_Result_Info_Publish>();
            List<Tab_City_Result_Info> srcList = Model.Tab_City_Result_Info.Where(o => o.Publish_Date == queue.Time).ToList();
            foreach (Tab_City_Result_Info src in srcList)
            {
                Tab_City_Result_Info_Publish data = new Tab_City_Result_Info_Publish()
                {
                    CityCode = src.CityCode,
                    Publish_Date = src.Publish_Date,
                    Forecast_Date = src.Forecast_Date,
                    Create_Date = DateTime.Now,
                    Air_Quality_Level_Upper = src.Air_Quality_Level_Upper,
                    Primary_Pollutants = src.Primary_Pollutants,
                    AQI_Value_Upper = src.AQI_Value_Upper,
                    AQI_Value_Lower = src.AQI_Value_Lower,
                    PM2_5_Upper = src.PM2_5_Upper,
                    PM2_5_Lower = src.PM2_5_Lower,
                    Linkman_ID = src.Linkman_ID,
                    Table_Id = src.State_TableID,
                    PM10_Upper = src.PM10_Upper,
                    PM10_Lower = src.PM10_Lower,
                    SO2_Upper = src.SO2_Upper,
                    SO2_Lower = src.SO2_Lower,
                    NO2_Upper = src.NO2_Upper,
                    NO2_Lower = src.NO2_Lower,
                    O3_8H_Upper = src.O3_8H_Upper,
                    O3_8H_Lower = src.O3_8H_Lower,
                    CO_Upper = src.CO_Upper,
                    CO_Lower = src.CO_Lower
                };
                list.Add(data);
            }
            return list;
        }

        protected override bool IsSynchronized(DateTime time)
        {
            return Model.Tab_City_Result_Info_Publish.FirstOrDefault(o => o.Publish_Date == time) != null;
        }
    }
}
