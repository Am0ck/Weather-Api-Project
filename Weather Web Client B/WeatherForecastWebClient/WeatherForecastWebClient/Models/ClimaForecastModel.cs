using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    [DataContract]
    class ClimaForecastModel
    {
        [DataMember]
        public List<Ctemp> temp { get; set; }
        [DataMember]
        public ObservationTime observation_time { get; set; }
    }
    [DataContract]
    class ObservationTime
    {
        [DataMember]
        public string value { get; set; }
    }
    [DataContract]
    class Ctemp
    {
        [DataMember]
        public Range min { get; set; }
        [DataMember]
        public Range max { get; set; }
    }
    [DataContract]
    class Range
    {
        [DataMember]
        public float value { get; set; }
    }

}
