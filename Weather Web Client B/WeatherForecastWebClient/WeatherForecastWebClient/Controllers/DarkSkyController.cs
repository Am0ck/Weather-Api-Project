using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.Models;
using WeatherForecastWebClient.Parser;

namespace WeatherForecastWebClient.Controllers
{
    class DarkSkyController : Controller
    {
        private DarkSkyApiEndpoint darkSkyApiEndpoint;

        AccuWeatherController awc = new AccuWeatherController();
        public DarkSkyController() : base()
        {
            darkSkyApiEndpoint = new DarkSkyApiEndpoint();
        }
        public DarkSkyForecastModel getForecast(string cityName, EndpointType endpointType)
        {
            AccuWeatherLocationModel awlm =  awc.getPosition(cityName);
            //Console.WriteLine(awlm.GeoPosition.Latitude);
            
            //List<AccuWeatherForecast> forecastList = new List<AccuWeatherForecast>();

            restClient.endpoint = darkSkyApiEndpoint.getByCityNameEndpoint(awlm.GeoPosition.Longitude, awlm.GeoPosition.Latitude, endpointType);
            string response = restClient.makeRequest();

            JSONParser<DarkSkyForecastModel> jsonParser = new JSONParser<DarkSkyForecastModel>();


            DarkSkyForecastModel deserialisedDarkSkyModel = new DarkSkyForecastModel();
            deserialisedDarkSkyModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);

            //foreach (DailyForecast dailyForecast in deserialisedAccuWeatherModel.DailyForecasts)
            //{
            //    forecastList.Add(new AccuWeatherForecast(dailyForecast.EpochDate, dailyForecast.Temperature.Minimum.Value, dailyForecast.Temperature.Maximum.Value));
            //}
            return deserialisedDarkSkyModel;
        }
    }
}
