using AirQualityService.Models.City;
using AirQualityService.Models.Country;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirQualityWebApp.Models
{
    public class CitiesData
    {
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
