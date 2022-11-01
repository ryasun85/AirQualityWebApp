using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AirQualityService.Services;
using AirQualityService.Models.Country;

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

        //TEST METHOD
        public ActionResult TestCountryService()
        {
            List<CountryDTO> myList = new List<CountryDTO>();
            var myresponse = _countryService.GetAllCountries();
            return View(myresponse);
        }

        //  foreach (var myDto in myList.ToList())
        //    {
        //        var myresponse = _countryService.GetAllCountries();
        //CountryDTO countryDTO = new CountryDTO(myresponse);

        //myList.Add(countryDTO);


        //    }         
            //return View(myList);

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

        #region
        // GET: AirQualityController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //    // GET: AirQualityController/Details/5
        //    public ActionResult Details(int id)
        //    {
        //        return View();
        //    }

        //    // GET: AirQualityController/Create
        //    public ActionResult Create()
        //    {
        //        return View();
        //    }

        //    // POST: AirQualityController/Create
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Create(IFormCollection collection)
        //    {
        //        try
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }

        //    // GET: AirQualityController/Edit/5
        //    public ActionResult Edit(int id)
        //    {
        //        return View();
        //    }

        //    // POST: AirQualityController/Edit/5
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit(int id, IFormCollection collection)
        //    {
        //        try
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }

        //    // GET: AirQualityController/Delete/5
        //    public ActionResult Delete(int id)
        //    {
        //        return View();
        //    }

        //    // POST: AirQualityController/Delete/5
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Delete(int id, IFormCollection collection)
        //    {
        //        try
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }
        #endregion
    }
}
