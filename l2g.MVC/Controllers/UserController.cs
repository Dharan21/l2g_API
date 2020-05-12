using l2g.Entities.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace l2g.MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: UserDetails
        public ActionResult UserPersonalDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserPersonalDetails(UserDetailsVM userVM)
        {

            //get userID
            //userVM.UserId = 11;
            if (userVM != null)
            {
                TempData["UserPersonalData"] = userVM;
                return RedirectToAction("UserEmploymentDetails");
            }
            return View();
        }

        public ActionResult UserEmploymentDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserEmploymentDetails(UserEmploymentDetailsVM userVM)
        {
            // get userID
            //userVM.UserId = 11;
            //from employees tatus type get id of status type
            //from employee contract type get id of contract type

            if (userVM != null)
            {
                TempData["UserEmploymentData"] = userVM;
                return RedirectToAction("UserBankDetails");
            }
            return View();
        }

        public ActionResult UserBankDetails() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserBankDetails(UserBankDetailsVM userVM) 
        {
            //get userID
            //userVM.UserId = 11;
            if (userVM != null)
            {
                TempData["UserBankData"] = userVM;
                //return RedirectToAction("Index", "Quote");          
            }
            return View();
        }
    }
}