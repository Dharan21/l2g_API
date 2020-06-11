using l2g.BL;
using l2g.BL.Interfaces;
using l2g.Entities.BusinessEntities;
using l2g.Entities.ValidationEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace l2g.Controllers
{
    public class AuthController : ApiController
    {
        private IAuthBL _authBL;

        public AuthController(IAuthBL authBL) 
        {
            _authBL = authBL;
        }

        [HttpPost]
        public IHttpActionResult Register(UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                ErrorResponseVM errorResponse = _authBL.CheckUsernameOrEmailExists(userVM);
                if (errorResponse.IsValid)
                {
                    var isRegistered = _authBL.Register(userVM);
                    if(isRegistered)
                        return Ok();
                    else
                        return InternalServerError();
                }
                else
                    return BadRequest(JsonConvert.SerializeObject(errorResponse.Errors));
            }
            else
            {
                var validationResult = CustomDataAnnotation.ValidateEntity<UserVM>(userVM);
                return BadRequest(JsonConvert.SerializeObject(validationResult.ValidationErrors));
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetPassword(string email)
        {
            bool isExists = _authBL.CheckEmailExists(email);
            if (isExists)
            {
                var isSent = await _authBL.SendEmail(email);
                if (isSent)
                    return Ok();
                else
                    return InternalServerError();
            }
            else
                return BadRequest(JsonConvert.SerializeObject(new { ErrorMessage = "Email Doesn't registred!"}));     
        }
    }
}
