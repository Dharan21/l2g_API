using l2g.Entities.BusinessEntities;
using l2g.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace l2g.MVC.Controllers
{
    [CheckToken]
    [RoutePrefix("User")]
    public class UserController : Controller
    {
        [HttpGet]
        [Route("Personal-Details")]
        public ActionResult UserPersonalDetails()
        {
            ViewData["Username"] = HttpContext.Request.Cookies.Get("username").Value;
            return View();
        }

        [HttpPost]
        [Route("Personal-Details")]
        public ActionResult UserPersonalDetails(UserDetailsVM userVM)
        {

            //get userID
            //userVM.UserId = 11;
                if (userVM != null)
                {
                    TempData["UserPersonalData"] = userVM;
                    return RedirectToAction("UserEmploymentDetails");
                }
            ViewData["Username"] = HttpContext.Request.Cookies.Get("username").Value;
            return View();
        }

        [HttpGet]
        [Route("Employment-Details")]
        public ActionResult UserEmploymentDetails()
        {
            ViewData["Username"] = HttpContext.Request.Cookies.Get("username").Value;
            return View();
        }

        [HttpPost]
        [Route("Employment-Details")]
        public ActionResult UserEmploymentDetails(UserEmploymentDetailsVM userVM)
        {
            // get userID
            //userVM.UserId = 11;
            //from employees status type get id of status type
            //from employee contract type get id of contract type

            if (userVM != null)
            {
                TempData["UserEmploymentData"] = userVM;
                return RedirectToAction("UserBankDetails");
            }
            ViewData["Username"] = HttpContext.Request.Cookies.Get("username").Value;
            return View();
        }

        [HttpGet]
        [Route("Bank-Details")]
        public ActionResult UserBankDetails() 
        {
            ViewData["Username"] = HttpContext.Request.Cookies.Get("username").Value;
            return View();
        }

        [HttpPost]
        [Route("Bank-Details")]
        public ActionResult UserBankDetails(UserBankDetailsVM userVM) 
        {
            //get userID
            //userVM.UserId = 11;
            if (userVM != null)
            {
                TempData["UserBankData"] = userVM;
                //return RedirectToAction("Index", "Quote");
            }
            ViewData["Username"] = HttpContext.Request.Cookies.Get("username").Value;
            return View();
        }
    }
}