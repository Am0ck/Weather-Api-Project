using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.POCO
{
    class Weather2020Forecast
    {
        public DateTime dateTime { get; }
        public int min_temp { get; }
        public int max_temp { get; }

        public Weather2020Forecast(DateTime dateTime, int min_temp, int max_temp)
        {
            this.dateTime = dateTime;
            this.min_temp = min_temp;
            this.max_temp = max_temp;
        }
    }
}
