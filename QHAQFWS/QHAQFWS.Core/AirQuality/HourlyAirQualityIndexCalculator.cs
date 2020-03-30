using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Core.AirQuality
{
    public class HourlyAirQualityIndexCalculator : AirQualityIndexCalculator
    {
        public HourlyAirQualityIndexCalculator()
        {
            PollutantConcentrationLimitsDic.Add("SO2", new decimal[] { 0, 150, 500, 650, 800 });
            PollutantConcentrationLimitsDic.Add("NO2", new decimal[] { 0, 100, 200, 700, 1200, 2340, 3090, 3840 });
            PollutantConcentrationLimitsDic.Add("CO", new decimal[] { 0, 5, 10, 35, 60, 90, 120, 150 });
            PollutantConcentrationLimitsDic.Add("O3", new decimal[] { 0, 160, 200, 300, 400, 800, 1000, 1200 });
        }
    }
}
