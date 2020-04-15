using QHAQFWS.Basic.Extensions;
using QHAQFWS.Core.Sync.Base;
using QHAQFWS.Model;
using Suncere.StatisticModel;
using Suncere.StatisticModel.ForecastModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Core.Sync
{
    public class StationAirQualityDailyForecastSourceDataSync : SyncBase<For_D_Air_Src>
    {
        protected List<Station> stationList;
        protected List<Regional_Code> regionalCodes;
        protected List<ForecastPollutantRange> rangeList;
        protected decimal nullValue;
        public StationAirQualityDailyForecastSourceDataSync(QHAQFWSModel model) : base(model)
        {
            stationList = Model.Station.Where(o => o.Status && o.Area != "未知城市" && o.UniqueCode.StartsWith("63")).ToList();
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

        protected override List<For_D_Air_Src> GetSyncData(SyncDataQueue queue)
        {
            List<For_D_Air_Src> list = new List<For_D_Air_Src>();
            foreach (Station station in stationList)
            {
                List<For_D_Air_Src> tempList = new List<For_D_Air_Src>();
                if (!IsSynchronized(station.UniqueCode, queue.Time, 2))
                {
                    TongQi forecastModel = new TongQi(station.UniqueCode, 30, 4, queue.Time, 15);
                    tempList.AddRange(Predict(forecastModel, station));
                }
                if (!IsSynchronized(station.UniqueCode, queue.Time, 1))
                {
                    DuoYuan forecastModel = new DuoYuan(station.UniqueCode, 30, 4, queue.Time, 15);
                    tempList.AddRange(Predict(forecastModel, station));
                }
                if (!IsSynchronized(station.UniqueCode, queue.Time, 3))
                {
                    BPNet forecastModel = new BPNet(station.UniqueCode, 40, 6, queue.Time, 15);
                    tempList.AddRange(Predict(forecastModel, station));
                }
                if (!IsSynchronized(station.UniqueCode, queue.Time, 5))
                {
                    JuLei forecastModel = new JuLei(station.UniqueCode, 40, 4, queue.Time, 15);
                    tempList.AddRange(Predict(forecastModel, station));
                }
                if (!IsSynchronized(station.UniqueCode, queue.Time, 0))
                {
                    tempList.AddRange(Predict(station.UniqueCode, queue.Time, tempList));
                }
                list.AddRange(tempList);
            }
            return list;
        }

        protected virtual bool IsSynchronized(string uniqueCode, DateTime time, int forecastModelId)
        {
            return Model.For_D_Air_Src.FirstOrDefault(o => o.StationCode == uniqueCode && o.TimePoint == time && o.ForecastModelId == forecastModelId) != null;
        }

        protected virtual List<For_D_Air_Src> Predict(BaseStatisticModel forecastModel, Station station)
        {
            List<For_D_Air_Src> list = new List<For_D_Air_Src>();
            try
            {
                List<Air_StationAQIHistory_Day_Pub> monitorAirQualityList = Model.Air_StationAQIHistory_Day_Pub.Where(o => o.UniqueCode == forecastModel.Code && o.TimePoint >= forecastModel.BeginTime && o.TimePoint <= forecastModel.EndTime).ToList();
                Regional_Code regionalCode = regionalCodes.First(o => o.Area_Code == station.DistrictCode.ToString());
                string cityName = regionalCode.Data_Value;
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

                List<PollutantMonitorData> pollutantMonitorDataList;
                if (monitorAirQualityList.Any())
                {
                    pollutantMonitorDataList = GetPollutantMonitorDataList(monitorAirQualityList);
                }
                else
                {
                    List<Air_StationAQIHistory_Day_Src> monitorAirQualitySrcList = Model.Air_StationAQIHistory_Day_Src.Where(o => o.UniqueCode == forecastModel.Code && o.TimePoint >= forecastModel.BeginTime && o.TimePoint <= forecastModel.EndTime).ToList();
                    pollutantMonitorDataList = GetPollutantMonitorDataList(monitorAirQualitySrcList);
                }
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
                list = GetFor_D_Air_SrcList(pollutantForecastDataList);
            }
            catch (Exception e)
            {
                Logger.DebugFormat("获取{0} {1} 模型{2}预报数据失败。", e, forecastModel.Code, forecastModel.TimePoint.ToString(""), forecastModel.ForecastModelId);
            }
            return list;
        }

        protected virtual List<PollutantMonitorData> GetPollutantMonitorDataList(List<Air_StationAQIHistory_Day_Pub> srcList)
        {
            List<PollutantMonitorData> list = new List<PollutantMonitorData>();
            foreach (Air_StationAQIHistory_Day_Pub src in srcList)
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

        protected virtual List<PollutantMonitorData> GetPollutantMonitorDataList(List<Air_StationAQIHistory_Day_Src> srcList)
        {
            List<PollutantMonitorData> list = new List<PollutantMonitorData>();
            foreach (Air_StationAQIHistory_Day_Src src in srcList)
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

        protected virtual List<For_D_Air_Src> GetFor_D_Air_SrcList(List<PollutantForecastData> srcList)
        {
            List<For_D_Air_Src> list = new List<For_D_Air_Src>();
            foreach (PollutantForecastData src in srcList)
            {
                For_D_Air_Src data = new For_D_Air_Src()
                {
                    StationCode = src.Code,
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

        /// <summary>
        /// 智能择优模型预报（暂时直接使用BP神经网络模型的结果，待后续修改）
        /// </summary>
        /// <param name="cityCode"></param>
        /// <param name="time"></param>
        /// <param name="otherList"></param>
        /// <returns></returns>
        protected virtual List<For_D_Air_Src> Predict(string cityCode, DateTime time, List<For_D_Air_Src> otherList)
        {
            List<For_D_Air_Src> list = new List<For_D_Air_Src>();
            if (otherList.Any())
            {
                int forecastModelId = 0;
                int forecastModelIdSelected = 3;
                if (!otherList.Any(o => o.ForecastModelId == forecastModelIdSelected))
                {
                    forecastModelIdSelected = otherList.First().ForecastModelId;
                }
                for (int i = 0; i < 15; i++)
                {
                    DateTime forTime = time.AddDays(i);
                    For_D_Air_Src selected = otherList.First(o => o.ForecastModelId == forecastModelIdSelected && o.ForTime == forTime);
                    For_D_Air_Src data = new For_D_Air_Src();
                    ReflectionHelper.Copy(data, selected, null);
                    data.ForecastModelId = forecastModelId;
                    list.Add(data);
                }
            }
            return list;
        }

        protected override bool IsSynchronized(DateTime time)
        {
            return Model.For_D_Air_Src.Count(o => o.TimePoint == time) >= stationList.Count * 15 * 5;
        }
    }
}
