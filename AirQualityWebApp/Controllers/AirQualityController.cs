using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AirQualityService.Services;
using AirQualityService.Models.Country;
using AirQualityWebApp.Models;
using System.Diagnostics.Metrics;

namespace AirQualityWebApp.Controllers
{
    public class AirQualityController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;
        private readonly IMeasurementsService _measurementsService;

        public AirQualityController(
            ICountryService countryService,
            ICityService cityService,
            IMeasurementsService measurementsService)
        {
            _countryService = countryService;
            _cityService = cityService;
            _measurementsService = measurementsService;
        }

       
        public ActionResult Countries()
        {
            var myresponse = _countryService.GetAllCountries();
            CountriesData countriesData = new CountriesData(myresponse);

            AirQualityViewModel oneViewModel = new AirQualityViewModel(countriesData);

            return View(oneViewModel);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Countries(string countryCode)
        {
            return RedirectToAction("Cities", "AirQuality", new { countryCode = countryCode });
        }

        [HttpGet]
        public ActionResult Cities(string countryCode)
        {

            var myresponse = _cityService.GetAllCitiesByCountry(countryCode);

            if (myresponse.Meta.Found == 0)
            {
                ViewBag.myErrorMsg = "The Country you have selected has no cities or measurements provided";
               
            }

            CitiesData citiesData = new CitiesData(myresponse);

            AirQualityViewModel airQualityViewModel = new AirQualityViewModel(citiesData);

            return View(airQualityViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cities(string countryCode, string cityName)
        {
            return RedirectToAction("Measurements", "AirQuality", new { countryCode = countryCode, cityName = cityName });

        }

        public ActionResult Measurements(string countryCode, string cityName)
        {
            var myresponse = _measurementsService.GetAllMeasurements(countryCode, cityName);

            MeasurementsData measurementsData = new MeasurementsData(myresponse);

            AirQualityViewModel airQualityViewModel = new AirQualityViewModel(measurementsData);

            airQualityViewModel.CityName = cityName;

            return View(airQualityViewModel);

        }
    }
}
