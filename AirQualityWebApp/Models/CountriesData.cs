using AirQualityService.Models.Country;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirQualityWebApp.Models
{    /// <summary>
     /// this class function is getting only required data from DTO 
     /// rather than everything. Only this data will be passed onto the viewModel
     /// </summary>
    public class CountriesData
    {
        public CountriesData(CountryDTO countryDTO)
        {
            Countries = new List<SelectListItem>();

            foreach (var item in countryDTO.Results)
            {
                     
                SelectListItem listItem = new SelectListItem();
              
                listItem.Text = item.Name; 
                listItem.Value = item.Code;
               
                Countries.Add(listItem);
                
            }
                       
        }

        public List<SelectListItem> Countries { get; set; }         
    }
}
