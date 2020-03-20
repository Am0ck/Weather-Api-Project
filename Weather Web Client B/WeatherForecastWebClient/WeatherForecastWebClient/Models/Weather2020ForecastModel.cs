using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    [DataContract]
    class Weather2020ForecastModel
    {
        [DataMember]
        public long startDate { get; set; }
        [DataMember]
        public int temperatureHighCelcius { get; set; }
        [DataMember]
        public int temperatureLowCelcius { get; set; }
    }
}
