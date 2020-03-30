using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Core.Weather
{
    public interface IWeather
    {
        decimal? AirTemperature { get; set; }
        decimal? Rainfall { get; set; }
        decimal? RelativeHumidity { get; set; }
        decimal? AirPressure { get; set; }
        decimal? WindSpeed { get; set; }
        decimal? WindDirection { get; set; }
    }
}
