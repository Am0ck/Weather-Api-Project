using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.POCO
{
    class ClimaForecast
    {
        public string dateTime { get; }
        public float min_temp { get; }
        public float max_temp { get; }

        public ClimaForecast(string dateTime, float min_temp, float max_temp)
        {
            this.dateTime = dateTime;
            this.min_temp = min_temp;
            this.max_temp = max_temp;
        }
    }
}
