using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    [DataContract]
    class AccuWeatherLocationModel
    {
        [DataMember]
        public string Key { get; set; }
        [DataMember]
        public GP GeoPosition { get; set; }
    }
    [DataContract]
    class GP
    {
        [DataMember]
        public float Latitude { get; set; }
        [DataMember]
        public float Longitude { get; set; }
    }
}
