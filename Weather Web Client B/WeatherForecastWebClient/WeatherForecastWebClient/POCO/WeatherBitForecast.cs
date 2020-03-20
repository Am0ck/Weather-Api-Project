using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.POCO
{
    class WeatherBitForecast
    {
        public DateTime dateTime { get; }
        public float min_temp { get; }
        public float max_temp { get; }

        public WeatherBitForecast(DateTime dateTime, float min_temp, float max_temp)
        {
            this.dateTime = dateTime;
            this.min_temp = min_temp;
            this.max_temp = max_temp;
        }
    }
}
