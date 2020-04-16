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
    public class CityWeatherDailyDataSync : SyncBase<Weather_D_SpiData>
    {
        protected Dictionary<string, string> CityDic;
        public CityWeatherDailyDataSync(QHAQFWSModel model) : base(model)
        {
            CityDic = new Dictionary<string, string>();
            CityDic.Add("101150101", "西宁市");
            CityDic.Add("101150202", "海东市");
            CityDic.Add("101150301", "黄南藏族自治州");
            CityDic.Add("101150409", "海南藏族自治州");
            CityDic.Add("101150508", "果洛藏族自治州");
            CityDic.Add("101150601", "玉树藏族自治州");
            CityDic.Add("101150716", "海西蒙古族藏族自治州");
            CityDic.Add("101150804", "海北藏族自治州");
        }

        protected override DateTime GetStartTime(DateTime time)
        {
            return time.AddDays(1).AddHours(8);
        }

        protected override List<Weather_D_SpiData> GetSyncData(DateTime time)
        {
            List<Weather_D_SpiData> list = new List<Weather_D_SpiData>();
            using (MeteorologyDataClient client = new MeteorologyDataClient())
            {
                Weather_D_SpiDatum[] srcList = client.GetDaySpiData(CityDic.Keys.ToArray(), time, time);
                foreach (Weather_D_SpiDatum src in srcList)
                {
                    Weather_D_SpiData data = new Weather_D_SpiData()
                    {
                        TimePoint = src.TimePoint,
                        CreateTime = DateTime.Now,
                        CityName = CityDic[src.CityCode],
                        WindDirection = src.WindDirection,
                        WindSpeed = src.WindSpeed,
                        AirPress = src.AirPress,
                        AirTemperature = src.AirTemperature,
                        RelHumidity = src.RelHumidity,
                        Apparent = src.Apparent,
                        RainFall = src.RainFall,
                        RainLevel = src.RainLevel,
                        HighTemperature = src.HighTemperature,
                        LowTemperature = src.LowTemperature
                    };
                    list.Add(data);
                }
            }
            return list;
        }

        protected override bool IsSynchronized(DateTime time)
        {
            return Model.Weather_D_SpiData.FirstOrDefault(o => o.TimePoint == time) != null;
        }

        protected override void RemoveData(DateTime time)
        {
            IQueryable<Weather_D_SpiData> list = Model.Weather_D_SpiData.Where(o => o.TimePoint == time);
            if (list.Any())
            {
                Model.Weather_D_SpiData.RemoveRange(list);
            }
        }
    }
}
