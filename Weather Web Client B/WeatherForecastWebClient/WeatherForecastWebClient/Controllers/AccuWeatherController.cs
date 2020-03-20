using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.Models;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.POCO;

namespace WeatherForecastWebClient.Controllers
{
    class AccuWeatherController : Controller
    {
        private AccuweatherEndpoint accuweatherEndpoint;

        public AccuWeatherController() : base()
        {
            accuweatherEndpoint = new AccuweatherEndpoint();
        }

        private string getLocationKey(string cityName)
        {
            string locationKey = string.Empty;

            restClient.endpoint = accuweatherEndpoint.getLocationsEndpoint(cityName);
            string response = restClient.makeRequest();

            JSONParser<List<AccuWeatherLocationModel>> jsonParser = new JSONParser<List<AccuWeatherLocationModel>>();

            List<AccuWeatherLocationModel> deserialisedAccuWeatherModel = new List<AccuWeatherLocationModel>();
            deserialisedAccuWeatherModel = jsonParser.parseJSON(response,Parser.Version.NETCore2);
            locationKey = deserialisedAccuWeatherModel[0].Key;

            return locationKey;
        }
        public AccuWeatherLocationModel getPosition(string cityName)
        {
            string locationKey = string.Empty;

            restClient.endpoint = accuweatherEndpoint.getLocationsEndpoint(cityName);
            string response = restClient.makeRequest();

            JSONParser<List<AccuWeatherLocationModel>> jsonParser = new JSONParser<List<AccuWeatherLocationModel>>();

            List<AccuWeatherLocationModel> deserialisedAccuWeatherModel = new List<AccuWeatherLocationModel>();
            deserialisedAccuWeatherModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);
            //locationKey = deserialisedAccuWeatherModel[0].Key;

            return deserialisedAccuWeatherModel[0];
        }

        public float getCurrentWeather(string cityName)
        {
            float temperature = 0f;

            restClient.endpoint = accuweatherEndpoint.getCurrentConditionsEndpoint(getLocationKey(cityName));
            string response = restClient.makeRequest();
            JSONParser <List<AccuWeatherWeatherModel>> jsonParser = new JSONParser<List<AccuWeatherWeatherModel>>();

            List<AccuWeatherWeatherModel> deserialisedAccuWeatherModel = new List<AccuWeatherWeatherModel>();
            deserialisedAccuWeatherModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);

            temperature = deserialisedAccuWeatherModel[0].Temperature.Metric.Value;

            return temperature;
        }

        public List<AccuWeatherForecast> getForecast(string cityName)
        {
            List<AccuWeatherForecast> forecastList = new List<AccuWeatherForecast>();

            restClient.endpoint = accuweatherEndpoint.getForecastEndpoint(getLocationKey(cityName));
            string response = restClient.makeRequest();

            JSONParser<AccuWeatherForecastModel> jsonParser = new JSONParser<AccuWeatherForecastModel>();


            AccuWeatherForecastModel deserialisedAccuWeatherModel = new AccuWeatherForecastModel();
            deserialisedAccuWeatherModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);

            foreach(DailyForecast dailyForecast in deserialisedAccuWeatherModel.DailyForecasts)
            {
                forecastList.Add(new AccuWeatherForecast(dailyForecast.EpochDate, dailyForecast.Temperature.Minimum.Value, dailyForecast.Temperature.Maximum.Value));
            }

            return forecastList;
        }
    }
}
