using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AirQualityService.Models.Country;

namespace AirQualityService.Services
{
    public class CountryService : ICountryService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly ILogger<CountryService> _logger;
       
        public CountryService(ILogger<CountryService> logger)
        {
          // _httpClient.BaseAddress = new Uri("https://api.openaq.org/v2/");
            //_httpClient.Timeout = new TimeSpan(0, 0, 30);
            _httpClient.DefaultRequestHeaders.Clear();
           _logger = logger;
        }

        /// <summary>
        /// Method that returns all countries
        /// </summary>
        /// <returns>IEnumerable<CountryDTO><returns>
        public CountryDTO GetAllCountries()
        {
            return GetAllCountriesApiCall();
        }

        private CountryDTO GetAllCountriesApiCall()
        {
            CountryDTO returnValue = new CountryDTO();

            try
            {   //TODO check if can change order by Country name 
                //var response = _httpClient.GetStringAsync("https://api.openaq.org/v2/countries?limit=200&page=1&offset=0&sort=asc&order_by=country").Result;
                var response = _httpClient.GetStringAsync("https://api.openaq.org/v2/countries").Result;
        

                CountryDTO countryDTO = JsonConvert.DeserializeObject<CountryDTO>(response);

                if (!string.IsNullOrWhiteSpace(response) && countryDTO.Meta.Found > 0)
                {
                    returnValue = countryDTO;
                    _logger.LogInformation("Success!");
                }

                

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception: " + ex.Message + " Inner exception: " + ex.InnerException?.Message);
                return new CountryDTO();
            }

            return returnValue;
        }
      
    }
}
