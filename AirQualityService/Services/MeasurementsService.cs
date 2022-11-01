using AirQualityService.Models.City;
using AirQualityService.Models.Measurements;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirQualityService.Services
{
    public class MeasurementsService : IMeasurementsService
    {

        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly ILogger<MeasurementsService> _logger;

        public MeasurementsService(ILogger<MeasurementsService> logger)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _logger = logger;
        }


        public MeasurementsDTO GetAllMeasurements(string countryCode, string cityName)
        {
            return GetAllMeasurementsApiCall(countryCode, cityName);
        }

        //https://localhost:7034/AirQuality/TestCityService?code=af
        private MeasurementsDTO GetAllMeasurementsApiCall(string countryCode, string cityName)
        {

            MeasurementsDTO returnValue = new MeasurementsDTO();

            try
            {
                   //var response = _httpClient.GetStringAsync("https://api.openaq.org/v2/latest?limit=100&page=1&offset=0&sort=desc&radius=1000&order_by=lastUpdated&dumpRaw=false&country_id=GB&city=Manchester
   
                 var response = _httpClient.GetStringAsync("https://api.openaq.org/v2/latest?limit=100&page=1&offset=0&sort=desc&radius=1000&order_by=lastUpdated&dumpRaw=false&country_id=" + countryCode + "&city=" + cityName).Result;

                MeasurementsDTO measurementsDTO = JsonConvert.DeserializeObject<MeasurementsDTO>(response);

                if (!string.IsNullOrWhiteSpace(response) && measurementsDTO.Meta.Found > 0)
                {
                    returnValue = measurementsDTO;
                    _logger.LogInformation("Success!");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception: " + ex.Message + " Inner exception: " + ex.InnerException?.Message);
                return new MeasurementsDTO();
            }

            return returnValue; //returns all measurements for particular country and city  
        }
    }
}
