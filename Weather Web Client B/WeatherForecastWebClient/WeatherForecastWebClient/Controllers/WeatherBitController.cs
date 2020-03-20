using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.Models;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.POCO;

namespace WeatherForecastWebClient.Controllers
{
    class WeatherBitController: Controller
    {
        private WeatherBitEndpoint weatherBitEndpoint;

        public WeatherBitController() : base()
        {
            this.weatherBitEndpoint = new WeatherBitEndpoint();
        }
        public float getCurrentTemperature(string city, EndpointType endpointType)
        {
            float temperature = 0f;

            restClient.endpoint = weatherBitEndpoint.getByCityNameEndpoint(city, endpointType);
            string response = restClient.makeRequest();
            //Console.WriteLine(response);
            JSONParser<WeatherBitWeatherModel> jsonParser = new JSONParser<WeatherBitWeatherModel>();

            WeatherBitWeatherModel deserialisedOpenWeatherMapModel = new WeatherBitWeatherModel();
            deserialisedOpenWeatherMapModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);

            temperature = deserialisedOpenWeatherMapModel.data[0].temp;

            return temperature;
        }

        public List<WeatherBitForecast> getForecastList(string city, EndpointType endpoint)
        {
            List<WeatherBitForecast> forecastList = new List<WeatherBitForecast>();

            restClient.endpoint = weatherBitEndpoint.getByCityNameEndpoint(city, endpoint);
            string response = restClient.makeRequest();

            JSONParser<WeatherBitForecastModel> jsonParser = new JSONParser<WeatherBitForecastModel>();

            WeatherBitForecastModel deserialisedWeatherBitMapModel = new WeatherBitForecastModel();
            deserialisedWeatherBitMapModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);
            //Console.WriteLine(deserialisedWeatherBitMapModel);
            foreach (BitForecastObj forecastMain in deserialisedWeatherBitMapModel.data)
            {
                //DateTime dt = DateTimeOffset.FromUnixTimeSeconds(forecastMain.datetime).UtcDateTime;
                DateTime dt = DateTime.Parse(forecastMain.datetime);
                //Console.WriteLine(dt);
                forecastList.Add(new WeatherBitForecast(dt, forecastMain.min_temp, forecastMain.max_temp));
            }
            return forecastList;
        }
        //public WeatherBitForecastModel getForecastList(string city, EndpointType endpoint)
        //{
        //    List<WeatherBitForecastModel> forecastList = new List<WeatherBitForecastModel>();

        //    restClient.endpoint = weatherBitEndpoint.getByCityNameEndpoint(city, endpoint);
        //    string response = restClient.makeRequest();

        //    JSONParser<WeatherBitForecastModel> jsonParser = new JSONParser<WeatherBitForecastModel>();

        //    WeatherBitForecastModel deserialisedWeatherBitMapModel = new WeatherBitForecastModel();
        //    deserialisedWeatherBitMapModel = jsonParser.parseJSON(response, Parser.Version.NETCore2);
        //    Console.WriteLine(deserialisedWeatherBitMapModel);
        //    //foreach (BitForecastObj forecastMain in deserialisedWeatherBitMapModel.list)
        //    //{
        //    //    DateTime dt = DateTimeOffset.FromUnixTimeSeconds(forecastMain.datetime).UtcDateTime;
        //        //forecastList.Add(new WeatherBitForecast(dt, forecastMain.tr.min_temp, forecastMain.tr.max_temp));
        //    //}
        //    return deserialisedWeatherBitMapModel;
        //}
    }
}
