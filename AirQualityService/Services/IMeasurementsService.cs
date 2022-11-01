using AirQualityService.Models.Measurements;

namespace AirQualityService.Services
{
    public interface IMeasurementsService
    {
        MeasurementsDTO GetAllMeasurements(string countryCode, string cityName);
    }
}