using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    [DataContract]
    class DarkSkyForecastModel
    {
        [DataMember]
        public CurrentWeather currently;
        [DataMember]
        public Forecast daily;
        //public List<ForecastDay> data;
    }
    [DataContract]
    class CurrentWeather
    {
        [DataMember]
        public float temperature;
    }
    [DataContract]
    class Forecast
    {
        [DataMember]
        public List<ForecastDay> data;
    }
    [DataContract]
    class ForecastDay
    {
        [DataMember]
        public long time;
        [DataMember]
        public float temperatureMin;
        [DataMember]
        public float temperatureMax;
    }
}
