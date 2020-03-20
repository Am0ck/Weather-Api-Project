using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Endpoints
{
    class ClimaCellEndpoint : Endpoint
    {
        public ClimaCellEndpoint() : base(
            "iwFKQOGyLYTNTnBtpWgws8HZRbwIcNId",
            "https://api.climacell.co",
            new Dictionary<EndpointType, string>{
                {EndpointType.CURRENT,"realtime" },
                {EndpointType.FORECAST,"forecast/daily"}},
             "v3/weather", "temp:C")
        { }

        public string getByCityNameEndpoint(float lon, float lat, EndpointType endpointType)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/{version}");
            stringBuilder.Append($"/{endpointTypeDictionary[endpointType]}");
            stringBuilder.Append("?apikey=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append($"&lat={lat}");
            stringBuilder.Append($"&lon={lon}");
            stringBuilder.Append($"&fields={units}");
            return stringBuilder.ToString();
        }
        public string getForecastByCityNameEndpoint(float lon, float lat, EndpointType endpointType)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/{version}");
            stringBuilder.Append($"/{endpointTypeDictionary[endpointType]}");
            stringBuilder.Append("?apikey=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append($"&lat={lat}");
            stringBuilder.Append($"&lon={lon}");
            stringBuilder.Append($"&start_time=now&end_time=2020-03-25T14:09:50Z");
            stringBuilder.Append($"&fields={units}");
            return stringBuilder.ToString();
        }
    }
}
