using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    [DataContract]
    class ClimaRealTimeModel
    {
        [DataMember]
        public Temp temp { get; set; }
    }
    [DataContract]
    class Temp
    {
        [DataMember]
        public float value { get; set; }
    }
}
