using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.Models;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.POCO;

namespace WeatherForecastWebClient.Controllers
{
    class Weather2020Controller : Controller
    {
        private Weather2020Endpoint weather2020Endpoint;
        AccuWeatherController awc = new AccuWeatherController();
        public Weather2020Controller() : base()
        {
            weather2020Endpoint = new Weather2020Endpoint();
        }
        public List<Weather2020Forecast> getForecast(string cityName)
        {
            
            List<Weather2020Forecast> forecastList = new List<Weather2020Forecast>();
            AccuWeatherLocationModel awlm = awc.getPosition(cityName);

            restClient.endpoint = weather2020Endpoint.getByCityNameEndpoint(awlm.GeoPosition.Longitude, awlm.GeoPosition.Latitude);
            string response = restClient.makeRequest();

            JSONParser<List<Weather2020ForecastModel>> jsonParser = new JSONParser<List<Weather2020ForecastModel>>();

            List<Weather2020ForecastModel> deserialisedw2020 = new List<Weather2020ForecastModel>();
            deserialisedw2020 = jsonParser.parseJSON(response, Parser.Version.NETCore2);
            foreach (Weather2020ForecastModel wfm in deserialisedw2020)
            {
                DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(wfm.startDate).UtcDateTime;
                forecastList.Add(new Weather2020Forecast(dateTime, wfm.temperatureLowCelcius, wfm.temperatureHighCelcius));
            }
            return forecastList;
        }
    }
}
