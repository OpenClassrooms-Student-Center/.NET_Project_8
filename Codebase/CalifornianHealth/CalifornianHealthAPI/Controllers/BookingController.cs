using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CalifornianHealthAPI.Models;

namespace CalifornianHealthAPI.Controllers
{
    [RoutePrefix("api/Contacts")]
    public class BookingController : ApiController
    {
        [Route("")]
        [System.Web.Http.Description.ResponseType(typeof(BookingModel))]
        public IHttpActionResult Post(BookingModel bookingModel)
        {
            throw new NotImplementedException;
        }
    }
}
