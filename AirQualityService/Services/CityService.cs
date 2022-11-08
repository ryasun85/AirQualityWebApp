using AirQualityService.Models.City;
using AirQualityService.Models.Country;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirQualityService.Services
{
    public class CityService : ICityService
    {

        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly ILogger<CityService> _logger;

        public CityService(ILogger<CityService> logger)
        {
           //_httpClient.BaseAddress = new Uri("https://api.openaq.org/v2/");
            _httpClient.DefaultRequestHeaders.Clear();
            _logger = logger;
        }

        /// <summary>
        /// Method that returns all countries    
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns>CityDTO</returns>
        public CityDTO GetAllCitiesByCountry(string countryCode)
        {
            return GetCitiesByCountryApiCall(countryCode);
        }

       
        //TODO change methods async Task<CityDTO>
        private CityDTO GetCitiesByCountryApiCall(string countryCode)
        {

            CityDTO returnValue = new CityDTO();

            try
            {                        
                var response =/* await*/ _httpClient.GetStringAsync("https://api.openaq.org/v2/cities?limit=100&page=1&offset=0&sort=asc&order_by=city&country_id=" + countryCode).Result;

                CityDTO cityDTO = JsonConvert.DeserializeObject<CityDTO>(response);
                
                if (!string.IsNullOrWhiteSpace(response) && cityDTO.Meta.Found >= 0)
                {
                    returnValue = cityDTO;
                    _logger.LogInformation("Success!");
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception: " + ex.Message + " Inner exception: " + ex.InnerException?.Message);
                return new CityDTO();
            }

            return returnValue; 
        }
    }

}
