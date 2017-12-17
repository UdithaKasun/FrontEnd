using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SPDC.Models;
using Microsoft.AspNetCore.Cors;

namespace SPDC.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("api/sms")]
    public class SMSController : Controller
    {
        [HttpPost]
        public IActionResult sendMessage([FromBody]Message message)
        {
            return Ok();
        }
    }
}