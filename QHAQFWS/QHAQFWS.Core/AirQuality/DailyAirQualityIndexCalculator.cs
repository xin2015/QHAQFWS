using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Core.AirQuality
{
    public class DailyAirQualityIndexCalculator : AirQualityIndexCalculator
    {
        public DailyAirQualityIndexCalculator()
        {
            PollutantConcentrationLimitsDic.Add("SO2", new decimal[] { 0, 50, 150, 475, 800, 1600, 2100, 2620 });
            PollutantConcentrationLimitsDic.Add("NO2", new decimal[] { 0, 40, 80, 180, 280, 565, 750, 940 });
            PollutantConcentrationLimitsDic.Add("CO", new decimal[] { 0, 2, 4, 14, 24, 36, 48, 60 });
            PollutantConcentrationLimitsDic.Add("O3", new decimal[] { 0, 100, 160, 215, 265, 800 });
        }
    }
}
