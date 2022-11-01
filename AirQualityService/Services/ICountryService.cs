using AirQualityService.Models.Country;

namespace AirQualityService.Services
{
    public interface ICountryService
    {
        CountryDTO GetAllCountries();
    }
}