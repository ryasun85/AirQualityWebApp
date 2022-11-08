using AirQualityService.Models.City;

namespace AirQualityService.Services
{
    public interface ICityService
    {
        CityDTO GetAllCitiesByCountry(string countryCode);
    }
}