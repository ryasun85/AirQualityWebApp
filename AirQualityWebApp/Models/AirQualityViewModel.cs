using AirQualityService.Models.Measurements;
using AirQualityWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AirQualityWebApp.Models
{
    public class AirQualityViewModel
    {
        public AirQualityViewModel(CountriesData countriesData)
        {
            Countries = countriesData.Countries;

        }

        public string CountryCode { get; set; }
        public List<SelectListItem> Countries { get; set; }

        public AirQualityViewModel(CitiesData citiesData)
        {
            Cities = citiesData.Cities;

        }

        public string CityName { get; set; }

        public List<SelectListItem> Cities { get; set; }

        public AirQualityViewModel(MeasurementsData measurementsData)
        {
            Measurements = measurementsData.Measurements;
        }
        public List<Measurement> Measurements { get; set; }

    }

    public class Measurement
    {
        public string Parameter { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0.000#}")]
        public double Value { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Unit { get; set; }
        public string Location { get; set; }
    }

    public class Locations
    {
        public string Location { get; set; }
        public List<Measurement> Measurements { get; set; }

    }
}

