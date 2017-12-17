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
    public class CustomerController : Controller
    {
        private readonly DBContext _context;

        public CustomerController(DBContext context)
        {
            this._context = context;
        }

        [HttpPost]
        [Route("api/authentication/login")]
        public IActionResult loginUser([FromBody]Customer user)
        {
            var item = _context.Users.FirstOrDefault(t => t.UserName == user.UserName && t.Password == user.Password);
            if (item == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/authentication/register")]
        public IActionResult registerUser([FromBody]Customer user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok();
        }
    }
}