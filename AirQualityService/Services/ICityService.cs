using AirQualityService.Models.City;

namespace AirQualityService.Services
{
    public interface ICityService
    {
       /* IEnumerable<CityDTO>*/CityDTO GetAllCitiesByCountry(string countryCode);
    }
}