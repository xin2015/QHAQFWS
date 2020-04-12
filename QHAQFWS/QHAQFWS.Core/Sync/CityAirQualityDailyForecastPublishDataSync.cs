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

        protected override DateTime GetEndTime(DateTime time)
        {
            return time.AddYears(30);
        }

        protected override List<Tab_City_Result_Info_Publish> GetSyncData(SyncDataQueue queue)
        {
            List<Tab_City_Result_Info_Publish> list = new List<Tab_City_Result_Info_Publish>();
            
            return list;
        }

        protected override bool IsSynchronized(DateTime time)
        {
            return Model.Tab_City_Result_Info_Publish.FirstOrDefault(o => o.Publish_Date == time) != null;
        }
    }
}
