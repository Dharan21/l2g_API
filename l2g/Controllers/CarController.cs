using l2g.BL;
using l2g.Entities.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace l2g.Controllers
{
    public class CarController : ApiController
    {
        public IHttpActionResult GetCars()
        {
            CarBL carBL = new CarBL();
            var carResponse = carBL.GetCars();
            if (carResponse == null)
                return BadRequest();
            return Ok(carResponse);
        }
    }
}
