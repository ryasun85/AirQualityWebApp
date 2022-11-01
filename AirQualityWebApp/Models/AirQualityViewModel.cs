using AirQualityWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirQualityWebApp.Models
{
    public class AirQualityViewModel
    {
        public AirQualityViewModel(/*middleClass*/CountriesData countriesData)
        {
            Countries = countriesData.Countries;
            //CityName = Dto.city_name;
        }
        //CountryCode

       public List<SelectListItem> Countries { get; set; }

        //public string CityName { get; set; }
        //public List<SelectListItem> Cities { get; set; }

        //CountryCode
    }
}

//CountryCode = countriesData.Countries
//            CityName = countriesData.Countries
//            Countries = countriesData.Countries;