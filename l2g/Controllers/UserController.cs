using l2g.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace l2g.Controllers
{
    public class UserController : ApiController
    {
        [EnableCors("*", "*", "*")]
        public async Task<IHttpActionResult> GetPassword(string email)
            {
            //string email = "bhavya0598@gmail.com";
            UserBL userBL = new UserBL();
            await userBL.SendEmail(email);
            return Ok();
        }
    }
}
