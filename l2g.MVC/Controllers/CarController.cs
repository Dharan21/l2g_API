using l2g.Entities.BusinessEntities;
using l2g.MVC.BL;
using l2g.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace l2g.MVC.Controllers
{
    [RoutePrefix("Car")]
    public class CarController : Controller
    {
        // GET: Car
        [HttpGet]
        [Route("Home")]
        [CheckToken]
        public ActionResult Home()
        {
            ViewData["Username"] = HttpContext.Request.Cookies.Get("username").Value;
            GetResponse data = (GetResponse)TempData.Peek("Data");
            if (data == null)
            {
                CarBL carBL = new CarBL();
                try
                {
                    data = carBL.GetCarData();
                    TempData["Data"] = data;
                }
                catch(Exception e)
                {
                    ViewData["Error"] = e.Message;
                }
            }
            return View(data);
        }

        [Route("Home")]
        [HttpPost]
        public ActionResult Home(FormCollection form)
        {
            string[] keys = form.AllKeys;
            List<string> selectedModels = new List<string>();
            List<string> selectedBrands = new List<string>();
            List<string> selectedFuels = new List<string>();
            List<string> selectedGearboxes = new List<string>();
            List<string> selectedPriceRanges = new List<string>();
            foreach(string key in keys)
            {
                string[] temp = key.Split(' ');
                if (temp[0] == "model")
                    selectedModels.Add(form[key]);
                else if(temp[0] == "brand")
                    selectedBrands.Add(form[key]);
                else if(temp[0] == "fuel")
                    selectedFuels.Add(form[key]);
                else if(temp[0] == "gearbox")
                    selectedGearboxes.Add(form[key]);
                else if(temp[0] == "range")
                    selectedPriceRanges.Add(form[key]);
            }
            TempData["SelectedModels"] = selectedModels;
            TempData["SelectedBrands"] = selectedBrands;
            TempData["SelectedFuelTypes"] = selectedFuels;
            TempData["SelectedGearboxTypes"] = selectedGearboxes;
            TempData["SelectedPriceRangeIndexes"] = selectedPriceRanges;
            return RedirectToAction("CarList");
        }

        [HttpGet]
        [CheckToken]
        [Route("List")]
        public ActionResult CarList()
        {
            ViewData["SelectedModels"] = TempData.Peek("SelectedModels"); 
            ViewData["SelectedBrands"] = TempData.Peek("SelectedBrands");
            ViewData["SelectedFuelTypes"] = TempData.Peek("SelectedFuelTypes");
            ViewData["SelectedGearboxTypes"] = TempData.Peek("SelectedGearboxTypes");
            ViewData["SelectedPriceRangeIndexes"] = TempData.Peek("SelectedPriceRangeIndexes");
            ViewData["Username"] = HttpContext.Request.Cookies.Get("username").Value;
            GetResponse data = (GetResponse)TempData.Peek("Data");
            if (data == null)
            {
                CarBL carBL = new CarBL();
                try
                {
                    data = carBL.GetCarData();
                    TempData["Data"] = data;
                }
                catch (Exception e)
                {
                    ViewData["Error"] = e.Message;
                    // redirect to error page with error message
                }
            }
            return View(data);
        }

        [HttpGet]
        [Route("Select-Mileage-And-PaybackTime")]
        [CheckToken]
        public ActionResult SelectMileageAndPaybackTime(int? id)
        {
            id = id ?? 1;
            ViewData["Username"] = HttpContext.Request.Cookies.Get("username").Value;
            GetResponse data = TempData.Peek("Data") as GetResponse;
            CarVM car = new CarVM();
            if (data == null)
            {
                CarBL carBL = new CarBL();
                try
                {
                    data = carBL.GetCarData();
                    TempData["Data"] = data;
                }
                catch (Exception e)
                {
                    ViewData["Error"] = e.Message;
                    // redirect to error page with error message
                }
            }
            ViewData["Mileages"] = data.Mileages;
            ViewData["PaybackTimes"] = data.PaybackTimes;
            car = data.Cars.AsQueryable().Where(x => x.CarId == id).First();
            ViewData["Car"] = car;
            return View();
        }

        [HttpPost]
        [Route("Select-Mileage-And-PaybackTime")]
        [CheckToken]
        public ActionResult SelectMileageAndPaybackTime(GetQuote quote)
        {
            if (quote !=null)
            {
                TempData["Quote"] = quote;
                return RedirectToAction("UserPersonalDetails", "User");
            }
            
            // return RedirectToAction personal details page
            return View();
        }
    }
}