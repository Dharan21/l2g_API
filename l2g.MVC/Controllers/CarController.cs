using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace l2g.MVC.Controllers
{
    [RoutePrefix("car")]
    public class CarController : Controller
    {
        // GET: Car
        [HttpGet]
        [Route("filter-page")]
        public ActionResult FilterPage()
        {
            return View();
        }
    }
}