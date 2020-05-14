using l2g.Entities.BusinessEntities;
using l2g.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace l2g.MVC.Controllers
{
    [CheckToken]
    [RoutePrefix("Quote")]
    public class QuoteController : Controller
    {
        // GET: Quote
        [HttpGet]
        [Route("Details")]
        public ActionResult QuoteDetails()
        {
            ViewData["Username"] = HttpContext.Request.Cookies.Get("username").Value;
            string token = HttpContext.Request.Cookies.Get("token").Value;
            if (TempData.Peek("Quote") == null || TempData.Peek("Data") == null)
            {
                return RedirectToAction("Home", "Car");
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52778/user/");
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.ConnectionClose = true;
                var response = client.GetAsync("getAll");
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var objString = result.Content.ReadAsStringAsync().Result;
                    var obj = JsonConvert.DeserializeObject<UserDetailsFullVM>(objString);
                    GetQuote quote = (GetQuote)TempData.Peek("Quote");
                    GetResponse allData = (GetResponse)TempData.Peek("Data");
                    ConfirmQuote confirmQuoteDetails = new ConfirmQuote();
                    confirmQuoteDetails.User = obj;
                    confirmQuoteDetails.Car = allData.Cars.AsQueryable().Where(x => x.CarId == quote.CarId).First();
                    confirmQuoteDetails.Mileage = allData.Mileages.AsQueryable().Where(x => x.MileageId == quote.MileageId).First();
                    confirmQuoteDetails.PaybackTime = allData.PaybackTimes.AsQueryable().Where(x => x.MonthId == quote.MonthId).First();
                    confirmQuoteDetails.Price = quote.Price;
                    ViewData["quote"] = quote;
                    ViewData["token"] = token;
                    return View(confirmQuoteDetails);
                }
            }
            return View();
        }

        [HttpGet]
        [Route("Temp")]
        public ActionResult DestroyTempData()
        {
            _ = TempData["Quote"];
            return RedirectToAction("Index", "Home");
        }
    }
}