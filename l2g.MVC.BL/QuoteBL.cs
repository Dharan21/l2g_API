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
    public class QuoteBL
    {
        public UserDetailsFullVM GetUserDetails()
        {
            string token = HttpContext.Current.Request.Cookies.Get("token").Value;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52778/user/");
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.ConnectionClose = true;
                var response = client.GetAsync("getAll");
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var objString = result.Content.ReadAsStringAsync().Result;
                    var obj = JsonConvert.DeserializeObject<UserDetailsFullVM>(objString);
                    return obj;
                }
                else
                {
                    if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
                        throw new Exception("User Not Found");
                    else if(result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        throw new Exception("Unauthorized! Try first Login and then add details.");
                    else
                        throw new Exception("Unknown Error Occured!");
                }
            }
        } 

        public ConfirmQuote CreateConfirmQuoteObject(GetQuote quote, GetResponse allData, UserDetailsFullVM userData)
        {
            ConfirmQuote confirmQuoteDetails = new ConfirmQuote();
            confirmQuoteDetails.User = userData;
            confirmQuoteDetails.Car = allData.Cars.AsQueryable().Where(x => x.CarId == quote.CarId).First();
            confirmQuoteDetails.Mileage = allData.Mileages.AsQueryable().Where(x => x.MileageId == quote.MileageId).First();
            confirmQuoteDetails.PaybackTime = allData.PaybackTimes.AsQueryable().Where(x => x.MonthId == quote.MonthId).First();
            confirmQuoteDetails.Price = quote.Price;
            return confirmQuoteDetails;
        }
    }
}
