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
using System.Web;
using System.Web.Http;

namespace l2g.Controllers
{
    [RoutePrefix("user")]
    [Authorize]
    public class UserController : ApiController
    {
        private IUserBL _userBL;
        public UserController(IUserBL userBL)
        {
            _userBL = userBL;
        }

        [HttpGet]
        [Route("getAll")]
        public IHttpActionResult GetAll()
        {
                UserDetailsFullVM user = _userBL.GetAllDetails();
                return Ok(user);
        }

        [Route("getBankDetails")]
        [HttpGet]
        public IHttpActionResult GetBankDetails()
        {
                UserBankDetailsVM userVM = _userBL.GetBankDetails();
                return Ok(userVM);
        }

        [Route("addBankDetails")]
        [HttpPost]
        public IHttpActionResult AddBankDetails(GetUserBankDetails userVM)
        {   
            if (ModelState.IsValid)
            {
                bool isExists = _userBL.CheckBankDetailsExists();
                if (!isExists)
                {
                    ErrorResponseVM errors = _userBL.CheckAccountNoExists(userVM);
                    if (errors.IsValid)
                    {
                        bool isSuccess = _userBL.AddBankDetails(userVM);
                        if (isSuccess)
                            return Ok();
                        else
                            return InternalServerError();
                    }
                    else
                    {
                        return BadRequest(JsonConvert.SerializeObject(errors.Errors));
                    }
                }
                else
                {
                    ErrorResponseVM errors = _userBL.CheckAccountNoExistsONUpdate(userVM);
                    if (errors.IsValid)
                    {
                        bool isSuccess = _userBL.UpdateBankDetails(userVM);
                        if (isSuccess)
                            return Ok();
                        else
                            return InternalServerError();
                    }
                    else
                    {
                        return BadRequest(JsonConvert.SerializeObject(errors.Errors));
                    }
                }
            }
            else
            {
                var validationResult = CustomDataAnnotation.ValidateEntity<GetUserBankDetails>(userVM);
                return BadRequest(JsonConvert.SerializeObject(validationResult.ValidationErrors));
            }
        }

        [Route("getEmploymentDetails")]
        [HttpGet]
        public IHttpActionResult GetEmploymentDetails()
        { 
            UserEmploymentDetailsVM userVM = _userBL.GetUserEmploymentDetails();
            return Ok(userVM);
        }

        [Route("addEmploymentDetails")]
        [HttpPost]
        public IHttpActionResult AddEmploymentDetails(GetUserEmploymentDetails userVM)
        {
            if (ModelState.IsValid)
            {
                
                    bool isSuccess = _userBL.AddOrUpdateUserEmploymentDetails(userVM);
                    if (isSuccess)
                        return Ok();
                    else
                        return InternalServerError();
                
            }
            else
            {
                var validationResult = CustomDataAnnotation.ValidateEntity<GetUserEmploymentDetails>(userVM);
                return BadRequest(JsonConvert.SerializeObject(validationResult.ValidationErrors));
            }
        }

        [Route("getUserDetails")]
        [HttpGet]
        public IHttpActionResult GetUserDetails()
        {
                UserDetailsVM userVM = _userBL.GetUserDetails();
                return Ok(userVM);
        }

        [Route("addUserDetails")]
        [HttpPost]
        public IHttpActionResult AddUserDetails(UserDetailsVM userVM)
        {
            if (ModelState.IsValid)
            {
                bool isSuccess = _userBL.AddOrUpdateUserDetails(userVM);
                if (isSuccess)
                    return Ok();
                else
                    return InternalServerError();
            }
            else
            {
                var validationResult = CustomDataAnnotation.ValidateEntity<UserDetailsVM>(userVM);
                return BadRequest(JsonConvert.SerializeObject(validationResult.ValidationErrors));
            }
        }
        [HttpGet]
        [Route("getEmploymentDropdowns")]
        public IHttpActionResult GetEmploymentDropdown()
        {
            EmploymentDropdowns response = _userBL.getEmploymenttDropdown();
            return Ok(response);
        }
    }
}
