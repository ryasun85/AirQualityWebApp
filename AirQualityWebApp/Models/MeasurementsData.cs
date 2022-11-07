using AirQualityService.Models.City;
using AirQualityService.Models.Measurements;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirQualityWebApp.Models
{
    public class MeasurementsData
    {
        public MeasurementsData(MeasurementsDTO measurementsDTO)
        {
            
            Measurements = new List<SelectListItem>();

            foreach (var item in measurementsDTO.Results)
            {

                SelectListItem listItem = new SelectListItem();

                //Populate all params prom the measureements
               // listItem.Text = item.Measurements.;
                //listItem.Value = item.Measurements;
                //listItem.Text = item.Country;
                //listItem.Value = item.Country;

               Measurements.Add(listItem);

            }
            }
        public List<SelectListItem> Measurements { get; set; }
    }
}
