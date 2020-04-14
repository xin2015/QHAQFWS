using Ivony.Html;
using Ivony.Html.Parser;
using QHAQFWS.Basic.Extensions;
using QHAQFWS.Basic.Models;
using QHAQFWS.Core.MeteorologyDataService;
using QHAQFWS.Core.Sync.Base;
using QHAQFWS.Core.Weather;
using QHAQFWS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Core.Sync
{
    public class CityWeatherDailyForecastDataSync : SyncBase<City_WeatherForeastInfo>
    {
        protected List<Regional_Code> RegionalCodeList;
        protected Dictionary<string, string> CityUrlDic;
        public CityWeatherDailyForecastDataSync(QHAQFWSModel model) : base(model)
        {
            RegionalCodeList = Model.Regional_Code.Where(o => o.Status == 1).ToList();
            CityUrlDic = new Dictionary<string, string>();
            CityUrlDic.Add("西宁市", "http://www.nmc.cn/publish/forecast/AQH/xining.html");
            CityUrlDic.Add("海东市", "http://www.nmc.cn/publish/forecast/AQH/ledou.html");
            CityUrlDic.Add("黄南藏族自治州", "http://www.nmc.cn/publish/forecast/AQH/tongren2.html");
            CityUrlDic.Add("海南藏族自治州", "http://www.nmc.cn/publish/forecast/AQH/gonghe.html");
            CityUrlDic.Add("果洛藏族自治州", "http://www.nmc.cn/publish/forecast/AQH/maqin.html");
            CityUrlDic.Add("玉树藏族自治州", "http://www.nmc.cn/publish/forecast/AQH/yushu1.html");
            CityUrlDic.Add("海西蒙古族藏族自治州", "http://www.nmc.cn/publish/forecast/AQH/delingha.html");
            CityUrlDic.Add("海北藏族自治州", "http://www.nmc.cn/publish/forecast/AQH/haiyan1.html");
        }

        protected override DateTime GetTime()
        {
            return DateTime.Today;
        }

        protected override DateTime GetStartTime(DateTime time)
        {
            return time.AddHours(7);
        }

        protected override DateTime GetEndTime(DateTime time)
        {
            return time.AddDays(1);
        }

        protected virtual List<City_WeatherForeastInfo> GetSyncDataFromWCF(SyncDataQueue queue)
        {
            List<City_WeatherForeastInfo> list = new List<City_WeatherForeastInfo>();
            Dictionary<string, string> CityDic = new Dictionary<string, string>();
            CityDic.Add("101150101", "西宁市");
            CityDic.Add("101150202", "海东市");
            CityDic.Add("101150301", "黄南藏族自治州");
            CityDic.Add("101150409", "海南藏族自治州");
            CityDic.Add("101150508", "果洛藏族自治州");
            CityDic.Add("101150601", "玉树藏族自治州");
            CityDic.Add("101150716", "海西蒙古族藏族自治州");
            CityDic.Add("101150804", "海北藏族自治州");
            using (MeteorologyDataClient client = new MeteorologyDataClient())
            {
                City_WeatherForecastInfo[] srcList = client.GetDayForecastData(CityDic.Keys.ToArray(), queue.Time, queue.Time);
                List<City_WeatherForeastInfo> existList = Model.City_WeatherForeastInfo.Where(o => o.Timepoint == queue.Time).ToList();
                foreach (City_WeatherForecastInfo src in srcList)
                {
                    if (!existList.Any(o => o.CityCode == src.CityCode && o.ForTime == src.ForTime))
                    {
                        City_WeatherForeastInfo data = new City_WeatherForeastInfo()
                        {
                            Timepoint = src.TimePoint,
                            ForTime = src.ForTime,
                            CreateTime = DateTime.Now,
                            CityName = CityDic[src.CityCode],
                            CityCode = src.CityCode,
                            WindDirection = src.WindDirection,
                            WindSpeed = src.WindSpeed,
                            AirPress = src.AirPress,
                            AirTemp = src.AirTemp,
                            High_AirTemp = src.Day_AirTemp,
                            Low_High_AirTemp = src.Night_AirTemp,
                            Day_Condition = src.Day_Condition,
                            Night_Condition = src.Night_Condition,
                            DayWindDirection = src.Day_WindDirection,
                            NightWindDirection = src.Night_WindDirection,
                            DayWindSpeed = src.Day_WindSpeed,
                            NightWindSpeed = src.Night_WindSpeed,
                            RelativeHumidity = src.RelativeHumidity,
                            CloundCover = src.CloundCover,
                            Visibility = src.Visibility,
                            RainFall = src.RainFall
                        };
                        list.Add(data);
                    }
                }
            }
            return list;
        }

        protected override List<City_WeatherForeastInfo> GetSyncData(SyncDataQueue queue)
        {
            List<City_WeatherForeastInfo> list = new List<City_WeatherForeastInfo>();
            foreach (Regional_Code regionalCode in RegionalCodeList)
            {
                if (Model.City_WeatherForeastInfo.FirstOrDefault(o => o.CityCode == regionalCode.Area_Code && o.Timepoint == queue.Time) == null)
                {
                    list.AddRange(GetList(regionalCode, queue.Time));
                }
            }
            return list;
        }

        protected virtual List<City_WeatherForeastInfo> GetList(Regional_Code regionalCode, DateTime time)
        {
            List<City_WeatherForeastInfo> list = new List<City_WeatherForeastInfo>();
            try
            {
                JumonyParser jp = new JumonyParser();
                IHtmlDocument html = jp.LoadDocument(CityUrlDic[regionalCode.Data_Value], Encoding.UTF8);
                if (html != null)
                {
                    #region 七天天气预报
                    int day = 0;
                    City_WeatherForeastInfo cityForecastData;
                    foreach (IHtmlElement weatherDiv in html.FindFirst("#day7").Elements())
                    {
                        cityForecastData = new City_WeatherForeastInfo();
                        cityForecastData.CityCode = regionalCode.Area_Code;
                        cityForecastData.CityName = regionalCode.Data_Value;
                        cityForecastData.CreateTime = DateTime.Now;
                        cityForecastData.Timepoint = time;
                        cityForecastData.ForTime = DateTime.Today.AddDays(day++);
                        cityForecastData.High_AirTemp = weatherDiv.FindFirst("div.tmp").InnerText().Replace("℃", string.Empty).ToNullableDecimal();
                        cityForecastData.Low_High_AirTemp = weatherDiv.FindLast("div.tmp").InnerText().Replace("℃", string.Empty).ToNullableDecimal();
                        cityForecastData.Day_Condition = weatherDiv.FindFirst("div.desc").InnerText().Trim();
                        cityForecastData.Night_Condition = weatherDiv.FindLast("div.desc").InnerText().Trim();
                        cityForecastData.DayWindDirection = NMCHelper.GetWindDirect(weatherDiv.FindFirst("div.windd").InnerText().Trim());
                        cityForecastData.NightWindDirection = NMCHelper.GetWindDirect(weatherDiv.FindLast("div.windd").InnerText().Trim());
                        cityForecastData.DayWindSpeed = weatherDiv.FindFirst("div.winds").InnerText().Trim();
                        cityForecastData.NightWindSpeed = weatherDiv.FindLast("div.winds").InnerText().Trim();
                        list.Add(cityForecastData);
                    }
                    #endregion
                    #region 精细预报
                    for (day = 0; day < 7; day++)
                    {
                        #region 小时预报
                        List<City_WeatherForeastInfo> hourListForDay = new List<City_WeatherForeastInfo>();
                        IHtmlElement dayDiv = html.FindFirst("#day" + day);
                        DateTime beginTime = DateTime.Today;
                        int hourIndex = 0;
                        foreach (IHtmlElement hour3Div in dayDiv.Elements())
                        {
                            IHtmlElement columnDiv = hour3Div.FindFirst("div");
                            if (hourIndex == 0)
                            {
                                beginTime = DateTime.Parse(string.Format("{0} {1}", DateTime.Today.AddDays(day).ToShortDateString(), columnDiv.InnerText().Trim()));
                            }
                            City_WeatherForeastInfo hourData = new City_WeatherForeastInfo()
                            {
                                CityCode = regionalCode.Area_Code,
                                CityName = regionalCode.Data_Value,
                                Timepoint = time,
                                CreateTime = DateTime.Now,
                                ForTime = beginTime.AddHours(hourIndex * 3)
                            };
                            #region 天气现象
                            columnDiv = columnDiv.NextElement();
                            //天气概况显示为图片，暂不抓取 2020-03-24
                            #endregion
                            #region 降水
                            columnDiv = columnDiv.NextElement();
                            string rain = columnDiv.InnerText().Trim();
                            if (rain == "-")
                            {
                                hourData.RainFall = 0;
                            }
                            else
                            {
                                hourData.RainFall = rain.Replace("mm", string.Empty).ToNullableDecimal();
                            }
                            #endregion
                            #region 气温
                            columnDiv = columnDiv.NextElement();
                            hourData.AirTemp = columnDiv.InnerText().Trim().Replace("℃", string.Empty).ToNullableDecimal();
                            #endregion
                            #region 风速
                            columnDiv = columnDiv.NextElement();
                            hourData.WindSpeed = columnDiv.InnerText().Trim().Replace("m/s", string.Empty).ToNullableDecimal();
                            #endregion
                            #region 风向
                            columnDiv = columnDiv.NextElement();
                            hourData.WindDirection = NMCHelper.GetWindDirect(columnDiv.InnerText().Trim());
                            #endregion
                            #region 气压
                            columnDiv = columnDiv.NextElement();
                            hourData.AirPress = columnDiv.InnerText().Trim().Replace("hPa", string.Empty).ToNullableDecimal();
                            #endregion
                            #region 湿度
                            columnDiv = columnDiv.NextElement();
                            hourData.RelativeHumidity = columnDiv.InnerText().Trim().Replace("%", string.Empty).ToNullableDecimal();
                            #endregion
                            #region 云量
                            columnDiv = columnDiv.NextElement();
                            hourData.CloundCover = columnDiv.InnerText().Trim().Replace("%", string.Empty).ToNullableDecimal();
                            #endregion
                            hourListForDay.Add(hourData);
                            hourIndex++;
                        }
                        #endregion
                        #region 日均预报
                        City_WeatherForeastInfo forecastData = list.First(o => o.ForTime == beginTime.Date);
                        forecastData.AirTemp = hourListForDay.Average(t => t.AirTemp).Round(1);
                        forecastData.RainFall = hourListForDay.Sum(t => t.RainFall).Round(1);
                        forecastData.AirPress = hourListForDay.Average(t => t.AirPress).Round(1);
                        forecastData.RelativeHumidity = hourListForDay.Average(t => t.RelativeHumidity).Round(1);
                        forecastData.CloundCover = hourListForDay.Average(t => t.CloundCover).Round(1);
                        forecastData.Visibility = hourListForDay.Average(t => t.Visibility).Round(1);
                        IEnumerable<City_WeatherForeastInfo> temp = hourListForDay.Where(o => o.WindDirection.HasValue && o.WindSpeed.HasValue);
                        if (temp.Any())
                        {
                            Vector avg = VectorHelper.Average(temp.Select(o => new Vector((double)o.WindDirection.Value, (double)o.WindSpeed.Value, false)));
                            forecastData.WindDirection = (decimal)Math.Round(avg.GetDegree(), 1);
                            forecastData.WindSpeed = (decimal)Math.Round(avg.Length, 1);
                        }
                        #endregion
                    }
                    #endregion
                }
            }
            catch (Exception e)
            {
                Logger.DebugFormat("获取{0}气象预报数据失败", e, regionalCode.Data_Value);
            }
            return list;
        }

        protected override bool IsSynchronized(DateTime time)
        {
            return Model.City_WeatherForeastInfo.Count(o => o.Timepoint == time) == CityUrlDic.Count * 7;
        }
    }
}
