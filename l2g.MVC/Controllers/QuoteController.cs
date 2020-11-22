using l2g.Entities.BusinessEntities;
using l2g.MVC.BL;
using l2g.MVC.Models;
using System;
using System.Collections.Generic;
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
            QuoteBL quoteBL = new QuoteBL();
            UserDetailsFullVM data = new UserDetailsFullVM(); ;
            try
            {
                data = quoteBL.GetUserDetails();
            }
            catch(Exception e)
            {
                ViewData["Error"] = e.Message;
                // redirect to error page
            }
            GetQuote quote = (GetQuote)TempData.Peek("Quote");
            GetResponse allData = (GetResponse)TempData.Peek("Data");
            ConfirmQuote confirmQuoteDetails = quoteBL.CreateConfirmQuoteObject(quote, allData, data);
            ViewData["quote"] = quote;
            ViewData["token"] = token;
            return View(confirmQuoteDetails);
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