using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Controllers
{
    [Route("api/v1/u/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        public RestaurantsController()
        {

        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # User Service");

            return Ok("Inbound test Restaurant Controller");
        }
    }
}
