using AirQualityService.Models.City;
using AirQualityService.Models.Country;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirQualityWebApp.Models
{
    public class CitiesData
    {
        /// <summary>
        /// this class function is getting only required data from DTO 
        /// rather than everything. Only this data will be passed onto the viewModel
        /// </summary>
        public CitiesData(CityDTO cityDTO)
        {
            Cities = new List<SelectListItem>();

            foreach (var item in cityDTO.Results)
            {

                SelectListItem listItem = new SelectListItem();

                listItem.Text = item.City;
                listItem.Value = item.City;

                Cities.Add(listItem);

            }

        }

        public List<SelectListItem> Cities { get; set; }
    }
}
