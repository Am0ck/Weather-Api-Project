using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    [DataContract]
    class WeatherBitWeatherModel
    {
        [DataMember]
        public List<Data> data{ get; set; }
    }

    [DataContract]
    class Data
    {
        [DataMember]
        public float temp { get; set; }
    }
}
