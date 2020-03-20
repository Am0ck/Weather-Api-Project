using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    [DataContract]
    class WeatherBitForecastModel
    {
        [DataMember]
        public List<BitForecastObj> data { get; set; }
    }
    [DataContract]
    class BitForecastObj
    {
        [DataMember]
        public float min_temp { get; set; }
        [DataMember]
        public float max_temp { get; set; }
        [DataMember]
        public string datetime { get; set; }
    }
    //[DataContract]
    //class TempRange
    //{
    //    [DataMember]
    //    public float min_temp { get; set; }
    //    public float max_temp { get; set; }
    //}
}
