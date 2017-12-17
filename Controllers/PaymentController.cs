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
    [Route("api/payment")]
    public class PaymentController : Controller
    {
        [HttpPost]
        public IActionResult processPayment([FromBody]Payment payment)
        {
            return Ok();
        }
    }
}