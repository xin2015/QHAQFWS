using QHAQFWS.Core.AirQuality;
using QHAQFWS.Core.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Core.Forecast
{
    public class BackPropagationLearningForecast
    {
        public void Train(IEnumerable<IAirQualityPollutantConcentration> airQualityPollutantConcentrations, IEnumerable<IWeather> weathers)
        {

        }

        //public IAirQualityPollutantConcentration Predict(IAirQualityPollutantConcentration airQualityPollutantConcentration, IWeather weather)
        //{

        //}
    }
}
