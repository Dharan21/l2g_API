using l2g.BL;
using l2g.Entities.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace l2g.Controllers
{
    [EnableCors("*","*","*")]
    public class CarController : ApiController
    {
        public IHttpActionResult GetCars()
        {
            CarBL carBL = new CarBL();
            var getResponse = carBL.GetCars();
            if (getResponse == null)
                return BadRequest();
            return Ok(getResponse);
        }
    }
}
