using l2g.BL;
using l2g.Entities.BusinessEntities;
using l2g.Entities.ValidationEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace l2g.Controllers
{
    [Authorize]
    [RoutePrefix("quote")]
    public class QuoteController : ApiController
    {
        [HttpPost]
        [Route("save")]
        public IHttpActionResult SaveQuote(GetQuote quote)
        {
            if (ModelState.IsValid)
            {
                QuoteBL quoteBL = new QuoteBL();
                ErrorResponseVM errors = quoteBL.ValidateGetQuote(quote);
                if (errors.IsValid)
                {
                    string username = User.Identity.Name;
                    bool isAdded = quoteBL.AddQuote(quote, username);
                    if (isAdded)
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
                var validationResult = CustomDataAnnotation.ValidateEntity<GetQuote>(quote);
                return BadRequest(JsonConvert.SerializeObject(validationResult.ValidationErrors));
            }
        }
    }
}
