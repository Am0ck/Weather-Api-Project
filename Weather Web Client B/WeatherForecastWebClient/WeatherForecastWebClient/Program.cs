using System;
using WeatherForecastWebClient.Endpoints;
using WeatherForecastWebClient.WebClient;
using WeatherForecastWebClient.Output;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using WeatherForecastWebClient.WeatherModel;
using WeatherForecastWebClient.ForecastModel;
using WeatherForecastWebClient.Parser;
using WeatherForecastWebClient.Controllers;
using WeatherForecastWebClient.POCO;
using WeatherForecastWebClient.Models;

namespace WeatherForecastWebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string response = String.Empty;

            //OpenWeatherMap
            openWeatherMapCurrentAPI();
            openWeatherMapForecastAPI();

            //Accuweather
            accuweatherCurrentConditionsAPI();
            accuweatherForecastAPI();

            //WeatherBit
            weatherBitMapCurrentAPI();
            weatherBitMapForecastAPI();


            //DarkSky
            darkSkyForecastAPI();
            darkSkyCurrentAPI();

            //weather2020
            w2020ForecastAPI();
            
            //clima
            climaRealtime();
            climaForecast();
            Console.ReadKey();

        }

        static void openWeatherMapCurrentAPI()
        {
            Out output = new Out();

            OpenWeatherMapController openWeatherMapController = new OpenWeatherMapController();

            output.outputToConsole("**** Open Weather Map Current Weather *****");

            string cityName = "Valletta";
            output.outputToConsole($"Temperature for {cityName}: {openWeatherMapController.getCurrentTemperature(cityName,EndpointType.CURRENT)}");

            cityName = "London";
            output.outputToConsole($"Temperature for {cityName}: {openWeatherMapController.getCurrentTemperature(cityName, EndpointType.CURRENT)}");
        }

        static void openWeatherMapForecastAPI()
        {
            Out output = new Out();

            OpenWeatherMapController openWeatherMapController = new OpenWeatherMapController();

            output.outputToConsole("**** Open Weather Map Forecast *****");

            string cityName = "Valletta";

            output.outputToConsole($"Forecast weather for: {cityName}");

            foreach (OpenWeatherMapForecast forecast in openWeatherMapController.getForecastList(cityName,EndpointType.FORECAST))
            {          
                output.outputToConsole($"Date/Time: {forecast.dateTime} Temperature: {forecast.temperature}");
            }
        }
        static void weatherBitMapForecastAPI()
        {
            Out output = new Out();

            WeatherBitController weatherBitController = new WeatherBitController();

            output.outputToConsole("**** WeatherBit Forecast *****");

            string cityName = "Valletta";

            output.outputToConsole($"Forecast weather for: {cityName}");
            foreach (WeatherBitForecast forecast in weatherBitController.getForecastList(cityName, EndpointType.FORECAST))
            {
                output.outputToConsole($"Date/Time: {forecast.dateTime.ToString("yyyy-MM-dd")} Min: {forecast.min_temp} Max: {forecast.max_temp}");
            }
            weatherBitController.getForecastList(cityName, EndpointType.FORECAST);
            
               
        }

        static void accuweatherCurrentConditionsAPI()
        {
            Out output = new Out();

            AccuWeatherController accuweatherController = new AccuWeatherController();

            output.outputToConsole("***** Accuweather Current Conditions *****");

            string cityName = "Valletta";

            output.outputToConsole($"Temperature for {cityName}: {accuweatherController.getCurrentWeather(cityName)}");
        }

        static void accuweatherForecastAPI()
        {
            Out output = new Out();

            AccuWeatherController accuweatherController = new AccuWeatherController();

            output.outputToConsole("***** Accuweather Forecast *****");

            string cityName = "Valletta";

            foreach (AccuWeatherForecast forecast in accuweatherController.getForecast(cityName))
            {
                output.outputToConsole($"{forecast.getDateTime().ToString()} Minimum: {forecast.getMinimum()} Maximum: {forecast.getMaximum()}");
            }
        }
        static void weatherBitMapCurrentAPI()
        {
            Out output = new Out();

            WeatherBitController weatherBitMapController = new WeatherBitController();

            output.outputToConsole("**** WeatherBit Map Current Weather *****");

            string cityName = "Valletta";
            output.outputToConsole($"Temperature for {cityName}: {weatherBitMapController.getCurrentTemperature(cityName, EndpointType.CURRENT)}");

            cityName = "London";
            output.outputToConsole($"Temperature for {cityName}: {weatherBitMapController.getCurrentTemperature(cityName, EndpointType.CURRENT)}");
        }
        static void darkSkyCurrentAPI()
        {
            Out output = new Out();

            DarkSkyController darkSkyController = new DarkSkyController();

            output.outputToConsole("***** DarkSky Current Weather *****");

            string cityName = "Valletta";
            DarkSkyForecastModel dsfm = darkSkyController.getForecast(cityName, EndpointType.FORECAST);
            output.outputToConsole($"Current Temp in {cityName} is {dsfm.currently.temperature}");
        }
        static void darkSkyForecastAPI()
        {
            Out output = new Out();

            DarkSkyController darkSkyController = new DarkSkyController();

            output.outputToConsole("***** DarkSky Forecast *****");

            string cityName = "Valletta";
            DarkSkyForecastModel dsfm = darkSkyController.getForecast(cityName, EndpointType.FORECAST);
            foreach(ForecastDay fd in dsfm.daily.data)
            {
                DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(fd.time).UtcDateTime;
                output.outputToConsole($"{dateTime} Minimum: {fd.temperatureMin} Maximum: {fd.temperatureMax}");
            }
        }
        static void w2020ForecastAPI()
        {
            Out output = new Out();

            Weather2020Controller w2020Controller = new Weather2020Controller();

            output.outputToConsole("***** Weather2020 Forecast *****");

            string cityName = "Stuart";
            foreach (Weather2020Forecast forecast in w2020Controller.getForecast(cityName))
            {
                output.outputToConsole($"{forecast.dateTime} Minimum: {forecast.min_temp} Maximum: {forecast.max_temp}");
            }
        }
        static void climaRealtime()
        {
            Out output = new Out();

            ClimaWeatherController climaWeatherController = new ClimaWeatherController();

            output.outputToConsole("***** ClimaWeather Weather *****");

            string cityName = "Valletta";
            ClimaRealTimeModel crtm =  climaWeatherController.getWeather(cityName, EndpointType.CURRENT);
            output.outputToConsole($"In {cityName} current temp is: {crtm.temp.value}");
        }
        static void climaForecast()
        {
            Out output = new Out();

            ClimaWeatherController climaWeatherController = new ClimaWeatherController();

            output.outputToConsole("***** ClimaForecast *****");

            string cityName = "Valletta";
            output.outputToConsole(cityName+" Forecast");
            foreach (ClimaForecast forecast in climaWeatherController.getForecast(cityName, EndpointType.FORECAST))
            {
                output.outputToConsole($"Date: {forecast.dateTime} MIN:{forecast.min_temp} MAX: {forecast.max_temp}");
            }
        }
    }
}
