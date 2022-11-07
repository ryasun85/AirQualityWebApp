using AirQualityService.Models.Measurements;
using AirQualityWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirQualityWebApp.Models
{
    public class AirQualityViewModel
    {
        public AirQualityViewModel(CountriesData countriesData)
        {
           Countries = countriesData.Countries;
        
        }
      
        public string CountryCode { get; set; } //On Post 
        public List<SelectListItem> Countries { get; set; }

        public AirQualityViewModel(CitiesData citiesData)
        {        
            Cities = citiesData.Cities;
           
           
        }

        public string CityName { get; set; }

        public List<SelectListItem> Cities { get; set; }

        public AirQualityViewModel(MeasurementsDTO measurementsDTO)
        {
           //Measurements =  measurementsDTO.Results
        }
        //public List<Measurements> Measurements { get; set; }


    }
}

