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
            string token = HttpContext.Request.Cookies.Get("token").Value;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52778/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "bearer "+ token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.ConnectionClose = true;
                var response = client.GetAsync("car");
                var result = response.Result;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var objString = result.Content.ReadAsStringAsync().Result;
                    var obj = JsonConvert.DeserializeObject<GetResponse>(objString);
                    TempData["Mileages"] = obj.Mileages;
                    TempData["PaybackTimes"] = obj.PaybackTimes;
                    return View(obj);
                }
                else
                {
                    var errorString = result.Content.ReadAsStringAsync().Result;
                }
            }
            return View();
        }
    }
}