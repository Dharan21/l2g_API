using l2g.Entities.BusinessEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace l2g.MVC.BL
{
    public class CarBL
    {
        public GetResponse GetCarData()
        {
            string token = HttpContext.Current.Request.Cookies.Get("token").Value;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52778/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.ConnectionClose = true;
                var response = client.GetAsync("car");
                var result = response.Result;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var objString = result.Content.ReadAsStringAsync().Result;
                    var obj = JsonConvert.DeserializeObject<GetResponse>(objString);
                    return obj;
                }
                else
                {
                    if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        throw new Exception("Unauthorized! Try first Login and then add details.");
                    else
                        throw new Exception("Unknown Error Occured!");
                }
            }
        }
    }
}
