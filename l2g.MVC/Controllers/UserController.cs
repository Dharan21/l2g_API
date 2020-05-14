using l2g.Entities.BusinessEntities;
using l2g.Entities.ValidationEntities;
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
    [RoutePrefix("User")]
    public class UserController : Controller
    {
        [HttpGet]
        [Route("Personal-Details")]
        public ActionResult UserPersonalDetails()
        {
            ViewData["Username"] = HttpContext.Request.Cookies.Get("username").Value;
            string token = HttpContext.Request.Cookies.Get("token").Value;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52778/user/");
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.ConnectionClose = true;
                var response = client.GetAsync("getUserDetails");
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

        [HttpPost]
        [Route("Personal-Details")]
        public async System.Threading.Tasks.Task<ActionResult> UserPersonalDetails(UserDetailsVM userVM)
        {
            ViewData["Username"] = HttpContext.Request.Cookies.Get("username").Value;
            if (ModelState.IsValid)
            {
                string token = HttpContext.Request.Cookies.Get("token").Value;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:52778/user/");
                    client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                    var content = JsonConvert.SerializeObject(userVM);
                    HttpContent c = new StringContent(content, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync("addUserDetails", c);
                    if (response.IsSuccessStatusCode)
                        return RedirectToAction("UserEmploymentDetails");
                    else
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            ViewData["Error"] = "Unauthorized! Try first Login and then add details.";
                        else
                            ViewData["Error"] = "Unknown Error Occured!";
                        return View();
                    }          
                }
                
            }
            return View();
        }

        [HttpGet]
        [Route("Employment-Details")]
        public ActionResult UserEmploymentDetails()
        {
            ViewData["Username"] = HttpContext.Request.Cookies.Get("username").Value;
            string token = HttpContext.Request.Cookies.Get("token").Value;
            if (TempData.Peek("EmploymentDropdowns") == null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:52778/user/");
                    client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.ConnectionClose = true;
                    var response = client.GetAsync("getEmploymentDropdowns");
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var objString = result.Content.ReadAsStringAsync().Result;
                        var obj = JsonConvert.DeserializeObject<EmploymentDropdowns>(objString);
                        TempData["EmploymentDropdowns"] = obj;
                    }
                }
            }
            ViewBag.Contracts = new SelectList((TempData.Peek("EmploymentDropdowns") as EmploymentDropdowns).Contracts, "ContractId", "ContractType");
            ViewBag.EmployeeStatues = new SelectList((TempData.Peek("EmploymentDropdowns") as EmploymentDropdowns).Statuses, "EmployeeStatusId", "EmployeeStatusType");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52778/user/");
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.ConnectionClose = true;
                var response = client.GetAsync("getEmploymentDetails");
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var objString = result.Content.ReadAsStringAsync().Result;
                    var obj = JsonConvert.DeserializeObject<UserEmploymentDetailsVM>(objString);
                    GetUserEmploymentDetails user = new GetUserEmploymentDetails()
                    {
                        Company = obj.Company,
                        ContractId = obj.ContractId,
                        CreditScore = obj.CreditScore,
                        EmployeeStatusId = obj.EmployeeStatusId,
                        Salary = obj.Salary
                    };
                    return View(user);
                }
            }
            return View();
        }

        [HttpPost]
        [Route("Employment-Details")]
        public async System.Threading.Tasks.Task<ActionResult> UserEmploymentDetailsAsync(GetUserEmploymentDetails userVM)
        {
            if (ModelState.IsValid)
            {
                string token = HttpContext.Request.Cookies.Get("token").Value;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:52778/user/");
                    client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                    var content = JsonConvert.SerializeObject(userVM);
                    HttpContent c = new StringContent(content, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync("addEmploymentDetails", c);
                    if (response.IsSuccessStatusCode)
                        return RedirectToAction("UserBankDetails");
                    else
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            ViewData["Error"] = "Unauthorized! Try first Login and then add details.";
                        else
                            ViewData["Error"] = "Unknown Error Occured!";
                        return View();
                    }
                }
            }
            ViewData["Username"] = HttpContext.Request.Cookies.Get("username").Value;
            return View();
        }

        [HttpGet]
        [Route("Bank-Details")]
        public ActionResult UserBankDetails() 
        {
            ViewData["Username"] = HttpContext.Request.Cookies.Get("username").Value;
            ViewData["Errors"] = new Error[0];
            string token = HttpContext.Request.Cookies.Get("token").Value;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52778/user/");
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.ConnectionClose = true;
                var response = client.GetAsync("getBankDetails");
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var objString = result.Content.ReadAsStringAsync().Result;
                    var obj = JsonConvert.DeserializeObject<UserBankDetailsVM>(objString);
                    GetUserBankDetails user = new GetUserBankDetails() 
                    {
                        AccountHolderName = obj.AccountHolderName,
                        AccountNo = obj.AccountNo,
                        AccountType = obj.AccountType
                    };
                    return View(user);
                }
            }
            return View();
        }
    
        [HttpPost]
        [Route("Bank-Details")]
        public async System.Threading.Tasks.Task<ActionResult> UserBankDetails(GetUserBankDetails userVM) 
        {
            ViewData["Username"] = HttpContext.Request.Cookies.Get("username").Value;
            if (ModelState.IsValid)
            {
                string token = HttpContext.Request.Cookies.Get("token").Value;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:52778/user/");
                    client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                    var content = JsonConvert.SerializeObject(userVM);
                    HttpContent c = new StringContent(content, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync("addBankDetails", c);
                    if (response.IsSuccessStatusCode)
                        return RedirectToAction("QuoteDetails", "Quote");
                    else
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            ViewData["Error"] = "Unauthorized! Try first Login and then add details.";
                        else if(response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                        {
                            var errorString = response.Content.ReadAsStringAsync().Result;
                            var error = JsonConvert.DeserializeObject<ErrorRes>(errorString);
                            ViewData["Errors"] = JsonConvert.DeserializeObject<Error[]>(error.Message);
                        }
                        else
                            ViewData["Error"] = "Unknown Error Occured!";
                        return View();
                    }
                }

            }
            return View();
        }
    }
}