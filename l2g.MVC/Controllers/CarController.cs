using l2g.Entities.BusinessEntities;
using l2g.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
                string token = HttpContext.Request.Cookies.Get("token").Value;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:52778/api/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.ConnectionClose = true;
                    var response = client.GetAsync("car");
                    var result = response.Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var objString = result.Content.ReadAsStringAsync().Result;
                        var obj = JsonConvert.DeserializeObject<GetResponse>(objString);
                        TempData["Data"] = obj;
                        return View(obj);
                    }
                    else
                    {
                        if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            ViewData["Error"] = "Unauthorized! Try first Login and then add details.";
                        else
                            ViewData["Error"] = "Unknown Error Occured!";
                        return View();
                    }
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
                {
                    List<string> tempList = temp.ToList();
                    tempList.Remove(temp[0]);
                    string model = string.Join(" ", tempList);
                    selectedModels.Add(model);
                }
                else if(temp[0] == "brand")
                {
                    List<string> tempList = temp.ToList();
                    tempList.Remove(temp[0]);
                    string model = string.Join(" ", tempList);
                    selectedBrands.Add(temp[1]);
                }
                else if(temp[0] == "fuel")
                {
                    List<string> tempList = temp.ToList();
                    tempList.Remove(temp[0]);
                    string model = string.Join(" ", tempList);
                    selectedFuels.Add(temp[1]);
                }
                else if(temp[0] == "gearbox")
                {
                    List<string> tempList = temp.ToList();
                    tempList.Remove(temp[0]);
                    string model = string.Join(" ", tempList);
                    selectedGearboxes.Add(temp[1]);
                }
                else if(temp[0] == "range")
                {
                    List<string> tempList = temp.ToList();
                    tempList.Remove(temp[0]);
                    string model = string.Join(" ", tempList);
                    selectedPriceRanges.Add(temp[1]);
                }
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
                string token = HttpContext.Request.Cookies.Get("token").Value;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:52778/api/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.ConnectionClose = true;
                    var response = client.GetAsync("car");
                    var result = response.Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var objString = result.Content.ReadAsStringAsync().Result;
                        var obj = JsonConvert.DeserializeObject<GetResponse>(objString);
                        TempData["Data"] = obj;
                        return View(obj);
                    }
                    else
                    {
                        if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            ViewData["Error"] = "Unauthorized! Try first Login and then add details.";
                        else
                            ViewData["Error"] = "Unknown Error Occured!";
                        return View();
                    }
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
                string token = HttpContext.Request.Cookies.Get("token").Value;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:52778/api/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.ConnectionClose = true;
                    var response = client.GetAsync("car");
                    var result = response.Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var objString = result.Content.ReadAsStringAsync().Result;
                        var obj = JsonConvert.DeserializeObject<GetResponse>(objString);
                        TempData["Data"] = obj;
                        car = obj.Cars.AsQueryable().Where(x => x.CarId == id).First();
                        ViewData["Mileages"] = obj.Mileages;
                        ViewData["PaybackTimes"] = obj.PaybackTimes;
                    }
                    else
                    {
                        if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            ViewData["Error"] = "Unauthorized! Try first Login and then add details.";
                        else
                            ViewData["Error"] = "Unknown Error Occured!";
                        return View();
                    }
                }
            }
            else
            {
                ViewData["Mileages"] = data.Mileages;
                ViewData["PaybackTimes"] = data.PaybackTimes;
                car = data.Cars.AsQueryable().Where(x => x.CarId == id).First();
            }
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