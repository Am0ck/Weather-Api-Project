using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.Models;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.POCO;

namespace WeatherForecastWebClient.Controllers
{
    class ClimaWeatherController : Controller
    {
        private ClimaCellEndpoint climaCellEndpoint;

        AccuWeatherController awc = new AccuWeatherController();
        public ClimaWeatherController() : base()
        {
            climaCellEndpoint = new ClimaCellEndpoint();
        }
        public ClimaRealTimeModel getWeather(string cityName, EndpointType endpointType)
        {
            AccuWeatherLocationModel awlm = awc.getPosition(cityName);
            //Console.WriteLine(awlm.GeoPosition.Latitude);

            //List<AccuWeatherForecast> forecastList = new List<AccuWeatherForecast>();

            restClient.endpoint = climaCellEndpoint.getByCityNameEndpoint(awlm.GeoPosition.Longitude, awlm.GeoPosition.Latitude, endpointType);
            string response = restClient.makeRequest();

            JSONParser<ClimaRealTimeModel> jsonParser = new JSONParser<ClimaRealTimeModel>();


            ClimaRealTimeModel deserialisedClimaModel = new ClimaRealTimeModel();
            deserialisedClimaModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);

            //foreach (DailyForecast dailyForecast in deserialisedAccuWeatherModel.DailyForecasts)
            //{
            //    forecastList.Add(new AccuWeatherForecast(dailyForecast.EpochDate, dailyForecast.Temperature.Minimum.Value, dailyForecast.Temperature.Maximum.Value));
            //}
            return deserialisedClimaModel;
        }
        public List<ClimaForecast> getForecast(string cityName, EndpointType endpointType)
        {
            List<ClimaForecast> forecastList = new List<ClimaForecast>();
            AccuWeatherLocationModel awlm = awc.getPosition(cityName);
           
            restClient.endpoint = climaCellEndpoint.getByCityNameEndpoint(awlm.GeoPosition.Longitude, awlm.GeoPosition.Latitude, endpointType);
            string response = restClient.makeRequest();

            JSONParser<List<ClimaForecastModel>> jsonParser = new JSONParser<List<ClimaForecastModel>>();

            List<ClimaForecastModel> deserialisedClimaForecast = new List<ClimaForecastModel>();
            deserialisedClimaForecast = jsonParser.parseJSON(response, Parser.Version.NETCore2);

            foreach (ClimaForecastModel cm in deserialisedClimaForecast)
            {
                forecastList.Add(new ClimaForecast(cm.observation_time.value, cm.temp[0].min.value, cm.temp[1].max.value));
            }
            return forecastList;
        }
    }
}
