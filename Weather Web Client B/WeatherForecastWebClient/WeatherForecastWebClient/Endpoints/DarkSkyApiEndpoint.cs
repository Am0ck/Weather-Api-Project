using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Endpoints
{
    class DarkSkyApiEndpoint : Endpoint
    {
        public DarkSkyApiEndpoint() : base(
            "807b13a278898db81c0ba027931c61df",
            "https://api.darksky.net",
            new Dictionary<EndpointType, string>{
                {EndpointType.CURRENT,"current" },
                {EndpointType.FORECAST,"forecast"}},
             "", "si")
        { }

        public string getByCityNameEndpoint(float lon, float lat, EndpointType endpointType)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/{endpointTypeDictionary[endpointType]}");
            stringBuilder.Append("/");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("/"+lat+","+lon);
            return stringBuilder.ToString();
        }
    }
}
