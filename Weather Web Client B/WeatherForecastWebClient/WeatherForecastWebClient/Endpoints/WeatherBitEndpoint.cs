using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebClient.Endpoints
{
    class WeatherBitEndpoint : Endpoint
    {
        public WeatherBitEndpoint() : base(
            "51472573e15144dabc3dd27ddaf82074",
            "http://api.weatherbit.io",
            new Dictionary<EndpointType, string>{
                {EndpointType.CURRENT,"current" },
                {EndpointType.FORECAST,"forecast/daily"}},
             "v2.0","M")
        {}

        public string getByCityNameEndpoint(string cityName, EndpointType endpointType)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append($"/{version}");
            stringBuilder.Append($"/{endpointTypeDictionary[endpointType]}");
            stringBuilder.Append("?key=");
            stringBuilder.Append(apiKey);
            stringBuilder.Append("&units=");
            stringBuilder.Append(units);
            stringBuilder.Append("&city=");
            stringBuilder.Append(cityName);
            return stringBuilder.ToString();
        }
    }
}
