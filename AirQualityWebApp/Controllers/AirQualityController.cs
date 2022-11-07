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

        //Get List of countres and display them in dropdown
        public ActionResult Index()
        {
            var myresponse = _countryService.GetAllCountries();            
            CountriesData countriesData = new CountriesData(myresponse);

            AirQualityViewModel oneViewModel = new AirQualityViewModel(countriesData);

            return View(oneViewModel);
        }

        //Post country code back so can be used in Cities service
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(/*AirQualityViewModel airQualityViewModel, */string countryCode)
        {
           //countryCode = airQualityViewModel.CountryCode;

           return RedirectToAction("Cities", "AirQuality", new { countryCode = countryCode });
         //return RedirectToAction("Cities", "AirQuality", new { countryCode = airQualityViewModel.CountryCode });

        }

        [HttpGet]
        public ActionResult Cities(string countryCode)
        {

            var myresponse = _cityService.GetAllCitiesByCountry(countryCode);

             
            //If(myresponse.Results[0].City == null || myresponse.Results[0].City == "N/A"){ }
            if (myresponse.Meta.Found == 0)
            {
               ViewBag.myErrorMsg = "The Country you have selected has no cities or measurements provided";
               // return View(myViewModel);
            }
        
            CitiesData citiesData = new CitiesData(myresponse);

            AirQualityViewModel oneViewModel = new AirQualityViewModel(citiesData);
            
            return View(oneViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]        
        public ActionResult Cities(string countryCode, string cityName)
        {
              return RedirectToAction("Measurements", "AirQuality", new { countryCode = countryCode, cityName = cityName});
            //return RedirectToAction("Cities", "AirQuality", new { countryCode = airQualityViewModel.CountryCode });

        }

        public ActionResult Measurements(string countryCode, string cityName)
        {
            return View();
        }
        //https://localhost:7034/AirQuality/TestCityService?code=af
        public ActionResult TestCityService(string code)
        {
            var myresponse = _cityService.GetAllCitiesByCountry(code);
            return View(myresponse);
        }
        //https://localhost:7034/AirQuality/TestMeasurementsService?code=af&cityname=kabul
        public ActionResult TestMeasurementsService(string code, string cityName)
        {
            var myresponse = _measurementsService.GetAllMeasurements(code, cityName);
            return View(myresponse);
        }

    }
}
