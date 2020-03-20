using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Endpoints
{
    class Weather2020Endpoint : Endpoint
    {
        public Weather2020Endpoint() : base(
            "e8ecee8ff60c478f8a36280fea0524fe",
            "http://api.weather2020.com",
            new Dictionary<EndpointType, string>{},"", ""){ }

        public string getByCityNameEndpoint(float lon, float lat)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("/");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("/" + lat + "," + lon);
            return stringBuilder.ToString();
        }
    }
}
