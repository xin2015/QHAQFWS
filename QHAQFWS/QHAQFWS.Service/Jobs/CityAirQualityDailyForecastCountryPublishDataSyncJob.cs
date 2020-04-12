using Common.Logging;
using QHAQFWS.Basic.Extensions;
using QHAQFWS.Core.MeteorologyDataService;
using QHAQFWS.Model;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Service.Jobs
{
    public class CityAirQualityDailyForecastCountryPublishDataSyncJob : IJob
    {
        ILog logger;

        public CityAirQualityDailyForecastCountryPublishDataSyncJob()
        {
            logger = LogManager.GetLogger<CityAirQualityDailyForecastCountryPublishDataSyncJob>();
        }

        public void Execute(IJobExecutionContext context)
        {
            context.Scheduler.PauseJob(context.JobDetail.Key);
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                using (QHAQFWSModel model = new QHAQFWSModel())
                {
                    using (MeteorologyDataClient client = new MeteorologyDataClient())
                    {
                        DateTime date = DateTime.Now.Hour <= 17 ? DateTime.Today.AddDays(-1) : DateTime.Today;
                        NationCityPollutantForecast[] srcList = client.GetCityPollutantForecast(date).Where(o => o.CityCode.Contains("63")).ToArray();
                        foreach (NationCityPollutantForecast src in srcList)
                        {
                            DateTime forecastDate = src.PublishDate.AddDays(src.ForecastType);
                            Tab_City_Result_Info_Publish data = model.Tab_City_Result_Info_Publish.FirstOrDefault(o => o.CityCode == src.CityCode && o.Publish_Date == src.PublishDate && o.Forecast_Date == forecastDate);
                            if (data != null)
                            {
                                data.AQI_Value_Lower = src.AQILow.ToNullableInt();
                                data.AQI_Value_Upper = src.AQIHigh.ToNullableInt();
                                data.Air_Quality_Level_Upper = src.AQILevel;
                                data.Primary_Pollutants = src.PrimaryPollutant;
                                data.Health_Guide = src.HealthTips;
                                data.Create_Date = src.ReceiveTime;
                                data.InscribeInfo = src.DetailInfo;
                            }
                        }
                    }
                    model.SaveChanges();
                }
                sw.Stop();
                logger.InfoFormat("CityAirQualityDailyForecastCountryPublishDataSync {0}.", sw.Elapsed);
            }
            catch (Exception e)
            {
                logger.Error("Execute failed.", e);
            }
            context.Scheduler.ResumeJob(context.JobDetail.Key);
        }
    }
}
