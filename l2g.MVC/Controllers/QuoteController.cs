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
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52778/quote/");
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.ConnectionClose = true;
                var response = client.GetAsync("getQuoteDetails");
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var objString = result.Content.ReadAsStringAsync().Result;
                    var obj = JsonConvert.DeserializeObject<UserDetailsVM>(objString);
                    return View(obj);
                }
            }
            return View();
        }

        //[HttpPost]
        //[Route("Details")]
        //public async System.Threading.Tasks.Task<ActionResult> QuoteDetails(GetQuoteDetails quoteVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string token = HttpContext.Request.Cookies.Get("token").Value;
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri("http://localhost:52778/quote/");
        //            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
        //            var content = JsonConvert.SerializeObject(quoteVM);
        //            HttpContent c = new StringContent(content, Encoding.UTF8, "application/json");
        //            HttpResponseMessage response = await client.PostAsync("SaveQuoteDetails", c);
        //            if (response.IsSuccessStatusCode) { }
        //            //return RedirectToAction("UserBankDetails");
        //            else
        //            {
        //                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        //                    ViewData["Error"] = "Unauthorized! Try first Login and then add details.";
        //                else
        //                    ViewData["Error"] = "Unknown Error Occured!";
        //                return View();
        //            }
        //        }
        //    }
        //    ViewData["Username"] = HttpContext.Request.Cookies.Get("username").Value;
        //    return View();
        //}
    }
}