using AirQualityService.Models.City;
using AirQualityService.Models.Measurements;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace AirQualityWebApp.Models
{
    /// <summary>
    /// this class' function is getting only required data from DTO 
    /// rather than everything. Only this data will be passed onto viewModel
    /// </summary>
    public class MeasurementsData
    {
        public MeasurementsData(MeasurementsDTO measurementsDTO)
        {

            Measurements = new List<Measurement>();

            foreach (var measure in measurementsDTO.Results)
            {

                foreach (var parameter in measure.Measurements)
                {
                    Measurement measurement = new Measurement();

                    measurement.Location = measure.Location;
                    measurement.Parameter = parameter.Parameter;
                    measurement.Value = parameter.Value;
                    measurement.Unit = parameter.Unit;
                    measurement.LastUpdated = parameter.LastUpdated;

                    Measurements.Add(measurement);
                }
                                
            }
        }
      
        public List<Measurement> Measurements { get; set; }
    }
}
