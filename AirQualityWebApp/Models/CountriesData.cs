using AirQualityService.Models.Country;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirQualityWebApp.Models
{
    public class CountriesData
    {
        public CountriesData(CountryDTO countryDTO)
        {
            foreach (var item in countryDTO.Results)
            {
                SelectListItem listItem = new SelectListItem();
                listItem.Text = item.Name; 
                listItem.Value = item.Code;
               
                Countries.Add(listItem);
                
            }

            
        }

        public List<SelectListItem> Countries { get; set; }

        //public string CountryName { get; set; }
        //public string CountryCode { get; set; }
        public int Cities { get; set; }
    }
}
