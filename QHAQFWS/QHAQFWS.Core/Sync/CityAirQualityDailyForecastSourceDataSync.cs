using QHAQFWS.Basic.Extensions;
using QHAQFWS.Core.Sync.Base;
using QHAQFWS.Model;
using Suncere.StatisticModel;
using Suncere.StatisticModel.ForecastModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Core.Sync
{
    public class CityAirQualityDailyForecastSourceDataSync : SyncBase<For_D_Air_City>
    {
        protected List<Regional_Code> regionalCodes;
        protected List<ForecastPollutantRange> rangeList;
        protected decimal nullValue;
        public CityAirQualityDailyForecastSourceDataSync(QHAQFWSModel model) : base(model)
        {
            regionalCodes = Model.Regional_Code.Where(o => o.Status == 1).ToList();
            List<Forecast_Pollutant_Range> tempList = Model.Forecast_Pollutant_Range.ToList();
            rangeList = ReflectionHelper.Copy<ForecastPollutantRange, Forecast_Pollutant_Range>(tempList, null);
            nullValue = -99;
        }

        protected override DateTime GetTime()
        {
            return DateTime.Today;
        }

        protected override DateTime GetStartTime(DateTime time)
        {
            return time.AddHours(8);
        }

        protected override List<For_D_Air_City> GetSyncData(SyncDataQueue queue)
        {
            List<For_D_Air_City> list = new List<For_D_Air_City>();
            foreach (Regional_Code regionalCode in regionalCodes)
            {
                if (!IsSynchronized(regionalCode.Area_Code, queue.Time, 2))
                {
                    TongQi forecastModel = new TongQi(regionalCode.Area_Code, 30, 4, queue.Time, 15);
                    list.AddRange(Predict(forecastModel));
                }
                if (!IsSynchronized(regionalCode.Area_Code, queue.Time, 1))
                {
                    DuoYuan forecastModel = new DuoYuan(regionalCode.Area_Code, 30, 4, queue.Time, 15);
                    list.AddRange(Predict(forecastModel));
                }
                if (!IsSynchronized(regionalCode.Area_Code, queue.Time, 3))
                {
                    BPNet forecastModel = new BPNet(regionalCode.Area_Code, 40, 6, queue.Time, 15);
                    list.AddRange(Predict(forecastModel));
                }
                if (!IsSynchronized(regionalCode.Area_Code, queue.Time, 5))
                {
                    JuLei forecastModel = new JuLei(regionalCode.Area_Code, 40, 4, queue.Time, 15);
                    list.AddRange(Predict(forecastModel));
                }
            }
            return list;
        }

        protected virtual bool IsSynchronized(string cityCode, DateTime time, int forecastModelId)
        {
            return Model.For_D_Air_City.FirstOrDefault(o => o.AreaCode == cityCode && o.TimePoint == time && o.ForecastModelId == forecastModelId) != null;
        }

        protected virtual List<For_D_Air_City> Predict(BaseStatisticModel forecastModel)
        {
            List<Air_CityAQIHistory_Day_Pub> monitorAirQualityList = Model.Air_CityAQIHistory_Day_Pub.Where(o => o.CityCode.ToString() == forecastModel.Code && o.TimePoint >= forecastModel.BeginTime && o.TimePoint <= forecastModel.EndTime).ToList();
            string cityName = regionalCodes.First(o => o.Area_Code == forecastModel.Code).Data_Value;
            List<Weather_D_SpiData> monitorWeatherList = Model.Weather_D_SpiData.Where(o => o.CityName == cityName && o.TimePoint >= forecastModel.BeginTime && o.TimePoint <= forecastModel.EndTime).ToList();
            List<City_WeatherForeastInfo> forecastWeatherList = Model.City_WeatherForeastInfo.Where(o => o.CityName == cityName && o.Timepoint == forecastModel.TimePoint).ToList();
            for (int i = 0; i < 15; i++)
            {
                DateTime forecastDate = forecastModel.TimePoint.AddDays(i);
                City_WeatherForeastInfo forecastWeather = forecastWeatherList.FirstOrDefault(o => o.ForTime == forecastDate);
                if (forecastWeather == null)
                {
                    City_WeatherForeastInfo forecastWeatherLast = forecastWeatherList.Last();
                    forecastWeather = new City_WeatherForeastInfo()
                    {
                        Timepoint = forecastWeatherLast.Timepoint,
                        ForTime = forecastDate,
                        CreateTime = DateTime.Now,
                        CityName = forecastWeatherLast.CityName,
                        CityCode = forecastWeatherLast.CityCode,
                        WindDirection = forecastWeatherLast.WindDirection,
                        WindSpeed = forecastWeatherLast.WindSpeed,
                        AirPress = forecastWeatherLast.AirPress,
                        AirTemp = forecastWeatherLast.AirTemp,
                        High_AirTemp = forecastWeatherLast.High_AirTemp,
                        Low_High_AirTemp = forecastWeatherLast.Low_High_AirTemp,
                        Day_Condition = forecastWeatherLast.Day_Condition,
                        Night_Condition = forecastWeatherLast.Night_Condition,
                        DayWindDirection = forecastWeatherLast.DayWindDirection,
                        NightWindDirection = forecastWeatherLast.NightWindDirection,
                        DayWindSpeed = forecastWeatherLast.DayWindSpeed,
                        NightWindSpeed = forecastWeatherLast.NightWindSpeed,
                        RelativeHumidity = forecastWeatherLast.RelativeHumidity,
                        CloundCover = forecastWeatherLast.CloundCover,
                        Visibility = forecastWeatherLast.Visibility,
                        RainFall = forecastWeatherLast.RainFall
                    };
                    forecastWeatherList.Add(forecastWeather);
                }
            }

            List<PollutantMonitorData> pollutantMonitorDataList = GetPollutantMonitorDataList(monitorAirQualityList);
            List<WeatherMonitorData> weatherMonitorDataList = GetWeatherMonitorDataList(monitorWeatherList);
            List<WeatherForecastData> weatherForecastDataList = ReflectionHelper.Copy<WeatherForecastData, City_WeatherForeastInfo>(forecastWeatherList, null);

            //数据源及模型设置
            forecastModel.IsAccordingNationStandard = true;     //按照总站标准计算AQI预报范围
            forecastModel.PollutantMonitorList = pollutantMonitorDataList;
            forecastModel.WeatherMonitorList = weatherMonitorDataList;
            forecastModel.WeatherForecastList = weatherForecastDataList;
            forecastModel.PollutantRangeList = rangeList;
            forecastModel.AQILowRange = 20;
            forecastModel.AQIHighRange = 35;

            List<PollutantForecastData> pollutantForecastDataList = forecastModel.PredictOutPut();
            return GetFor_D_Air_CityList(pollutantForecastDataList);
        }

        protected virtual List<PollutantMonitorData> GetPollutantMonitorDataList(List<Air_CityAQIHistory_Day_Pub> srcList)
        {
            List<PollutantMonitorData> list = new List<PollutantMonitorData>();
            foreach (Air_CityAQIHistory_Day_Pub src in srcList)
            {
                PollutantMonitorData data = new PollutantMonitorData()
                {
                    TimePoint = src.TimePoint,
                    SO2 = GetValue(src.SO2_24h),
                    NO2 = GetValue(src.NO2_24h),
                    NO = nullValue,
                    CO = src.CO_24h.ToDecimal(nullValue),
                    NOx = nullValue,
                    O3 = nullValue,
                    O3_8H = GetValue(src.O3_8h_24h),
                    PM2_5 = GetValue(src.PM2_5_24h),
                    PM10 = GetValue(src.PM10_24h),
                    AQI = src.AQI.ToInt(-99)
                };
                list.Add(data);
            }
            return list;
        }

        protected decimal GetValue(string text)
        {
            decimal value;
            if (decimal.TryParse(text, out value))
            {
                return value / 1000;
            }
            else
            {
                return nullValue;
            }
        }

        protected virtual List<WeatherMonitorData> GetWeatherMonitorDataList(List<Weather_D_SpiData> srcList)
        {
            List<WeatherMonitorData> list = new List<WeatherMonitorData>();
            foreach (Weather_D_SpiData src in srcList)
            {
                WeatherMonitorData data = new WeatherMonitorData()
                {
                    TimePoint = src.TimePoint.Value,
                    WindDirection = src.WindDirection.HasValue ? src.WindDirection : nullValue,
                    WindSpeed = src.WindSpeed.HasValue ? src.WindSpeed : nullValue,
                    Pressure = src.AirPress.HasValue ? src.AirPress : nullValue,
                    AirTemperature = src.AirTemperature.HasValue ? src.AirTemperature : nullValue,
                    Humidity = src.RelHumidity.HasValue ? src.RelHumidity : nullValue,
                    Rainfall = src.RainFall.HasValue ? src.RainFall : nullValue,
                    Apparent = src.Apparent.HasValue ? src.Apparent : nullValue
                };
                list.Add(data);
            }
            return list;
        }

        protected virtual List<WeatherForecastData> GetWeatherForecastDataList(List<City_WeatherForeastInfo> srcList)
        {
            return ReflectionHelper.Copy<WeatherForecastData, City_WeatherForeastInfo>(srcList, null);
        }

        protected virtual List<For_D_Air_City> GetFor_D_Air_CityList(List<PollutantForecastData> srcList)
        {
            List<For_D_Air_City> list = new List<For_D_Air_City>();
            foreach (PollutantForecastData src in srcList)
            {
                For_D_Air_City data = new For_D_Air_City()
                {
                    AreaCode = src.Code,
                    TimePoint = src.TimePoint,
                    ForTime = src.ForTime,
                    ForecastModelId = src.ForecastModelId,
                    CreateTime = DateTime.Now,
                    DayANight = "白天",
                    SO2 = src.SO2,
                    NO2 = src.NO2,
                    CO = src.CO,
                    O3_8H = src.O3_8H,
                    PM10 = src.PM10,
                    PM2_5 = src.PM2_5,
                    SO2_FloatingValue = src.SO2_FloatingValue,
                    NO2_FloatingValue = src.NO2_FloatingValue,
                    CO_FloatingValue = src.CO_FloatingValue,
                    O3_8H_FloatingValue = src.O3_8H_FloatingValue,
                    PM10_FloatingValue = src.PM10_FloatingValue,
                    PM2_5_FloatingValue = src.PM2_5_FloatingValue,
                    AQI = src.AQI,
                    AQI_Low = src.AQI_Low,
                    AQI_High = src.AQI_High,
                    AQILevel = src.AQILevel,
                    PrimaryPollutant = src.PrimaryPollutant
                };
                list.Add(data);
            }
            return list;
        }

        protected override bool IsSynchronized(DateTime time)
        {
            return Model.For_D_Air_City.FirstOrDefault(o => o.TimePoint == time) != null;
        }
    }
}
