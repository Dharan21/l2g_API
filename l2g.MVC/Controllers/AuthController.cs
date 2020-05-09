using l2g.Entities.BusinessEntities;
using l2g.Entities.ValidationEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace l2g.MVC.Controllers
{
    [RoutePrefix("auth")]
    public class AuthController : Controller
    {
        // GET: Default
        [Route("sign-up")]
        [HttpGet]
        public ActionResult Register()
        {
            ViewData["Errors"] = new Error[0];
            return View();
        }

        [Route("sign-up")]
        [HttpPost]
        public async Task<ActionResult> Register(UserVM user)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:52778/");
                    var content = JsonConvert.SerializeObject(user);
                    HttpContent c = new StringContent(content, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync("api/auth", c);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("login");
                    }
                    else
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        var obj = JsonConvert.DeserializeObject<ErrorRes>(result);
                        ViewData["Errors"] = JsonConvert.DeserializeObject<Error[]>(obj.Message);
                        return View();
                    }
                }
            }
            return View();
        }

        [Route("login")]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> Login(LoginVM user)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:52778/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    var request = new HttpRequestMessage(HttpMethod.Post, "token");
                    var keyValues = new List<KeyValuePair<string, string>>();
                    keyValues.Add(new KeyValuePair<string, string>("username", user.Username));
                    keyValues.Add(new KeyValuePair<string, string>("password", user.Password));
                    keyValues.Add(new KeyValuePair<string, string>("grant_type", "password"));
                   
                    request.Content = new FormUrlEncodedContent(keyValues);
                    var response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        var obj = JsonConvert.DeserializeObject<TokenRes>(result);
                        
                        HttpCookie cookie = new HttpCookie("token");
                        cookie.Value = obj.access_token;
                        cookie.Expires = DateTime.Now.AddSeconds(obj.expires_in);
                        Response.Cookies.Add(cookie);

                        return RedirectToAction("Home", "Car");
                    }
                    else
                    {
                        ViewBag.Error = "Username or Password is incorrect!";
                    }
                }
            }
            return View();
        }

        [Route("forgot-password")]
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}