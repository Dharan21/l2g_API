using l2g.BL;
using l2g.Entities.BusinessEntities;
using l2g.Entities.ValidationEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace l2g.Controllers
{
    [RoutePrefix("user")]
    [Authorize]
    public class UserController : ApiController
    {
        [Route("getBankDetails")]
        [HttpGet]
        public IHttpActionResult GetBankDetails()
        {
            using (var userBL = new UserBL())
            {
                UserBankDetailsVM userVM = userBL.GetBankDetails();
                return Ok(userVM);
            }
        }

        [Route("addBankDetails")]
        [HttpPost]
        public IHttpActionResult AddBankDetails(UserBankDetailsVM userVM)
        {
            if(ModelState.IsValid)
            {
                using (var userBL = new UserBL())
                {
                    bool isAdded = userBL.AddBankDetails(userVM);
                    if (isAdded)
                        return Ok();
                    else
                        return InternalServerError();
                }
            }
            else
            {
                var validationResult = CustomDataAnnotation.ValidateEntity<UserBankDetailsVM>(userVM);
                return BadRequest(JsonConvert.SerializeObject(validationResult.ValidationErrors));
            }      
        }

        [Route("getEmploymentDetails")]
        [HttpGet]
        public IHttpActionResult GetEmploymentDetails()
        {
            using (var userBL = new UserBL())
            {
                UserEmploymentDetailsVM userVM = userBL.GetUserEmploymentDetails();
                return Ok(userVM);
            }
        }

        [Route("addEmploymentDetails")]
        [HttpPost]
        public IHttpActionResult AddEmploymentDetails(UserEmploymentDetailsVM userVM)
        {
            if (ModelState.IsValid)
            {
                using (var userBL = new UserBL())
                {
                    bool isAdded = userBL.AddUserEmploymentDetails(userVM);
                    if (isAdded)
                        return Ok();
                    else
                        return InternalServerError();
                }
            }
            else
            {
                var validationResult = CustomDataAnnotation.ValidateEntity<UserEmploymentDetailsVM>(userVM);
                return BadRequest(JsonConvert.SerializeObject(validationResult.ValidationErrors));
            }
        }

        [Route("getUserDetails")]
        [HttpGet]
        public IHttpActionResult GetUserDetails()
        {
            using (var userBL = new UserBL())
            {
                UserDetailsVM userVM = userBL.GetUserDetails();
                return Ok(userVM);
            }
        }

        [Route("addUserDetails")]
        [HttpPost]
        public IHttpActionResult AddUserDetails(UserDetailsVM userVM)
        {
            if (ModelState.IsValid)
            {
                using (var userBL = new UserBL())
                {
                    bool isAdded = userBL.AddUserDetails(userVM);
                    if (isAdded)
                        return Ok();
                    else
                        return InternalServerError();
                }
            }
            else
            {
                var validationResult = CustomDataAnnotation.ValidateEntity<UserDetailsVM>(userVM);
                return BadRequest(JsonConvert.SerializeObject(validationResult.ValidationErrors));
            }
        }
    }
}
