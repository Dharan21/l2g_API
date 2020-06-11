using l2g.Entities.BusinessEntities;
using l2g.Entities.ValidationEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace l2g.MVC.BL
{
    public class AuthBL
    {
        public async Task<ErrorResponseVM> RegisterAsync(UserVM user)
        {
            using (var client = new HttpClient())
            {
                var errorRes = new ErrorResponseVM();
                client.BaseAddress = new Uri("http://localhost:52778/");
                var content = JsonConvert.SerializeObject(user);
                HttpContent c = new StringContent(content, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("api/auth", c);
                if (!response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    var obj = JsonConvert.DeserializeObject<ErrorRes>(result);
                    errorRes.Errors = JsonConvert.DeserializeObject<Error[]>(obj.Message).ToList();
                }
                return errorRes;
            }
        }

        public async Task<bool> LoginAsync(LoginVM user)
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

                    AddCookie("token", obj.access_token, obj.expires_in);
               
                    AddCookie("username", user.Username, obj.expires_in);
                }
                return response.IsSuccessStatusCode;
            }
        }

        public void Logout()
        {
            RemoveCookie("token");
            RemoveCookie("username");
        }

        public static void AddCookie(string name, string value, int expires_in)
        {
            HttpCookie cookie = new HttpCookie(name, value);
            cookie.Expires = DateTime.Now.AddSeconds(expires_in);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static void RemoveCookie(string name)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(name);
            cookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}
