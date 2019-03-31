using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;
using WeatherDataDal.Models;

namespace WeatherDataRetrieval
{
    public class GetWeatherData
    {
        private readonly WeatherDataContext _context;
        private readonly ILogger _logger;
        private readonly IConfigurationRoot configuration;
        private readonly IList<KeyValuePair<string, int>> zipcodeConfig = new List<KeyValuePair<string, int>>();
        private string apiAction = "";
        private string apiKey = "";
        private IConfigurationSection appSettings;
        private string baseUrl = "";

        public GetWeatherData(WeatherDataContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;

            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .Build();
        }

        /// <summary>
        ///     Run
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Run()
        {
            _logger.LogDebug("GetWeatherData - Run Started");
            try
            {
                if (Configure())
                {
                    await GetWeatherDataByZip();

                    return true;
                }

                _logger.LogError("Configure-Failed!!");
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError("Run-Failed: {0}", ex.Message);
                return false;
            }
        }

        // get info from OpenWeather
        /// <summary>
        ///     GetWeatherDataByZip
        /// </summary>
        private async Task GetWeatherDataByZip()
        {
            _logger.LogDebug("GetWeatherDataByZip - Run Started");
            try
            {
                // loop thru zip codes
                foreach (var cfg in zipcodeConfig)
                {
                    var action = apiAction + cfg.Key + ",us" + apiKey;
                    var resp = await GetWeatherDataAsync(baseUrl, action);

                    // Store data
                    if (resp != null)
                    {
                        resp.UpdatedAt = DateTime.Now;
                        _context.WeatherData.Add(resp);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("GetWeatherDataByZip-Failed: {0}", ex.Message);
            }
        }

        /// <summary>
        ///     Configure
        /// </summary>
        private bool Configure()
        {
            _logger.LogDebug("Configure - Run Started");
            try
            {
                // Read and parse config values
                // Get path settings
                appSettings = configuration.GetSection("AppSetting");
                baseUrl = appSettings.GetValue<string>("WeatherDataBaseUrl");
                apiAction = appSettings.GetValue<string>("WeatherDataAction");
                apiKey = appSettings.GetValue<string>("WeatherDataAPIKey");
                var tempStr = appSettings.GetValue<string>("ZipCodeFreq");
                var items = tempStr.Split(",");

                foreach (var item in items)
                {
                    var tempItemStr = item.Split("|");
                    var tempItem =
                        new KeyValuePair<string, int>(tempItemStr[0], Convert.ToInt32(tempItemStr[1]));
                    zipcodeConfig.Add(tempItem);
                }

                //TODO: current only supports one timer trigger so we are setting it in code on the timer definition

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Configure-Failed: {0}", ex.Message);
                return false;
            }
        }

        /// <summary>
        ///     GetWeatherDataAsync
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private async Task<WeatherData> GetWeatherDataAsync(string BaseUrl, string BaseAction)
        {
            _logger.LogDebug("GetWeatherDataAsync - Run Started");
            WeatherData weatherData = null;
            try
            {
                var client = new RestClient();
                var request = new RestRequest(BaseUrl + BaseAction, Method.GET);
                var result = client.Execute<WeatherData>(request).Data;
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetWeatherDataAsync-Failed: {0}", ex.Message);
                return weatherData;
            }
        }
    }
}