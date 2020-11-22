using l2g.Entities.BusinessEntities;
using l2g.MVC.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace l2g.MVC.Controllers
{
    [RoutePrefix("Auth")]
    public class AuthController : Controller
    {
        // GET: Default
        [Route("Register")]
        [HttpGet]
        public ActionResult Register()
        {
            ViewData["Errors"] = new List<Error>();
            return View();
        }

        [Route("Register")]
        [HttpPost]
        public async Task<ActionResult> Register(UserVM user)
        {
            if (ModelState.IsValid)
            {
                AuthBL auth = new AuthBL();
                ErrorResponseVM response = await auth.RegisterAsync(user);
                if (response.IsValid)
                    return RedirectToAction("Login");
                else
                    ViewData["Errors"] = response.Errors;
            }
            return View();
        }

        [Route("Login")]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult> Login(LoginVM user)
        {
            if (ModelState.IsValid)
            {
                AuthBL auth = new AuthBL();
                bool isSuccess = await auth.LoginAsync(user);
                if(isSuccess)
                    return RedirectToAction("Home", "Car");
                else
                    ViewBag.Error = "Username or Password is incorrect!";
            }
            return View();
        }

        [Route("Forgot-Password")]
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpGet]
        [Route("Logout")]
        public ActionResult Logout()
        {
            AuthBL auth = new AuthBL();
            auth.Logout();
            return RedirectToAction("Login");
        }
    }
}