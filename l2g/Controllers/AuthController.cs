using l2g.BL;
using l2g.Entities.BusinessEntities;
using l2g.Entities.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace l2g.Controllers
{
    public class AuthController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Register(UserVM userVM)
        {
            AuthBL authBL = new AuthBL();
            ErrorResponseVM response = authBL.Register(userVM);
            if (response.isInternalServerError)
                return InternalServerError();
            if (response.isSuccess)
                return Ok();
            if (!response.isValid)
                return BadRequest(JsonConvert.SerializeObject(response.errors));
            return Ok();
        }
    }
}
