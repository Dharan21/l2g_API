using l2g.BL;
using l2g.BL.Interfaces;
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
    [Authorize]
    public class CarController : ApiController
    {
        private ICarBL _carBL;

        public CarController(ICarBL carBL)
        {
            _carBL = carBL;
        }
        public IHttpActionResult GetCars()
        {
            var getResponse = _carBL.GetCars();
            if (getResponse == null)
                return BadRequest();
            return Ok(getResponse);
        }
    }
}
