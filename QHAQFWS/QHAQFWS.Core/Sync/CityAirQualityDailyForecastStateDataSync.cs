using QHAQFWS.Core.Sync.Base;
using QHAQFWS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Core.Sync
{
    public class CityAirQualityDailyForecastStateDataSync : SyncBase<City_Result_State>
    {
        public CityAirQualityDailyForecastStateDataSync(QHAQFWSModel model) : base(model)
        {

        }

        protected override DateTime GetTime()
        {
            return DateTime.Today;
        }

        protected override DateTime GetStartTime(DateTime time)
        {
            return time;
        }

        protected override List<City_Result_State> GetSyncData(SyncDataQueue queue)
        {
            List<City_Result_State> list = new List<City_Result_State>();
            List<Regional_Code> regionalCodes = Model.Regional_Code.Where(o => o.Status == 1).ToList();
            foreach (Regional_Code regionalCode in regionalCodes)
            {
                City_Result_State data = new City_Result_State()
                {
                    CityCode = regionalCode.Area_Code,
                    Create_Date = queue.Time,
                    Step_Key = "8000",
                    Is_Modifying = 0,
                    Is_Agreed = 0,
                    Apply_Count = 0,
                    IsSubmit = false,
                    IsProvinceEdit = false,
                    IsLateUnload = false,
                    IsNoUnload = false
                };
                list.Add(data);
            }
            return list;
        }

        protected override bool IsSynchronized(DateTime time)
        {
            return Model.City_Result_State.FirstOrDefault(o => o.Create_Date == time) != null;
        }
    }
}
