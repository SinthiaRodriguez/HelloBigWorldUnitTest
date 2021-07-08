using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiNetCore5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PruebameController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Hola desde web api");
        }
    }
}
